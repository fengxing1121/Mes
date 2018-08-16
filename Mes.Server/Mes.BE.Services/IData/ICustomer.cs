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
        void SaveCustomer(Sender sender, SaveCustomerArgs args);
        [OperationContract]
        Customer GetCustomer(Sender sender, Guid CustomerID);
        [OperationContract]
        List<Customer> GetCustomers(Sender sender);
        [OperationContract]
        SearchResult SearchCustomer(Sender sender, SearchCustomerArgs args);
    }
}
