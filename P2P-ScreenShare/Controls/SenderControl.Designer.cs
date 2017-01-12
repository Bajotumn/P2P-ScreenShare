namespace P2P_ScreenShare {
    partial class SenderControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnControlSender = new System.Windows.Forms.Button();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblSenderStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.ttConnectionError = new System.Windows.Forms.ToolTip(this.components);
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.chkSendingEnabled = new System.Windows.Forms.CheckBox();
            this.lblPing = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Controls.Add(this.chkSendingEnabled, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtHost, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPing, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(376, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnControlSender);
            this.panel1.Controls.Add(this.picStatus);
            this.panel1.Controls.Add(this.lblSenderStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(47, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 29);
            this.panel1.TabIndex = 11;
            // 
            // btnControlSender
            // 
            this.btnControlSender.Location = new System.Drawing.Point(3, 3);
            this.btnControlSender.Name = "btnControlSender";
            this.btnControlSender.Size = new System.Drawing.Size(130, 23);
            this.btnControlSender.TabIndex = 8;
            this.btnControlSender.Text = "Connect";
            this.btnControlSender.UseVisualStyleBackColor = true;
            this.btnControlSender.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Red;
            this.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStatus.Location = new System.Drawing.Point(139, 2);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(24, 24);
            this.picStatus.TabIndex = 10;
            this.picStatus.TabStop = false;
            // 
            // lblSenderStatus
            // 
            this.lblSenderStatus.AutoSize = true;
            this.lblSenderStatus.Location = new System.Drawing.Point(169, 8);
            this.lblSenderStatus.Name = "lblSenderStatus";
            this.lblSenderStatus.Size = new System.Drawing.Size(73, 13);
            this.lblSenderStatus.TabIndex = 9;
            this.lblSenderStatus.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Host:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(335, 38);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(38, 20);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "0";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ttInfo.SetToolTip(this.txtPort, "Remote port to connect thought");
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(299, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHost
            // 
            this.txtHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHost.Location = new System.Drawing.Point(47, 38);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(246, 20);
            this.txtHost.TabIndex = 9;
            this.txtHost.Text = "127.0.0.1";
            this.ttInfo.SetToolTip(this.txtHost, "Remote host to connect to.\\nThis can be a hostname or an IP.\\nEx: example.com or " +
                    "123.123.123.123");
            this.txtHost.Enter += new System.EventHandler(this.txtHost_Enter);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumber.Location = new System.Drawing.Point(3, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(38, 35);
            this.lblNumber.TabIndex = 13;
            this.lblNumber.Text = "##";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ttConnectionError
            // 
            this.ttConnectionError.IsBalloon = true;
            this.ttConnectionError.ShowAlways = true;
            this.ttConnectionError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.ttConnectionError.ToolTipTitle = "Connection Error";
            // 
            // ttInfo
            // 
            this.ttInfo.IsBalloon = true;
            this.ttInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttInfo.ToolTipTitle = "Whats this?";
            // 
            // chkSendingEnabled
            // 
            this.chkSendingEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSendingEnabled.AutoSize = true;
            this.chkSendingEnabled.Checked = true;
            this.chkSendingEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendingEnabled.Location = new System.Drawing.Point(314, 3);
            this.chkSendingEnabled.Name = "chkSendingEnabled";
            this.chkSendingEnabled.Size = new System.Drawing.Size(15, 29);
            this.chkSendingEnabled.TabIndex = 15;
            this.chkSendingEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttInfo.SetToolTip(this.chkSendingEnabled, "Send images using this client");
            this.chkSendingEnabled.UseVisualStyleBackColor = true;
            // 
            // lblPing
            // 
            this.lblPing.AutoSize = true;
            this.lblPing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPing.Location = new System.Drawing.Point(335, 0);
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(38, 35);
            this.lblPing.TabIndex = 16;
            this.lblPing.Text = "Ping: ###";
            this.lblPing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SenderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SenderControl";
            this.Size = new System.Drawing.Size(376, 61);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnControlSender;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label lblSenderStatus;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.ToolTip ttConnectionError;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.CheckBox chkSendingEnabled;
        private System.Windows.Forms.Label lblPing;
    }
}
