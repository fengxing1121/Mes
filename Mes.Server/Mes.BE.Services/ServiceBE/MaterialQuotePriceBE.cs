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
        public MaterialQuotePrice GetMaterialQuotePrice(Sender sender, Guid MaterialID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    MaterialQuotePrice obj = new MaterialQuotePrice();
                    obj.MaterialID = MaterialID;
                    if (op.LoadMaterialQuotePriceByMaterialID(obj) == 0)
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
        public void SaveMaterialQuotePrice(Sender sender, SaveMaterialQuotePriceArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    MaterialQuotePrice obj = new MaterialQuotePrice();
                    obj.MaterialID = args.MaterialQuotePrice.MaterialID;
                    if (op.LoadMaterialQuotePriceByMaterialID(obj) == 0)
                    {
                        op.InsertMaterialQuotePrice(args.MaterialQuotePrice);
                    }
                    else
                    {
                        op.UpdateMaterialQuotePriceByMaterialID(args.MaterialQuotePrice);
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
        public void DeleteMaterialQuotePrice(Sender sender, Guid MaterialID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteMaterialQuotePriceByMaterialID(MaterialID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchMaterialQuotePrice(Sender sender, SearchMaterialQuotePriceArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchMaterialQuotePrice(args);
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
