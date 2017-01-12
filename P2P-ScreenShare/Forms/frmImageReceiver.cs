using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace P2P_ScreenShare {
    public partial class frmImageReceiver : Form {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        public frmImageReceiver() {
            InitializeComponent();
        }
        public frmImageReceiver(System.Net.IPEndPoint pName) {
            InitializeComponent();
            txtMyName.Text = pName.ToString();
        }
        public void SetImage(Image img) {
            if (this.InvokeRequired) {
                this.Invoke(new Action<Image>(SetImage), img);
                return;
            }
            if (this.Size.Width != img.Size.Width) {
                this.Width = img.Size.Width;
            }
            if (this.Size.Height + txtMyName.Height != img.Size.Height) {
                this.Height = img.Size.Height + txtMyName.Height;
            }
            this.picImage.Image = img;
        }
        public Image GetImage() {
            return this.picImage.Image;
        }

        private void frmImageReceiver_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (ReleaseCapture()) {
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void picImage_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (ReleaseCapture()) {
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        public void Disconnected() {
            if (this.InvokeRequired) {
                this.Invoke(new MethodInvoker(Disconnected));
                return;
            }
            this.Close();
        }
        public void Connected() {
            if (this.InvokeRequired) {
                this.Invoke(new MethodInvoker(Connected));
            }
            this.Show();
        }

        private void topmostToolStripMenuItem_Click(object sender, EventArgs e) {
            topmostToolStripMenuItem.Checked = !topmostToolStripMenuItem.Checked;
            this.TopMost = topmostToolStripMenuItem.Checked;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
