using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P2P_ScreenShare {
    static class Program {
        public static frmMain main = null;
        public static frmCaptureArea captureArea = null;
        public static Bajotumn.registrySettings Settings = new Bajotumn.registrySettings("P2P-ScreenViewer");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            captureArea = new frmCaptureArea();
#if DEBUG
            DebugConsole.Init();
#endif
            SetupConsole();
            Application.Run((main = new frmMain()));
#if DEBUG
            DebugConsole.Stop(); 
#endif
        }
        private static void SetupConsole() {
            try {
                Console.BufferWidth = 120;
                Console.WindowWidth = 120;
                Console.WindowHeight = 30;
            } catch { }
        }
        public static void killThread(System.Threading.Thread t) {
            if (t != null) {
                if (t.IsAlive) {
                    t.Abort();
                }
            }
        }
    }
}
