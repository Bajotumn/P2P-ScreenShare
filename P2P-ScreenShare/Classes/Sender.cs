using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace P2P_ScreenShare.Communications {
    public class Sender : Communicator {
        private TcpClient pClient = null;
        public delegate void ConnectionErrorHandler(SocketException ex);
        public event ConnectionErrorHandler ConnectionError = null;
        public event EventHandler ConnectionComplete = null;
        public event EventHandler ConnectionClosed = null;
        public event EventHandler ReceivedPingResponse = null;
        private Thread tMakeConnection = null;
        private Thread tPing = null;
        public bool Connected {
            get {
                if (this.pClient == null) {
                    return false;
                }
                return this.aSock.Connected;
            }
        }
        public Sender(IPAddress pIP, int pPort) {
            MyName = "Sender  ";
            WriteColor = ConsoleColor.Magenta;
            SetEndPoint(pIP.ToString(), pPort.ToString());
            this.pClient = new TcpClient();
            SetSocket(pClient.Client);
        }

        public void SendImage(Image img) {
            if (img != null) {
                Packet pack = new Packet(imageToByteArray(img), Packet.tPacketType.Image);
                this.Send(pack);
            }
        }
        private byte[] imageToByteArray(Image img) {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public bool BeginConnect() {
            if (tMakeConnection == null) {
                tMakeConnection = new Thread(new ThreadStart(MakeConnection));
                tMakeConnection.Start();
                return true;
            }
            return false;
        }

        private void MakeConnection() {
            WriteLine("Attempting to connect to " + this.aEndPoint.ToString() + "...");
            try {
                this.pClient.Connect(this.aEndPoint);
                this.tPing = new Thread(new ThreadStart(SendPing));

                ConnectionComplete?.Invoke(this, new EventArgs());
            } catch (SocketException e) {
                ConnectionError?.Invoke(e);
                WriteError(e);
            }
            if (this.tPing != null) {
                this.tPing.Start();
            }
        }
        private void ReceiveData() {
            Packet pack = Receive(this.aSock);
            if (pack != null) {
                if (pack.PacketType == Packet.tPacketType.Ping) {
                    WriteLine("Received ping packet");
                    this.PingResponse();
                }

            } else {
                Disconnect();
            }
        }

        private void PingResponse() {
            ReceivedPingResponse?.Invoke(this, new EventArgs());
        }
        private void SendPing() {
            while (this.Connected) {
                this.Send(new Packet(new byte[32], Packet.tPacketType.Ping));
                ReceiveData();
                Thread.Sleep(5000);
            }
        }

        public void Disconnect() {
            WriteLine("Disconnecting from " + this.aEndPoint.ToString() + ", closing sockets and streams...");
            if (this.ConnectionClosed != null) {
                ConnectionClosed(this, new EventArgs());
            }
            if (this.pClient != null) {
                if (this.pClient.Client != null) {
                    this.pClient.Client.Close();
                }

                this.pClient.Close();
            }
        }
        public void Cleanup() {
            this.ConnectionClosed = null;
            this.ConnectionComplete = null;
            this.ConnectionError = null;
            this.ReceivedPingResponse = null;
        }
    }
}
