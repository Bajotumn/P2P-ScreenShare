using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace P2P_ScreenShare {
    public class ConsoleWrite {


        private ConsoleColor _color;
        public ConsoleColor Color { get { return _color; } set { _color = value; } }

        private object _src;
        public object Source { get { return _src; } set { _src = value; } }
        private object _data;
        public object Data { get { return _data; } set { _data = value; } }
        private int _thread;
        public int ThreadID { get { return _thread; } set { _thread = value; } }
        public Exception Ex{get;set;}

        public ConsoleWrite(ConsoleColor color, object src, object data) {
            this.Color = color;
            this.Source = src;
            this.Data = data;
            this.ThreadID = Thread.CurrentThread.ManagedThreadId;
        }
        public ConsoleWrite(ConsoleColor color, object src, object data, Exception ex) {
            this.Color = color;
            this.Source = src;
            this.Data = data;
            this.ThreadID = Thread.CurrentThread.ManagedThreadId;

            this.Ex = ex;

        }
    }
    public static class DebugConsole {
        #region Programatically show/hide console
        public static void ShowConsoleWindow() {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero) {
                AllocConsole();
            } else {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow() {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        #endregion

        private static Thread writerThread = new Thread(new ThreadStart(write));
        private static bool processQueue = false;
        private static ConcurrentQueue<ConsoleWrite> writeQueue = new ConcurrentQueue<ConsoleWrite>();


        public static void Init() {
            ShowConsoleWindow();
            processQueue = true;
            writerThread.Start();

        }
        public static void Stop() {
            HideConsoleWindow();
            processQueue = false;
        }
        private static void write() {
            ConsoleWrite qCurrent = null;
            do {

                if (writeQueue.Count > 0) {
                    if (writeQueue.TryDequeue(out qCurrent)) { 
                    
                        //Set restore color
                        ConsoleColor originalColor = Console.ForegroundColor;

                        //Write src name in the passed color
                        Console.ForegroundColor = qCurrent.Color;
                        Console.Write(qCurrent.Source);

                        //Write the originating thread id in white
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[{0}]", qCurrent.ThreadID);


                        //Write the divider in yellow
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("::");
                        
                        //Write the data in the passed color
                        Console.ForegroundColor = qCurrent.Color;
                        Console.Write(qCurrent.Data);

                        //Is this an exception?
                        if(qCurrent.Ex != null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(qCurrent.Ex.Message);

                            Console.ForegroundColor = originalColor;
                            Console.Write(" : \r\n");

                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(qCurrent.Ex.StackTrace);

                            //Exceptions always write line
                            Console.Write("\r\n");
                        }

                        //Restore the color
                        Console.ForegroundColor = originalColor;
                    }
                }
            } while (processQueue);
        }
        /// <summary>
        /// Write an object's string representation to the console
        /// </summary>
        /// <param name="color">Color to write in</param>
        /// <param name="src">Originating object</param>
        /// <param name="format">String format</param>
        /// <param name="args">String args</param>
        public static void Write(ConsoleColor color, object src, string format, params object[] args) {
            _queueWrite(color, src, String.Format(format, args));
        }
        /// <summary>
        /// Write an object's string representation to the console with a \r\n
        /// </summary>
        /// <param name="color">Color to write in</param>
        /// <param name="src">Originating object</param>
        /// <param name="format">String format</param>
        /// <param name="args">String args</param>
        public static void WriteLine(ConsoleColor color, object src, string format, params object[] args) {
            _queueWrite(color, src, String.Format(format + "\r\n", args));
        }

        /// <summary>
        /// Write an object's string representation to the console
        /// </summary>
        /// <param name="color">Color to write in</param>
        /// <param name="src">Originating object</param>
        /// <param name="data">Data to write (Uses ToString())</param>
        public static void Write(ConsoleColor color, object src, object data) {
            _queueWrite(color, src, data.ToString());
        }
        /// <summary>
        /// Write an object's string representation to the console with a \r\n
        /// </summary>
        /// <param name="color">Color to write in</param>
        /// <param name="src">Originating object</param>
        /// <param name="data">Data to write (Uses ToString())</param>
        public static void WriteLine(ConsoleColor color, object src, object data) {
            _queueWrite(color, src, data.ToString() + "\r\n");
        }

        /// <summary>
        /// Write an object's string representation to the console with a \r\n
        /// </summary>
        /// <param name="color">Color to write in</param>
        /// <param name="src">Originating object</param>
        /// <param name="ex">Exception to write</param>
        public static void WriteError(ConsoleColor color, object src, Exception ex) {
            _queueError(color, src, String.Empty, ex);
        }

        /// <summary>
        /// Write an object's string representation to the console with a \r\n
        /// </summary>
        /// <param name="color">Color to write in</param>
        /// <param name="src">Originating object</param>
        /// <param name="data">Additional data to write before exception data</param>
        /// <param name="ex">Exception to write</param>
        public static void WriteError(ConsoleColor color, object src, object data, Exception ex) {
            _queueError(color, src, data.ToString(), ex);
        }

        private static void _queueError(ConsoleColor color, object src, string data, Exception ex) {
            ConsoleWrite item = new ConsoleWrite(color, src, data, ex);
            writeQueue.Enqueue(item);
        }
        private static void _queueWrite(ConsoleColor color, object src, string data) {
#if DEBUG
            ConsoleWrite item = new ConsoleWrite(color, src, data);
            writeQueue.Enqueue(item);
#endif
        }
    }
}