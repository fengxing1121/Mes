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
        void SaveCustomerFollowUp(Sender sender, SaveCustomerFollowUpArgs args);
        [OperationContract]
        CustomerFollowUp GetCustomerFollowUp(Sender sender, Guid FollowID);
        [OperationContract]
        List<CustomerFollowUp> GetCustomerFollowUps(Sender sender);
        [OperationContract]
        SearchResult SearchCustomerFollowUp(Sender sender, SearchCustomerFollowUpArgs args);
    }
}
