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
        SolutionDetail GetSolutionDetail(Sender sender, Guid ItemID);
        [OperationContract]
        SolutionDetail GetSolutionDetailByBarcode(Sender sender, string Barcode);
        [OperationContract]
        SearchResult SearchSolutionDetail(Sender sender, SearchSolutionDetailArgs args);
        [OperationContract]
        void DeleteSolutionDetailByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        void DeleteSolutionDetailBySolutionID(Sender sender, Guid SolutionID);
        [OperationContract]
        void SaveSolutionDetail(Sender sender, SolutionDetail item);
        [OperationContract]
        SearchResult SearchSolutionQuoteDetail(Sender sender, Guid SolutonID);
        [OperationContract]
        SearchResult SearchSolutionQuoteHardwareDetail(Sender sender, Guid SolutonID);
    }
}
