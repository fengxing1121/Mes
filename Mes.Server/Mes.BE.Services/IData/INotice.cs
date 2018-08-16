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
        Notice GetNotice(Sender sender, Guid NoticeID);
        [OperationContract]
        void SaveNotice(Sender sender, SaveNoticeArgs args);
        [OperationContract]
        SearchResult SearchNotices(Sender sender, SearchNoticeArgs args);
    }
}
