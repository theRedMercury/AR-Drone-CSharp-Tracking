using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace A.R.Drone.Main.UIClass
{
    partial class AboutARDrone : Form
    {

        public AboutARDrone()
        {
            InitializeComponent();
            this.Text = String.Format("About A.R. Drone ISIB");
            this.labInfo.Text = "A.R.Drone Control \nVersion 1.0.0  \nMasson Nicolas\nISIB 2014-2015\n"+
                "(The AR.Drone 2.0 controlling library for C#\n Ruslan-B/AR.Drone)";
        }

        #region Assembly Attribute Accessors
    
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
        }
    }
}
