using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace HostingInWindowServices
{
    public partial class CyberCenterWindowsService : ServiceBase
    {
        private ServiceHost MyHost;
        public CyberCenterWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MyHost = new ServiceHost(typeof(CyberCenter.ClientServices));
            MyHost.Open();
        }

        protected override void OnStop()
        {
            MyHost.Close();
        }
    }
}
