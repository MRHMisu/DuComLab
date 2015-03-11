using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace HostingClientServices
{
    public partial class HostingClientServicesView : Form
    {
        private ServiceHost MyHost;
        public HostingClientServicesView()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            MyHost = new ServiceHost(typeof(CyberCenter.ClientServices));
            MyHost.Open();
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            labelStatus.Text = "Services Starting";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            MyHost.Close();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            labelStatus.Text = "Services Stoping";
        }
    }
}
