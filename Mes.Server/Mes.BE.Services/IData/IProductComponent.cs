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
        ProductComponent GetProductComponent(Sender sender, Int32 ComponentID);

        [OperationContract]
        List<ProductComponent> GetAllProductComponents(Sender sender);

        [OperationContract]
        List<ProductComponent> GetProductComponentByComponentID(Sender sender, Int32 ComponentID);

        [OperationContract]
        SearchResult SearchProductComponent(Sender sender, SearchProductComponentArgs args);

        [OperationContract]
        void SaveProductComponent(Sender sender, ProductComponent obj);

        [OperationContract]
        void SaveProductComponents(Sender sender, SaveProductComponentArgs args);

        [OperationContract]
        List<ProductComponent> GetProductComponentByOrderID(Sender sender, Guid OrderID);

        [OperationContract]
        List<ProductComponent> GetProductComponentByProductCode(Sender sender, string productCode);

        [OperationContract]
        ProductComponent GetProductComponentByComponentTypeID(Sender sender, int ComponentID, string ProductCode);
    }
}

