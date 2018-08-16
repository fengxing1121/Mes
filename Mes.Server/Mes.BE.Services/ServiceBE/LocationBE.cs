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
        public Location GetLocation(Sender sender, Guid LocationID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Location obj = new Location();
                    obj.LocationID = LocationID;
                    if (op.LoadLocationByLocationID(obj) == 0)
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
        public void SaveLocation(Sender sender, SaveLocationArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Location obj = new Location();
                    obj.LocationID = args.Location.LocationID;
                    if (op.LoadLocationByLocationID(obj) == 0)
                    {
                        args.Location.Created = DateTime.Now;
                        args.Location.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.Location.Modified = DateTime.Now;
                        args.Location.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertLocation(args.Location);
                    }
                    else
                    {
                        args.Location.Modified = DateTime.Now;
                        args.Location.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateLocationByLocationID(args.Location);
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
        public SearchResult SearchLocation(Sender sender, SearchLocationArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchLoction(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchWarehouse(Sender sender, SearchWarehouseArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWarehouse(args);
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
