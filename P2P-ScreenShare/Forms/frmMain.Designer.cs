namespace P2P_ScreenShare {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.conReceiver = new P2P_ScreenShare.ReceiverControl();
            this.grpSender = new System.Windows.Forms.GroupBox();
            this.tblSenders = new System.Windows.Forms.TableLayoutPanel();
            this.sender4 = new P2P_ScreenShare.SenderControl();
            this.sender3 = new P2P_ScreenShare.SenderControl();
            this.sender2 = new P2P_ScreenShare.SenderControl();
            this.sender1 = new P2P_ScreenShare.SenderControl();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabReceiver = new System.Windows.Forms.TabPage();
            this.tabSender = new System.Windows.Forms.TabPage();
            this.Options = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpViewport = new System.Windows.Forms.GroupBox();
            this.picViewport = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTimerResolution = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkViewCaptureAreaForm = new System.Windows.Forms.CheckBox();
            this.btnStartStopCapturingImages = new System.Windows.Forms.Button();
            this.grpReceiver.SuspendLayout();
            this.grpSender.SuspendLayout();
            this.tblSenders.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabReceiver.SuspendLayout();
            this.tabSender.SuspendLayout();
            this.Options.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpViewport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewport)).BeginInit();
            this.SuspendLayout();
            // 
            // grpReceiver
            // 
            this.grpReceiver.Controls.Add(this.conReceiver);
            this.grpReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceiver.Location = new System.Drawing.Point(3, 3);
            this.grpReceiver.Name = "grpReceiver";
            this.grpReceiver.Size = new System.Drawing.Size(384, 297);
            this.grpReceiver.TabIndex = 5;
            this.grpReceiver.TabStop = false;
            this.grpReceiver.Text = "Receiver";
            // 
            // conReceiver
            // 
            this.conReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conReceiver.Host = "192.168.1.101";
            this.conReceiver.Location = new System.Drawing.Point(3, 19);
            this.conReceiver.Name = "conReceiver";
            this.conReceiver.Port = 0;
            this.conReceiver.PortString = "42069";
            this.conReceiver.Size = new System.Drawing.Size(375, 61);
            this.conReceiver.TabIndex = 8;
            // 
            // grpSender
            // 
            this.grpSender.Controls.Add(this.tblSenders);
            this.grpSender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSender.Location = new System.Drawing.Point(3, 3);
            this.grpSender.Name = "grpSender";
            this.grpSender.Size = new System.Drawing.Size(419, 297);
            this.grpSender.TabIndex = 4;
            this.grpSender.TabStop = false;
            this.grpSender.Text = "Sender";
            // 
            // tblSenders
            // 
            this.tblSenders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSenders.ColumnCount = 1;
            this.tblSenders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSenders.Controls.Add(this.sender4, 0, 3);
            this.tblSenders.Controls.Add(this.sender3, 0, 2);
            this.tblSenders.Controls.Add(this.sender2, 0, 1);
            this.tblSenders.Controls.Add(this.sender1, 0, 0);
            this.tblSenders.Location = new System.Drawing.Point(6, 25);
            this.tblSenders.Name = "tblSenders";
            this.tblSenders.RowCount = 4;
            this.tblSenders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tblSenders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tblSenders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tblSenders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tblSenders.Size = new System.Drawing.Size(407, 266);
            this.tblSenders.TabIndex = 8;
            // 
            // sender4
            // 
            this.sender4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sender4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sender4.Host = "127.0.0.1";
            this.sender4.Location = new System.Drawing.Point(3, 202);
            this.sender4.Name = "sender4";
            this.sender4.Number = 4;
            this.sender4.Port = 0;
            this.sender4.PortString = "0";
            this.sender4.SendingEnabled = true;
            this.sender4.Size = new System.Drawing.Size(401, 61);
            this.sender4.TabIndex = 11;
            this.sender4.ConnectionError += new P2P_ScreenShare.SenderControl.SenderControlConnectionErrorHandler(this.sender_ConnectionError);
            // 
            // sender3
            // 
            this.sender3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sender3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sender3.Host = "127.0.0.1";
            this.sender3.Location = new System.Drawing.Point(3, 135);
            this.sender3.Name = "sender3";
            this.sender3.Number = 3;
            this.sender3.Port = 0;
            this.sender3.PortString = "0";
            this.sender3.SendingEnabled = true;
            this.sender3.Size = new System.Drawing.Size(401, 61);
            this.sender3.TabIndex = 10;
            this.sender3.ConnectionError += new P2P_ScreenShare.SenderControl.SenderControlConnectionErrorHandler(this.sender_ConnectionError);
            // 
            // sender2
            // 
            this.sender2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sender2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sender2.Host = "127.0.0.1";
            this.sender2.Location = new System.Drawing.Point(3, 69);
            this.sender2.Name = "sender2";
            this.sender2.Number = 2;
            this.sender2.Port = 0;
            this.sender2.PortString = "0";
            this.sender2.SendingEnabled = true;
            this.sender2.Size = new System.Drawing.Size(401, 60);
            this.sender2.TabIndex = 9;
            this.sender2.ConnectionError += new P2P_ScreenShare.SenderControl.SenderControlConnectionErrorHandler(this.sender_ConnectionError);
            // 
            // sender1
            // 
            this.sender1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sender1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sender1.Host = "127.0.0.1";
            this.sender1.Location = new System.Drawing.Point(3, 3);
            this.sender1.Name = "sender1";
            this.sender1.Number = 1;
            this.sender1.Port = 0;
            this.sender1.PortString = "0";
            this.sender1.SendingEnabled = true;
            this.sender1.Size = new System.Drawing.Size(401, 60);
            this.sender1.TabIndex = 8;
            this.sender1.ConnectionError += new P2P_ScreenShare.SenderControl.SenderControlConnectionErrorHandler(this.sender_ConnectionError);
            // 
            // tabsMain
            // 
            this.tabsMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsMain.Controls.Add(this.tabReceiver);
            this.tabsMain.Controls.Add(this.tabSender);
            this.tabsMain.Controls.Add(this.Options);
            this.tabsMain.Location = new System.Drawing.Point(12, 12);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(433, 329);
            this.tabsMain.TabIndex = 6;
            // 
            // tabReceiver
            // 
            this.tabReceiver.Controls.Add(this.grpReceiver);
            this.tabReceiver.Location = new System.Drawing.Point(4, 22);
            this.tabReceiver.Name = "tabReceiver";
            this.tabReceiver.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceiver.Size = new System.Drawing.Size(390, 303);
            this.tabReceiver.TabIndex = 0;
            this.tabReceiver.Text = "Receiver";
            this.tabReceiver.UseVisualStyleBackColor = true;
            // 
            // tabSender
            // 
            this.tabSender.Controls.Add(this.grpSender);
            this.tabSender.Location = new System.Drawing.Point(4, 22);
            this.tabSender.Name = "tabSender";
            this.tabSender.Padding = new System.Windows.Forms.Padding(3);
            this.tabSender.Size = new System.Drawing.Size(425, 303);
            this.tabSender.TabIndex = 1;
            this.tabSender.Text = "Sender";
            this.tabSender.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.Options.Controls.Add(this.groupBox1);
            this.Options.Location = new System.Drawing.Point(4, 22);
            this.Options.Name = "Options";
            this.Options.Padding = new System.Windows.Forms.Padding(3);
            this.Options.Size = new System.Drawing.Size(390, 303);
            this.Options.TabIndex = 2;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpViewport);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboTimerResolution);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkViewCaptureAreaForm);
            this.groupBox1.Controls.Add(this.btnStartStopCapturingImages);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 297);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options && Viewport";
            // 
            // grpViewport
            // 
            this.grpViewport.Controls.Add(this.picViewport);
            this.grpViewport.Location = new System.Drawing.Point(166, 48);
            this.grpViewport.Name = "grpViewport";
            this.grpViewport.Size = new System.Drawing.Size(212, 226);
            this.grpViewport.TabIndex = 14;
            this.grpViewport.TabStop = false;
            this.grpViewport.Text = "Viewport";
            // 
            // picViewport
            // 
            this.picViewport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picViewport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picViewport.Location = new System.Drawing.Point(6, 19);
            this.picViewport.Name = "picViewport";
            this.picViewport.Size = new System.Drawing.Size(200, 200);
            this.picViewport.TabIndex = 0;
            this.picViewport.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "seconds";
            // 
            // cboTimerResolution
            // 
            this.cboTimerResolution.FormatString = "0.0";
            this.cboTimerResolution.FormattingEnabled = true;
            this.cboTimerResolution.Location = new System.Drawing.Point(281, 21);
            this.cboTimerResolution.Name = "cboTimerResolution";
            this.cboTimerResolution.Size = new System.Drawing.Size(42, 21);
            this.cboTimerResolution.TabIndex = 12;
            this.cboTimerResolution.Text = "5.0";
            this.cboTimerResolution.TextChanged += new System.EventHandler(this.cboTimerResolution_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Timer Resolution: ";
            // 
            // chkViewCaptureAreaForm
            // 
            this.chkViewCaptureAreaForm.AutoSize = true;
            this.chkViewCaptureAreaForm.Checked = true;
            this.chkViewCaptureAreaForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewCaptureAreaForm.Location = new System.Drawing.Point(6, 48);
            this.chkViewCaptureAreaForm.Name = "chkViewCaptureAreaForm";
            this.chkViewCaptureAreaForm.Size = new System.Drawing.Size(114, 17);
            this.chkViewCaptureAreaForm.TabIndex = 3;
            this.chkViewCaptureAreaForm.Text = "View Capture Area";
            this.chkViewCaptureAreaForm.UseVisualStyleBackColor = true;
            this.chkViewCaptureAreaForm.CheckedChanged += new System.EventHandler(this.chkViewCaptureAreaForm_CheckedChanged);
            // 
            // btnStartStopCapturingImages
            // 
            this.btnStartStopCapturingImages.Location = new System.Drawing.Point(6, 19);
            this.btnStartStopCapturingImages.Name = "btnStartStopCapturingImages";
            this.btnStartStopCapturingImages.Size = new System.Drawing.Size(160, 23);
            this.btnStartStopCapturingImages.TabIndex = 0;
            this.btnStartStopCapturingImages.Text = "Start Sending Images";
            this.btnStartStopCapturingImages.UseVisualStyleBackColor = true;
            this.btnStartStopCapturingImages.Click += new System.EventHandler(this.btnStartStopCapturingImages_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 353);
            this.Controls.Add(this.tabsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "P2P Screen Share";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.grpReceiver.ResumeLayout(false);
            this.grpSender.ResumeLayout(false);
            this.tblSenders.ResumeLayout(false);
            this.tabsMain.ResumeLayout(false);
            this.tabReceiver.ResumeLayout(false);
            this.tabSender.ResumeLayout(false);
            this.Options.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpViewport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picViewport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReceiver;
        private System.Windows.Forms.GroupBox grpSender;
        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabReceiver;
        private System.Windows.Forms.TabPage tabSender;
        private System.Windows.Forms.TabPage Options;
        private System.Windows.Forms.TableLayoutPanel tblSenders;
        private SenderControl sender4;
        private SenderControl sender3;
        private SenderControl sender2;
        private SenderControl sender1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTimerResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkViewCaptureAreaForm;
        private System.Windows.Forms.Button btnStartStopCapturingImages;
        private ReceiverControl conReceiver;
        private System.Windows.Forms.GroupBox grpViewport;
        private System.Windows.Forms.PictureBox picViewport;
    }
}

