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
        ProductBOM GetProductBOM(Sender sender, Int32 ID);

        [OperationContract]
        List<ProductBOM> GetAllProductBOMs(Sender sender);

        [OperationContract]
        List<ProductBOM> GetProductBOMByID(Sender sender, Int32 ID);

        [OperationContract]
        SearchResult SearchProductBOM(Sender sender, SearchProductBOMArgs args);

        [OperationContract]
        void SaveProductBOM(Sender sender, ProductBOM obj);

        [OperationContract]
        void SaveProductBOMs(Sender sender, SaveProductBOMArgs args);
    }
}