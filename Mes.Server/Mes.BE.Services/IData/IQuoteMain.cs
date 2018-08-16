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
        QuoteMain GetQuoteMain(Sender sender, Guid QuoteID);
        [OperationContract]
        QuoteMain GetQuoteMainBySolutionID(Sender sender, Guid SolutionID);
        [OperationContract]
        QuoteMain GetQuoteMainByQuoteNo(Sender sender, string QuoteNo);
        [OperationContract]
        void SaveQuote(Sender sender, SaveQuoteMainArgs args);
        [OperationContract]
        SearchResult SearchQuote(Sender sender, SearchQuoteMainArgs args);
        [OperationContract]
        QuoteDetail GetQuoteDetail(Sender sender, Guid DetailID);
        [OperationContract]
        SearchResult SearchQuoteDetail(Sender sender, SearchQuoteDetailArgs args);
        [OperationContract]
        void DeleteQuote(Sender sender, Guid QuoteID);
    }
}
