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
        CustomerTransDetail GetCustomerTransDetail(Sender sender, Guid TransID);
        [OperationContract]
        SearchResult SearchCustomerTransDetail(Sender sender, SearchCustomerTransDetailArgs args);
        [OperationContract]
        List<CustomerTransDetail> GetCustomerTransDetailsByCustomerID(Sender sender, Guid CustomerID);
        [OperationContract]
        List<CustomerTransDetail> GetCustomerTransDetailsByQuoteID(Sender sender, Guid QuoteID);
        [OperationContract]
        void SaveCustomerTransDetail(Sender sender, SaveCustomerTransDetailArgs args);
        [OperationContract]
        void DeleteCustomerTransDetail(Sender sender, Guid TransID);

    }
}
