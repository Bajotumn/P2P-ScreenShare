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
            //s.SendTimeout = 30000;
            //s.ReceiveTimeout = 30000;
            this.aSock = s;
        }
        #region sending methods
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
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                do {
                    byte[] receiveBuffer = new Byte[s.Available];
                    s.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
                    pBuff.Append(receiveBuffer);
                } while (pBuff.Length < contentLength);
                stopWatch.Stop();
                WriteLine("Received {0} bytes of data from {1:0,000} in {2} ms", contentLength, s.RemoteEndPoint, stopWatch.ElapsedMilliseconds);
                return new Packet(pBuff.Buffer);
            } catch (Exception e) {
                WriteLine(e.Message);
            }
            return null;
        }
        #endregion
        #region Abstract variables
        public Socket aSock = null;
        public IPEndPoint aEndPoint = null;
        public ConsoleColor WriteColor = Console.ForegroundColor;
        #endregion
        #region Private variables
        private string _myname = "CommBase";
        #endregion
        #region Console writing accessors
        private void Name() {
            /*
            Console.ForegroundColor = WriteColor;
            Console.Write(MyName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[{0}]", System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("::");
            Console.ForegroundColor = WriteColor;
            */
        }
        /*
        internal void WriteNoName(string format, params object[] args) {
            Console.Write(format, args);
        }
        internal void WriteNoName(object data) {
            Console.Write(data);
        }
        */
        internal void Write(string format, params object[] args) {
            //Name();
            //Console.Write(format, args);
            DebugConsole.Write(WriteColor, MyName, format, args);
        }
        internal void Write(object data) {
            //Name();
            //Console.Write(data);
            DebugConsole.Write(WriteColor, MyName, data);
        }
        /*
        internal void WriteLineNoName(string format, params object[] args) {
            Console.WriteLine(format, args);
        }
        internal void WriteLineNoName(object data) {
            Console.WriteLine(data);
        }
        */
        internal void WriteLine(string format, params object[] args) {
            //Name();
            //Console.WriteLine(format, args);
            DebugConsole.WriteLine(WriteColor,MyName,format, args);
        }
        internal void WriteLine(object data) {
            //Name();
            //Console.WriteLine(data);
            DebugConsole.WriteLine(WriteColor, MyName, data);
        }
        #endregion
    }
}
