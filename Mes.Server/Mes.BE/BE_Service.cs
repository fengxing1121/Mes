using System.ServiceProcess;
using MES.Libraries;
using System.IO;

namespace Mes.BE
{
    public partial class BE_Service : ServiceBase
    {
        public BE_Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            PLogger.Listeners.Clear();
            PLogger.Listeners.Add(new PTraceListener("BE", Path.Combine(Config.WorkingFolder, "Log\\BE")));

            Host.Start();
        }

        protected override void OnStop()
        {
            Host.Stop();
        }
    }
}
