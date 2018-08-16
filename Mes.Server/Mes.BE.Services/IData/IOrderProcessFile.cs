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
        OrderProcessFile GetOrderProcessFile(Sender sender, Guid FileID);
        [OperationContract]
        OrderProcessFile GetOrderProcessFileByOrderID_FileType_FileName(Sender sender, Guid OrderID, string FileType, string Filename);
        [OperationContract]
        void SaveOrderProcessFile(Sender sender, SaveOrderProcessFileArgs args);
        [OperationContract]
        List<OrderProcessFile> GetOrderProcessFilesByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        List<OrderProcessFile> GetOrderProcessFilesByOrderID_FileType(Sender sender, Guid OrderID, string FileType);
        [OperationContract]
        SearchResult SearchOrderProcessFile(Sender sender, SearchOrderProcessFileArgs args);
        [OperationContract]
        void DeleteOrderProcessFileByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        void DeleteOrderProcessFileByOrderID(Sender sender, Guid OrderID);
    }
}
