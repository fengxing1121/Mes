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
        OrderProduct GetOrderProduct(Sender sender, Guid ProductID);

        [OperationContract]
        List<OrderProduct> GetAllOrderProducts(Sender sender);

        [OperationContract]
        List<OrderProduct> GetOrderProductByOrderID(Sender sender, Guid OrderID);

        [OperationContract]
        SearchResult SearchOrderProduct(Sender sender, SearchOrderProductArgs args);

        [OperationContract]
        void SaveOrderProduct(Sender sender, OrderProduct obj);
    }
}

