using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using P2P_ScreenShare.Communications;

namespace P2P_ScreenShare {
    public partial class ReceiverControl : UserControl {
        /// <summary>
        /// Instance of Receiver used to listen on a specific port and address
        /// </summary>
        public Receiver commDataReceiver = null;

        #region Private Vars
        private int _port = 0;
        #endregion

        #region Public Accessors

        /// <summary>
        /// String containing the currently selected host, defined by cboAddressSelection
        /// </summary>
        public string Host {
            get { return cboAddressSelection.Text; }
            set { cboAddressSelection.Text = value; }
        }

        /// <summary>
        /// String value of txtPort
        /// </summary>
        public string PortString {
            get { return txtPort.Text; }
            set { txtPort.Text = value; }
        }

        //int value of the port currently defined by txtPort
        public int Port {
            get { return _port; }
            set {
                _port = value;
                txtPort.Text = value.ToString();
            }
        }

        /// <summary>
        /// True if the receiver is listening. False if it is not or it is null
        /// </summary>
        public bool Listening {
            get {
                if (commDataReceiver == null) {
                    return false;
                }
                return commDataReceiver.Listening;
            }
        }

        /// <summary>
        /// Hashtable of the image receiver forms, using the IPEndPoint of the
        /// client it receives from as the key
        /// </summary>
        public Hashtable imageReceivers = new Hashtable();

        #endregion

        public ReceiverControl() {
            InitializeComponent();
            commDataReceiver = null;
            BuildNetworkInterfaceAddressList();
        }

        #region Functions
        #region Internal
        /// <summary>
        /// Load settings from registry
        /// </summary>
        internal void LoadSettings() {
            Bajotumn.registrySettings settings = new Bajotumn.registrySettings("P2P-ScreenViewer\\Receiver");
            txtPort.Text = settings.loadSetting("Port", "42069").ToString();
            cboAddressSelection.Text = settings.loadSetting("Host", cboAddressSelection.Items[0]).ToString();
        }
        /// <summary>
        /// Save settings to registry
        /// </summary>
        internal void SaveSettings() {
            Bajotumn.registrySettings settings = new Bajotumn.registrySettings("P2P-ScreenViewer\\Receiver");
            settings.saveSetting("Host", cboAddressSelection.Text);
            settings.saveSetting("Port", txtPort.Text);
        } 
        #endregion

        #region Private
        /// <summary>
        /// Build list of local network interface addresses and add them to cboAddressSelection
        /// </summary>
        private void BuildNetworkInterfaceAddressList() {
            IPHostEntry LocalHE;
            LocalHE = Dns.GetHostEntry(Dns.GetHostName());
            cboAddressSelection.Items.Clear();
            foreach (IPAddress ip in LocalHE.AddressList) {
                if (ip.ToString().Contains(":")) { continue; }
                cboAddressSelection.Items.Add(ip);
            }
            cboAddressSelection.SelectedIndex = 0;

        }
        /// <summary>
        /// Disable or enable certain items on the control
        /// </summary>
        /// <param name="p">Enabled value</param>
        private void DisableEnableItems(bool p) {
            cboAddressSelection.Enabled = p;
            txtPort.Enabled = p;
        }
        /// <summary>
        /// Set status text and color
        /// </summary>
        /// <param name="text">Text for status</param>
        private void SetStatus(string text) {
            picStatus.BackColor = (Listening ? Color.Lime : Color.Red);
            lblStatus.Text = text;
        }  
        #endregion
        #endregion

        #region Events
        private void btnControlReceiver_Click(object sender, EventArgs e) {
            if (!Listening) {
                commDataReceiver = new Receiver(cboAddressSelection.Text, txtPort.Text);
                commDataReceiver.ImageReceived += new Receiver.ImageReceivedHandler(commDataReceiver_ImageReceived);
                commDataReceiver.ClientDisconnected += new Receiver.ClientEventHandler(commDataReceiver_ClientDisconnected);
                commDataReceiver.ClientConnected += new Receiver.ClientEventHandler(commDataReceiver_ClientConnected);
                commDataReceiver.Start();
                SetStatus("Listening");
                btnControlReceiver.Text = "Stop Listening";

            } else {
                commDataReceiver.Stop();
                SetStatus("<Offline>");
                btnControlReceiver.Text = "Start Listening";
            }
            DisableEnableItems(!Listening);
        }
        private void commDataReceiver_ImageReceived(IPEndPoint dSource, Image dImageReceived) {
            if (this.InvokeRequired) {
                this.Invoke(new Receiver.ImageReceivedHandler(commDataReceiver_ImageReceived), dSource, dImageReceived);
                return;
            }
            ((frmImageReceiver)imageReceivers[dSource]).SetImage(dImageReceived);
        }
        private void commDataReceiver_ClientConnected(IPEndPoint dSource) {
            if (this.InvokeRequired) {
                this.Invoke(new Receiver.ClientEventHandler(commDataReceiver_ClientConnected), dSource);
                return;
            }
            frmImageReceiver frm = new frmImageReceiver(dSource);
            frm.Connected();
            imageReceivers.Add(dSource, frm);
        }
        private void commDataReceiver_ClientDisconnected(IPEndPoint dSource) {
            if (this.InvokeRequired) {
                this.Invoke(new Receiver.ClientEventHandler(commDataReceiver_ClientDisconnected), dSource);
                return;
            }
            ((frmImageReceiver)imageReceivers[dSource]).Disconnected();
        }
        #endregion
    }
}
