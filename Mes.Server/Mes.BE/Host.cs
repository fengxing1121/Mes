using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MES.Libraries;
using System.ServiceModel;
using Mes.BE.Services;

namespace Mes.BE
{
    internal static class Host
    {
        private static ServiceHost host;

        public static void Start()
        {
            try
            {
                PLogger.LogInformation("Host is starting...");
                if (host == null)
                {
                    host = new ServiceHost(typeof(ServiceBE));
                    host.Open();
                }
                PLogger.LogInformation("Host has started.");
            }
            catch (Exception ex)
            {
                try
                {
                    if (host != null)
                    {
                        host.Abort();
                    }
                }
                catch
                {
                }
                finally
                {
                    host = null;
                }
                PLogger.LogError(ex);
            }
        }

        public static void Stop()
        {
            try
            {
                PLogger.LogInformation("Host is stopping...");
                if (host != null)
                {
                    host.Close();
                }
                PLogger.LogInformation("Host has stopped.");
            }
            catch (Exception ex)
            {
                try
                {
                    if (host != null)
                    {
                        host.Abort();
                    }
                }
                catch
                {
                }
                PLogger.LogError(ex);
            }
            finally
            {
                host = null;
            }
        }
    }
}
