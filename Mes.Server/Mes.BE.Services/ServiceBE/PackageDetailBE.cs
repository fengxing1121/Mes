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
        public SearchResult SearchPackageDetail(Sender sender, SearchPackageDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPackageDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public PackageDetail GetPackageDetail(Sender sender, Guid DetailID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PackageDetail obj = new PackageDetail();
                    obj.DetailID = DetailID;
                    if (op.LoadPackageDetailByDetailID(obj) == 0)
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
        public List<PackageDetail> GetPackageDetailsByItemID(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPackageDetailsByItemID(ItemID);
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
