using Mes.Client.Service.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Service
{
    public class ProxyBE : IDisposable
    {
        public ProxyBE()
        {
            try
            {
                this.Client = new ServiceBEClient();

                this.Client.Open();
            }
            catch (Exception ex)
            {
                if (ex is System.ServiceModel.EndpointNotFoundException)
                {
                    throw new Exception("检查到MES后台服务BE未启动，请联系系统管理员。");
                }
                else if (ex is System.InvalidOperationException)
                {
                    throw new Exception("系统配置有误。" + ex.Message);
                }
                else
                {
                    throw new Exception("系统发生未知的错误:" + ex.Message);
                }
            }
        }
        public ServiceBEClient Client { get; set; }

        public void Dispose()
        {
            try
            {
                if (this.Client != null)
                {
                    this.Client.Close();
                }
            }
            catch
            {
                try
                {
                    if (this.Client != null)
                    {
                        this.Client.Abort();
                    }
                }
                catch
                {
                }
            }
        }
    }
}
