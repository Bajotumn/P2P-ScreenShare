namespace P2P_ScreenShare {
    partial class ReceiverControl {
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
            this.cboAddressSelection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnControlReceiver = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAddressSelection
            // 
            this.cboAddressSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboAddressSelection.FormattingEnabled = true;
            this.cboAddressSelection.Location = new System.Drawing.Point(61, 38);
            this.cboAddressSelection.Name = "cboAddressSelection";
            this.cboAddressSelection.Size = new System.Drawing.Size(297, 21);
            this.cboAddressSelection.TabIndex = 14;
            this.cboAddressSelection.Text = "<Address>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(364, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Port: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(400, 38);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(38, 20);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "42069";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboAddressSelection, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 61);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.btnControlReceiver);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(61, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 29);
            this.panel1.TabIndex = 0;
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Red;
            this.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStatus.Location = new System.Drawing.Point(139, 2);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(24, 24);
            this.picStatus.TabIndex = 14;
            this.picStatus.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(169, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "<Offline>";
            // 
            // btnControlReceiver
            // 
            this.btnControlReceiver.Location = new System.Drawing.Point(3, 3);
            this.btnControlReceiver.Name = "btnControlReceiver";
            this.btnControlReceiver.Size = new System.Drawing.Size(130, 23);
            this.btnControlReceiver.TabIndex = 12;
            this.btnControlReceiver.Text = "Start Listening";
            this.btnControlReceiver.UseVisualStyleBackColor = true;
            this.btnControlReceiver.Click += new System.EventHandler(this.btnControlReceiver_Click);
            // 
            // ReceiverControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReceiverControl";
            this.Size = new System.Drawing.Size(441, 61);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAddressSelection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnControlReceiver;
    }
}
