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
        ReviewDetail GetReviewDetail(Sender sender, Guid TransID);

        [OperationContract]
        List<ReviewDetail> GetAllReviewDetails(Sender sender);

        [OperationContract]
        List<ReviewDetail> GetReviewDetailByTransID(Sender sender, Guid TransID);

        [OperationContract]
        void SaveReviewDetail(Sender sender, ReviewDetail obj);
    }
}

