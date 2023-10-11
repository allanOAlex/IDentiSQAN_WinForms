using System;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.Shared.Requests;

namespace zk4500
{
    public partial class SearchResultsUserControl : UserControl
    {
        private readonly IServiceManager serviceManager;
        RegisterFingerPrintRequest registerFingerPrintRequest = new RegisterFingerPrintRequest();
        public SearchResultsUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1(serviceManager, registerFingerPrintRequest);
            form1.Show();

        }
    }
}
