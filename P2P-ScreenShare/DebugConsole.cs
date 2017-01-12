using System;
using System.Collections.Generic;
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

        public ConsoleWrite(ConsoleColor color, object src, object data) {
            this.Color = color;
            this.Source = src;
            this.Data = data;
            this.ThreadID = Thread.CurrentThread.ManagedThreadId;
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
        private static Queue<ConsoleWrite> writeQueue = new Queue<ConsoleWrite>();


        public static void Init() {
            ShowConsoleWindow();
            processQueue = true;
            writerThread.Start();

        }
        public static void Stop() {
            HideConsoleWindow();
            processQueue = false;
            writerThread.Abort();
        }
        private static void write() {
            ConsoleWrite qCurrent = null;
            do {

                if (writeQueue.Count > 0) {
                    if ((qCurrent = writeQueue.Dequeue()) != null) { 
                    
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

        private static void _queueWrite(ConsoleColor color, object src, string data) {
#if DEBUG
            ConsoleWrite item = new ConsoleWrite(color, src, data);
            writeQueue.Enqueue(item);
#endif
        }
    }
}