using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P2P_ScreenShare {
    public partial class frmCaptureArea : Form {
        public Point ReferencePoint {
            get {
                return PointToScreen(ClientRectangle.Location);
            }
        }
        public frmCaptureArea() {
            InitializeComponent();
        }
    }
}
