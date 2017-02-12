using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace P2P_ScreenShare.Communications {
    /// <summary>
    /// A base class for receivers. Extends Communicator.
    /// </summary>
    public class Receiver : Communicator {
        private TcpListenerEx pListener = null;
        /// <summary>
        /// If the server is listening this is true if not or if null it is false
        /// </summary>
        public bool Listening {
            get {
                if (pListener == null) {
                    return false;
                }
                return this.pListener.Active;
            }
        }
        public delegate void ImageReceivedHandler(IPEndPoint dSource, Image dImageReceived);
        public delegate void ImageRequestHandler(IPEndPoint dSource);
        public delegate void ClientEventHandler(IPEndPoint dSource);

        public event ImageReceivedHandler ImageReceived = null;
        public event ImageRequestHandler ImageRequested = null;
        public event ClientEventHandler ClientConnected = null;
        public event ClientEventHandler ClientDisconnected = null;

        private Thread ServerListenerThread = null;
        private List<TcpClient> ConnectedClients = new List<TcpClient>();
        public Receiver(string pIP, string pPort) {
            MyName = "Receiver";
            WriteColor = ConsoleColor.Cyan;
            SetEndPoint(pIP, pPort);
            this.pListener = new TcpListenerEx(this.aEndPoint);
            SetSocket(pListener.Server);
            ServerListenerThread = new Thread(new ThreadStart(ServerListenHandler));
        }

        private void ServerListenHandler() {
            WriteLine("Server Listening on " + this.aEndPoint);
            while (this.pListener.Active) {
                try {
                    TcpClient cli = this.pListener.AcceptTcpClient();
                    ClientConnected?.Invoke((IPEndPoint)cli.Client.RemoteEndPoint);
                    WriteLine("Client[" + cli.Client.RemoteEndPoint.ToString() + "] connected!");
                    Thread cliComm = new Thread(new ParameterizedThreadStart(ClientCommunicationHandler));
                    ConnectedClients.Add(cli);
                    cliComm.Start(cli);
                } catch (SocketException sockEx) {
                    if (sockEx.ErrorCode != 10004) //WSACancelBlockingCall
                        WriteLine(sockEx);
                }catch (ObjectDisposedException disposeEx) {
                    WriteLine(disposeEx);
                }
            }
        }

        private void ClientCommunicationHandler(object o) {
            TcpClient tClient = (TcpClient)o;
            Socket sock = tClient.Client;

            IPEndPoint cliEndPoint = (IPEndPoint)sock.RemoteEndPoint;
            while (tClient.Connected) {
                try {
                    Packet packet = Receive(tClient.Client);
                    if (packet != null) {
                        if (!ParseReceivedData(packet, sock)) {
                            WriteLine("The packet was not valid.");
                        } else {
                            tClient.Client.Send(new Packet(new byte[0x00], Packet.tPacketType.EMPTY));
                        }
                    } else {
                        break;
                    }
                } catch (SocketException sockEx) {
                    WriteLine(sockEx.Message);
                    break;
                }
            }
            if (ConnectedClients.Contains(tClient)) {
                ConnectedClients.Remove(tClient);
            }
            ClientDisconnected?.Invoke(cliEndPoint);
            
            WriteLine("Closing connection to client [" + cliEndPoint + "]");
            if (tClient != null) {
                if (tClient.Client != null) {
                    tClient.Client.Close();
                }
                tClient.Close();
            }
        }

        private bool ParseReceivedData(Packet packet, Socket sock) {
            string action = null;
            bool isValidPacket = false;
            switch (packet.PacketType) {
                case Packet.tPacketType.Ping:
                    action = ("Responding");
                    isValidPacket = true;
                    sock.Send(packet);
                    break;
                case Packet.tPacketType.ImageRequest:

                    isValidPacket = true;
                    if (ImageRequested != null) {
                        ImageRequested((IPEndPoint)sock.RemoteEndPoint);
                        action = ("Raising event");
                    } else {
                        action = ("No event");
                    }
                    break;
                case Packet.tPacketType.Image:
                    isValidPacket = true;
                    Image lImage = GetImage(ByteSubArray(packet.Buffer, Packet.HEADER_SIZE));
                    if (ImageReceived != null) {
                        ImageReceived((IPEndPoint)sock.RemoteEndPoint, lImage);
                        action = ("Raising event");
                    } else {
                        action = ("No event");
                    }
                    break;
                default:
                    action = ("Unknown packet type!");
                    break;
            }
            WriteLine("Received a(n) {0} packet...{1}", packet.PacketType, action);
            return isValidPacket;
        }

        private Image GetImage(byte[] dataStream) {
            MemoryStream ms = new MemoryStream(dataStream);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private byte[] ByteSubArray(byte[] data, int index) {
            byte[] ret = new byte[data.Length - index];
            int x = 0;
            for (int i = index; i < data.Length; i++) {
                ret[x++] = data[i];
            }
            return ret;
        }

        public void Start() {
            if (Listening) {
                Stop();
            }
            this.pListener.Start();
            if (this.pListener.Server.IsBound) {
                ServerListenerThread.Start();
            } else {
                throw new Exception("The listener was not able to bind itself to the local port(" + this.aEndPoint.Port + ")!");
            }
        }
        public void Stop() {
            WriteLine("Stopped listening");
            ConnectedClients.ForEach(new Action<TcpClient>(CloseClientConnection));
            this.pListener.Server.Close();
            this.pListener.Stop();
        }

        public void Cleanup() {
            this.ClientConnected = null;
            this.ClientDisconnected = null;
            this.ImageReceived = null;
            this.ImageRequested = null;
        }

        private void CloseClientConnection(TcpClient c) {
            c.Close();
        }
    }
}
