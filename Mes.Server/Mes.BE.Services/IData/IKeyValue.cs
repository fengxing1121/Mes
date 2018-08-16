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
    public partial interface IServiceBE
    {
        [OperationContract]
        string GetSystemTime();
        [OperationContract]
        KeyValue GetKeyValue(Sender sender, string key);
        [OperationContract]
        void SaveKeyValue(Sender sender, KeyValue kv);
        [OperationContract]
        int GetIncrease(Sender sender, string key);
        [OperationContract]
        List<KeyValue> GetKeyValues(Sender sender);
    }
}
