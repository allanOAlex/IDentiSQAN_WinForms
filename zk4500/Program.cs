using System;
using System.Windows.Forms;
using Unity;
using Unity.Resolution;
using zk4500.Extensions;
using zk4500.Forms;
using zk4500.Shared.Requests;

namespace zk4500
{
    static class Program
    {

        public static IServiceProvider serviceProvider { get; set; }

        private static void ConfigureContainer()
        {
            
        }


        [STAThread]
        [Obsolete]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IUnityContainer container = UnityConfig.RegisterComponents();

            // Resolve the Form1 instance with dependencies
            var registerFingerPrintRequest = new RegisterFingerPrintRequest();
            var form1 = container.Resolve<Form1>(new DependencyOverride<RegisterFingerPrintRequest>(registerFingerPrintRequest));

            Login form = container.Resolve<Login>();
            Main main = container.Resolve<Main>();

            Application.Run(main);


        }
    }
}
