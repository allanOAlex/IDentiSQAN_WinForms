using System;
using System.Threading;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.Shared.Requests;

namespace zk4500.Forms
{
    public partial class Home : Form
    {
        private readonly IServiceManager serviceManager;
        RegisterFingerPrintRequest registerFingerPrintRequest = new RegisterFingerPrintRequest();
        object obj;
        public Home(IServiceManager ServiceManager)
        {
            InitializeComponent();
            serviceManager = ServiceManager;
            //LoadPatients(new object(), new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisteredPatients registeredPatients = new RegisteredPatients(serviceManager);
            //registeredPatients.Show();

            Form1 form1 = new Form1(serviceManager, registerFingerPrintRequest);
            form1.Show();
        }

        private void LoadPatients(object sender, EventArgs e)
        {
            RegisteredPatients registeredPatients = new RegisteredPatients(serviceManager);
            registeredPatients.Show();
        }
    }
}
