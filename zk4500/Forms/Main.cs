using System;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.ApiClient;

namespace zk4500.Forms
{
    public partial class Main : Form
    {
        private readonly IServiceManager serviceManager;
        private readonly IAuthApiClient authApiClient;

        private Timer exitTimer;


        public Main(IServiceManager ServiceManager, IAuthApiClient AuthApiClient)
        {
            serviceManager = ServiceManager;
            authApiClient = AuthApiClient;
            InitializeComponent();
            HandleApplicationLifetime();
        }


        private void Main_Load(object sender, EventArgs e)
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

        private void HandleApplicationLifetime()
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                DateTime targetTime = DateTime.Today.AddHours(18);
                TimeSpan timeRemaining;

                // If the current time is already past 4 am, calculate the time remaining for the next day
                if (DateTime.Now >= targetTime)
                {
                    targetTime = targetTime.AddDays(1);
                    timeRemaining = targetTime - DateTime.Now;
                }
                else
                {
                    timeRemaining = targetTime - DateTime.Now;
                }

                if (timeRemaining.TotalMilliseconds > 0)
                {
                    // Set up the timer with the remaining time
                    exitTimer = new Timer();
                    exitTimer.Interval = (int)timeRemaining.TotalMilliseconds;
                    exitTimer.Tick += ExitApplication;
                    exitTimer.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        private void ExitApplication(object sender, EventArgs e)
        {
            // Exit the application when the timer ticks
            Application.Exit();
        }


    }
}
