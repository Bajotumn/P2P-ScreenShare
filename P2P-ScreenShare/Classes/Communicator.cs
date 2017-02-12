using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace P2P_ScreenShare.Communications {
    public abstract class Communicator {
        internal string MyName {
            get { return _myname; }
            set { _myname = value; }
        }

        internal void SetEndPoint(string pIP, string pPort) {
            IPAddress lIPAddress = null;
            if (!IPAddress.TryParse(pIP, out lIPAddress)) {
                throw new Exception("The supplied IPAddress(" + pIP + ") was not a valid IPAddress");
            }
            Int32 lPort = -1;
            if (!Int32.TryParse(pPort, out lPort)) {
                throw new Exception("Supplied port(" + pPort + ") was not a valid port number");
            }
            this.aEndPoint = new IPEndPoint(lIPAddress, lPort);
        }

        internal void SetSocket(Socket s) {
            this.aSock = s;
        }
        #region Sending Methods
        internal void Send(Packet packet) {

            WriteLine("Sending a(n) ({0}) packet {1} bytes long.", packet.PacketType, packet.Length);
            try {
                if (this.aSock != null) {
                    if (this.aSock.Connected) {
                        this.aSock.Send(packet.Buffer);
                    }
                }
            } catch { }
        }
        #endregion
        #region Receiving Methods
        internal Packet Receive(Socket s) {
            try {
                byte[] header = new byte[Packet.HEADER_SIZE];
                s.Receive(header, Packet.HEADER_SIZE, SocketFlags.None);
                PacketBuffer pBuff = new PacketBuffer(header);
                int contentLength = BitConverter.ToInt32(header, 0);

                // Start the stopwatch after receiving the header
                // Recieve is blocking, it'll wait for data before continuing
                // We don't want our stopwatch to count the delay between image packets
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                do {
                    byte[] receiveBuffer = new byte[s.Available];
                    s.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
                    pBuff.Append(receiveBuffer);
                } while (pBuff.Length < contentLength);
                stopWatch.Stop();
                WriteLine("Received {0} bytes of data from {1:0,000} in {2} ms", contentLength, s.RemoteEndPoint, stopWatch.ElapsedMilliseconds);
                return new Packet(pBuff.Buffer);
            } catch (Exception e) {
                WriteError(e);
            }
            return null;
        }
        #endregion
        #region Abstract variables
        internal Socket aSock = null;
        internal IPEndPoint aEndPoint = null;
        internal ConsoleColor WriteColor = Console.ForegroundColor;
        #endregion
        #region Private variables
        private string _myname = "CommBase";
        #endregion
        #region Console writing Methods
        
        internal void Write(string format, params object[] args) {

            DebugConsole.Write(WriteColor, MyName, format, args);
        }
        internal void Write(object data) {

            DebugConsole.Write(WriteColor, MyName, data);
        }
        internal void WriteLine(string format, params object[] args) {
            DebugConsole.WriteLine(WriteColor,MyName,format, args);
        }
        internal void WriteLine(object data) {
            DebugConsole.WriteLine(WriteColor, MyName, data);
        }
        internal void WriteError(Exception ex) {
            DebugConsole.WriteError(WriteColor, MyName,ex);
        }
        #endregion
    }
}
