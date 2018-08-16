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
        public Cabinet2Door GetCabinet2Door(Sender sender, Guid DoorID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Cabinet2Door obj = new Cabinet2Door();
                    obj.DoorID = DoorID;
                    if (op.LoadCabinet2DoorByDoorID(obj) == 0)
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
        public List<Cabinet2Door> GetCabinet2DoorByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCabinet2DoorsByCabinetID(CabinetID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveCabinet2Door(Sender sender, SaveCabinet2DoorArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Cabinet2Door obj = new Cabinet2Door();
                    obj.DoorID = args.Cabinet2Door.DoorID;
                    if (op.LoadCabinet2DoorByDoorID(obj) == 0)
                    {
                        args.Cabinet2Door.Created = DateTime.Now;
                        args.Cabinet2Door.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Cabinet2Door.Modified = DateTime.Now;
                        args.Cabinet2Door.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertCabinet2Door(args.Cabinet2Door);
                    }
                    else
                    {
                        args.Cabinet2Door.Modified = DateTime.Now;
                        args.Cabinet2Door.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateCabinet2DoorByDoorID(args.Cabinet2Door);
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
        public void DeleteCabinet2Door(Sender sender, Guid DoorID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteCabinet2DoorByDoorID(DoorID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchCabinet2Door(Sender sender, SearchCabinet2DoorArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCabinet2Door(args);
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
