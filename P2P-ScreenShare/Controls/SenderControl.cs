using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using P2P_ScreenShare.Communications;

namespace P2P_ScreenShare {
    public partial class SenderControl : UserControl {
        /// <summary>
        /// Instance of Sender used to send data to a specific port and address
        /// </summary>
        public Sender commDataSender = null;
        public delegate void SenderControlConnectionErrorHandler(SenderControl source, System.Net.Sockets.SocketException ex);
        public event SenderControlConnectionErrorHandler ConnectionError = null;
        #region Variables
        #region Private
        private int _number = -1;
        private int _port = 0;
        private DateTime _lastPingTime = DateTime.Now;
        private DateTime lastPingTime {
            get { return _lastPingTime; }
            set {
                lblPing.Text = "Ping: " + (DateTime.Now - _lastPingTime).Milliseconds;
                _lastPingTime = value;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Sending of images will only occur if this value is set to true
        /// </summary>
        public bool SendingEnabled {
            get {
                return chkSendingEnabled.Checked;
            }
            set {
                chkSendingEnabled.Checked = value;
            }
        }
        /// <summary>
        /// Basic identifier for loading and saving settings
        /// </summary>
        public int Number {
            get { return _number; }
            set {
                _number = value;
                lblNumber.Text = value.ToString();
                ttConnectionError.ToolTipTitle = "Connection Error [" + value + "]";
            }
        }

        /// <summary>
        /// String value of the text in txtHost
        /// </summary>
        public string Host {
            get { return txtHost.Text; }
            set { txtHost.Text = value; }
        }

        /// <summary>
        /// String value of the text in txtPort
        /// </summary>
        public string PortString {
            get { return txtPort.Text; }
            set { txtPort.Text = value; }
        }

        /// <summary>
        /// int value of the text in txtPort
        /// </summary>
        public int Port {
            get { return _port; }
            set {
                _port = value;
                txtPort.Text = value.ToString();
            }
        }

        /// <summary>
        /// True if the sender is connected false if not or if null
        /// </summary>
        public bool Connected {
            get {
                if (commDataSender == null) {
                    return false;
                }
                return commDataSender.Connected;
            }
        }
        #endregion
        #endregion

        public SenderControl() {
            InitializeComponent();
            Number = 0; 
            SetToolTipTexts();
        }

        public SenderControl(int number) {
            InitializeComponent();
            Number = number; 
            SetToolTipTexts();
        }
        private void SetToolTipTexts() {
            ttInfo.SetToolTip(txtHost, "Remote host to connect to.\nThis can be a hostname or an IP.\nEx: example.com or 123.123.123.123");
            ttInfo.SetToolTip(picStatus, "Red = Not Connected/Error\nYellow = Attempting Connection\nGreen = Working");
        }

        #region Events
        private void btnConnectDisconnect_Click(object sender, EventArgs e) {
            if (!Connected) {
                commDataSender = new Sender(parseIPAddress(), Port);
                commDataSender.ConnectionError += new Sender.ConnectionErrorHandler(commDataSender_ConnectionError);
                commDataSender.ConnectionComplete += new EventHandler(commDataSender_ConnectionComplete);
                commDataSender.ReceivedPingResponse += new EventHandler(commDataSender_ReceivedPingResponse);
                commDataSender.ConnectionClosed += new EventHandler(commDataSender_ConnectionClosed);
                bool attemptingConnection = commDataSender.BeginConnect();
                if (attemptingConnection) {
                    
                    SetStatus(Color.Yellow, "Connecting...");
                }
                DisableEnableItems(!attemptingConnection);
            } else {
                commDataSender.Disconnect();
                commDataSender = null;
                Disconnected();
            }
        }

        void commDataSender_ConnectionClosed(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                this.Invoke(new EventHandler(commDataSender_ConnectionClosed), sender, e);
                return;
            }
            Disconnected();
        }

        private void Disconnected() {
            SetStatus("Disconnected");
            btnControlSender.Text = "Connect";
            DisableEnableItems(true);
            if ((frmMain)this.ParentForm != null) {
                if (!((frmMain)this.ParentForm).SenderConnected) {
                    Program.captureArea.Hide();
                }
            }
        }
        

        void commDataSender_ReceivedPingResponse(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                this.Invoke(new EventHandler(commDataSender_ReceivedPingResponse), sender, e);
                return;
            }
            lastPingTime = DateTime.Now;
        }

        void commDataSender_ConnectionComplete(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                this.Invoke(new EventHandler(commDataSender_ConnectionComplete), sender, e);
                return;
            }
            SetStatus("Connected");
            btnControlSender.Text = "Disconnect";
            btnControlSender.Enabled = true;
            lastPingTime = DateTime.Now;
            Program.captureArea.Show();
        }

        private void commDataSender_ConnectionError(System.Net.Sockets.SocketException ex) {
            if (this.InvokeRequired) {
                this.Invoke(new Sender.ConnectionErrorHandler(commDataSender_ConnectionError), ex);
                return;
            }
            ConnectionError?.Invoke(this, ex);
            showError(ex);
            DisableEnableItems(true);
            SetStatus("<Connection Error>");
        }

        private void showError(Exception ex) {
            this.ttConnectionError.Show(GetErrorString(ex), picStatus, 0, -this.Height, 3000);
        }

        private string GetErrorString(Exception ex) {
            return ex.Message;
        }

        private void txtPort_TextChanged(object sender, EventArgs e) {
            int i = Port;
            if (!Int32.TryParse(txtPort.Text, out i)) {
                MessageBox.Show("The string entered was not a number");
            }
            Port = i;
        }

        private void txtHost_Enter(object sender, EventArgs e) {
            txtHost.SelectAll();
        }
        #endregion

        #region Functions
        #region Internal
        /// <summary>
        /// Send image using this Sender
        /// </summary>
        /// <param name="imgCapture">Image to send</param>
        internal void SendImage(Image imgCapture) {
            if (this.Connected && SendingEnabled) {
                this.commDataSender.SendImage(imgCapture);
            }
        }

        /// <summary>
        /// Load settings from registry
        /// </summary>
        internal void LoadSettings() {
            Bajotumn.registrySettings settings = new Bajotumn.registrySettings("P2P-ScreenViewer\\Senders\\" + Number);
            Host = settings.loadSetting("Host", "127.0.0.1").ToString();
            PortString = settings.loadSetting("Port", "42069").ToString();
            chkSendingEnabled.Checked = Boolean.Parse(settings.loadSetting("SendingEnabled", Boolean.TrueString).ToString());
        }

        /// <summary>
        /// Save settings to registry
        /// </summary>
        internal void SaveSettings() {
            Bajotumn.registrySettings settings = new Bajotumn.registrySettings("P2P-ScreenViewer\\Senders\\" + Number);
            settings.saveSetting("Host", Host);
            settings.saveSetting("Port", PortString);
            settings.saveSetting("SendingEnabled", chkSendingEnabled.Checked);
        }
        #endregion

        #region Private
        /// <summary>
        /// Parses the text in txtHost into an IPAddress
        /// </summary>
        /// <returns>IPAddress containing the ip of the host entered</returns>
        private IPAddress parseIPAddress() {
            IPAddress rAddress = IPAddress.None;
            if (!IPAddress.TryParse(txtHost.Text, out rAddress)) {
                foreach (IPAddress ip in Dns.GetHostEntry(txtHost.Text).AddressList) {
                    if (ip.ToString().Contains(":")) { continue; }
                    rAddress = ip;
                }
            }
            return rAddress;
        }
        /// <summary>
        /// Set status text and color
        /// </summary>
        /// <param name="text">Text for status</param>
        public void SetStatus(string text) {
            SetStatus((Connected ? Color.Lime : Color.Red), text);
        }
        private void SetStatus(Color color, string text) {
            picStatus.BackColor = color;
            lblSenderStatus.Text = text;
        }

        /// <summary>
        /// Disable or enable certain items on the control
        /// </summary>
        /// <param name="p">Enabled value</param>
        private void DisableEnableItems(bool p) {
            txtHost.Enabled = p;
            txtPort.Enabled = p;
            btnControlSender.Enabled = p;
        }
        #endregion
        #endregion

        public override string ToString() {
            return base.ToString() + "  [" + Host + ":" + Port + "]";
        }
    }
}
