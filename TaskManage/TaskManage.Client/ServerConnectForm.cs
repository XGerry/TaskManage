using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskManage.Client
{
    public partial class ServerConnectForm : Form
    {
        public ServerConnectForm()
        {
            InitializeComponent();
            cboServer.DataSource = RegistryStore.GetLastConnections();
            cboServer.DisplayMember = "ServerName";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            Server = cboServer.Text;
            Port = int.Parse(txtPort.Text);
            Scheduler = txtScheduler.Text;
            RegistryStore.AddConnection(new ConnectionInfo { ServerName = Server, Port = Port, SchedulerName = Scheduler });
            this.Close();
        }

        public string Server { get; private set; }
        public int Port { get; private set; }
        public string Scheduler { get; private set; }
        public bool Cancelled { get; private set; }

        private void ServerConnectForm_Load(object sender, EventArgs e)
        {
            Cancelled = true;
        }

        private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
