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
        void SaveProductWarehouse(Sender sender, SaveProductWarehouseArgs args);
        [OperationContract]
        ProductWarehouseMain GetProductWarehouse(Sender sender, Guid InID);
        [OperationContract]
        SearchResult SearchProductWarehouseMain(Sender sender, SearchProductWarehouseMainArgs args);
        [OperationContract]
        SearchResult SearchProductWarehouseDetail(Sender sender, SearchProductWarehouseDetailArgs args);
        [OperationContract]
        ProductMain GetProductMain(Sender sender, Guid ProductID);
        [OperationContract]
        ProductMain GetProductMainByProductCode(Sender sender, string ProductCode);
        [OperationContract]
        void SaveProduct(Sender sender, SaveProductArgs args);
        [OperationContract]
        bool IsProductBarcodeDuplicated(Sender sender, ProductDetail productDetail);
        [OperationContract]
        SearchResult SearchProduct(Sender sender, SearchProductArgs args);
        [OperationContract]
        ProductDetail GetProductDetail(Sender sender, Guid ItemID);
        [OperationContract]
        SearchResult SearchProductDetail(Sender sender, SearchProductDetailArgs args);
        [OperationContract]
        List<ProductProcessFile> GetProductProcessFilesByProductID(Sender sender, Guid ProductID);
        [OperationContract]
        ProductProcessFile GetProductProcessFile(Sender sender, Guid FileID);
        [OperationContract]
        void DeleteProduct(Sender sender, Guid ProductID);
        [OperationContract]
        SearchResult SearchProductHardware(Sender sender, SearchProduct2HardwareArgs args);
        [OperationContract]
        SearchResult SearchProductProcessFile(Sender sender, SearchProductProcessFileArgs args);
        [OperationContract]
        ProductDetail GetProductDetailByBarcode(Sender sender, string Barcode);
    }
}
