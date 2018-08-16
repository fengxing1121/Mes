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
        public Notice GetNotice(Sender sender, Guid NoticeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Notice obj = new Notice();
                    obj.NoticeID = NoticeID;

                    if (op.LoadNoticeByNoticeID(obj) == 0)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveNotice(Sender sender, SaveNoticeArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Notice obj = new Notice();
                    obj.NoticeID = args.Notice.NoticeID;
                    if (op.LoadNoticeByNoticeID(obj) == 0)
                    {
                        args.Notice.Created = DateTime.Now;
                        args.Notice.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertNotice(args.Notice);
                    }
                    else
                    {
                        op.UpdateNoticeByNoticeID(args.Notice);
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
        public SearchResult SearchNotices(Sender sender, SearchNoticeArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchNotices(args);
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
