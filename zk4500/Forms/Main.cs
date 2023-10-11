using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.ApiClient;

namespace zk4500.Forms
{
    public partial class Main : Form
    {
        private readonly IServiceManager serviceManager;
        private readonly IAuthApiClient authApiClient;


        public Main(IServiceManager ServiceManager, IAuthApiClient AuthApiClient)
        {
            serviceManager = ServiceManager;   
            authApiClient = AuthApiClient;
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItemMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(serviceManager, authApiClient);
            form1.Show();
            Enabled = false;
            Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void labelPoweredByMain_Click(object sender, EventArgs e)
        {

        }

        
    }
}
