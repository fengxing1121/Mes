using Mes.BE.Objects;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mes.BE.Services
{
    public partial class ServiceBE : IServiceBE
    {
        public string GetSystemTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }
        public KeyValue GetKeyValue(Sender sender, string key)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    KeyValue kv = new KeyValue();
                    kv.Key = key;
                    if (op.LoadKeyValueByKey(kv) == 0)
                    {
                        return null;
                    }
                    return kv;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveKeyValue(Sender sender, KeyValue kv)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    KeyValue tmp = new KeyValue();
                    tmp.Key = kv.Key;
                    if (op.LoadKeyValueByKey(tmp) == 0)
                    {
                        tmp = null;
                    }
                    if (tmp == null)
                    {
                        op.InsertKeyValue(kv);
                    }
                    else
                    {
                        op.UpdateKeyValueByKey(kv);
                    }
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public int GetIncrease(Sender sender, string key)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    KeyValue kv = new KeyValue();

                    kv.Key = key;
                    if (op.LoadKeyValueByKey(kv) == 0)
                    {
                        kv = null;
                    }

                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = key;
                        kv.Value = "1";
                        op.InsertKeyValue(kv);
                    }
                    else
                    {
                        kv.Key = key;
                        kv.Value = Convert.ToString(int.Parse(kv.Value) + 1);
                        op.UpdateKeyValueByKey(kv);
                    }
                    op.CommitTransaction();
                    return int.Parse(kv.Value);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<KeyValue> GetKeyValues(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadKeyValues();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
