using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections;
using P2P_ScreenShare.Communications;

namespace P2P_ScreenShare {
    public partial class frmMain : Form {
        #region Variables

        #region Public
        public bool SenderConnected {
            get {
                bool senderConnected = false;
                foreach (SenderControl sCon in commDataSenderList) {
                    senderConnected = sCon.Connected;
                    if (senderConnected) { break; }
                }
                return senderConnected;
            }
        }
        /// <summary>
        /// Receiver instance used to set up a server
        /// </summary>
        public Receiver commDataReceiver {
            get {
                return conReceiver.commDataReceiver;
            }
            set {
                conReceiver.commDataReceiver = value;
            }
        }
        /// <summary>
        /// Simple List of SenderControls for sending images to multiple hosts.
        /// </summary>
        public List<SenderControl> commDataSenderList = new List<SenderControl>();
        /// <summary>
        /// holds the image captured for manipulation and or sending
        /// </summary>
        public Image imgCapture {
            get { return picViewport.Image; }
            set { picViewport.Image = value; }
        }
        /// <summary>
        /// True if the receiver is listening. False if it is null or not listening.
        /// </summary>

        /// <summary>
        /// Hashtable of the image receiver forms, using the IPEndPoint of the
        /// client it receives from as the key
        /// </summary>
        public Hashtable imageReceivers = new Hashtable();
        #endregion

        #region Private
        /// <summary>
        /// Timer used to capture image from screen and send with each connected Sender
        /// </summary>
        private Timer tmrImageCapture = new Timer();
        #endregion

        #endregion

        public frmMain() {
            InitializeComponent();
            BuildTimerResolutionList();
            tmrImageCapture.Interval = 5000;
            tmrImageCapture.Tick += delegate {
                SendImage();
            };

        }

        #region Events
        private void frmMain_Load(object sender, EventArgs e) {
            LoadSettings();
            BuildSenderList();
        }
        private void chkViewCaptureAreaForm_CheckedChanged(object sender, EventArgs e) {
            Program.captureArea.Visible = chkViewCaptureAreaForm.Checked && SenderConnected;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (commDataReceiver != null) {
                commDataReceiver.Stop();
            }
            commDataSenderList.ForEach(new Action<SenderControl>(DisconnectSender));
            SaveSettings();
            Environment.Exit(0);
        }
        private void cboTimerResolution_TextChanged(object sender, EventArgs e) {
            double d = (double)(tmrImageCapture.Interval / 1000);
            if (!double.TryParse(cboTimerResolution.Text, out d)) {
                MessageBox.Show("Enter a number");
                cboTimerResolution.Text = d.ToString();
            } else {
                tmrImageCapture.Interval = (int)(d * 1000);
            }

        }
        private void btnStartStopCapturingImages_Click(object sender, EventArgs e) {
            ImageCaptureAndSendController();
        }
        private void sender_ConnectionError(SenderControl source, Exception ex) {

        }
        #endregion

        #region Functions

        #region Private
        private void LoadSettings() {
            cboTimerResolution.Text = Program.Settings.loadSetting("TimerResolution", "5.0").ToString();
            conReceiver.LoadSettings();
        }
        private void SaveSettings() {
            Program.Settings.saveSetting("TimerResolution", cboTimerResolution.Text);
            conReceiver.SaveSettings();
            SaveSenderSettings();
        }
        private void SaveSenderSettings() {
            foreach (SenderControl sCon in tblSenders.Controls) {
                sCon.SaveSettings();
            }
        }

        private void BuildSenderList() {
            foreach (SenderControl sCon in tblSenders.Controls) {
                commDataSenderList.Add(sCon);
                sCon.LoadSettings();
            }
        }
        private void BuildTimerResolutionList() {
            for (double i = 0; i <= 10; i += .5) {
                cboTimerResolution.Items.Add(i);
            }
            cboTimerResolution.Items.RemoveAt(0);
        }

        private void SendImage() {
            Image i = ScreenCapture.CaptureScreenArea(new Rectangle(Program.captureArea.ReferencePoint, Program.captureArea.ClientSize));
            SetPreviewImage(i);
            commDataSenderList.ForEach(new Action<SenderControl>(SendImageTo));
        }
        private void SendImageTo(SenderControl sCon) {
            sCon.SendImage(imgCapture);
        }

        private void DisconnectSender(SenderControl sCon) {
            if (sCon.commDataSender != null) {
                sCon.commDataSender.Disconnect();
            }
        }

        private void ImageCaptureAndSendController() {
            if (!tmrImageCapture.Enabled) {
                btnStartStopCapturingImages.Text = "Stop Sending Images";
                tmrImageCapture.Start();
            } else {
                btnStartStopCapturingImages.Text = "Start Sending Images";
                tmrImageCapture.Stop();
            }
        }
        #endregion

        #region Public
        public void SetPreviewImage(Image i) {
            if (this.InvokeRequired) {
                this.Invoke(new Action<Image>(SetPreviewImage), i);
                return;
            }
            this.imgCapture = i;
        }
        #endregion

        

        #endregion
    }
}
