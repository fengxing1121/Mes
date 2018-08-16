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
    public partial class ServiceBE : IServiceBE
    {
        public ReviewDetail GetReviewDetail(Sender sender, Guid TransID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ReviewDetail obj = new ReviewDetail();
                    obj.TransID = TransID;
                    if (op.LoadReviewDetail(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ReviewDetail> GetAllReviewDetails(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadReviewDetails();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ReviewDetail> GetReviewDetailByTransID(Sender sender, Guid TransID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ReviewDetail obj = new ReviewDetail();
                    obj.TransID = TransID;
                    return op.LoadReviewDetailByTransID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveReviewDetail(Sender sender, ReviewDetail obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadReviewDetail(obj) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertReviewDetail(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateReviewDetailByTransID(obj);
                    }
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}

