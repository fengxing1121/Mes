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
        public void SaveRoomDesigner(Sender sender, SaveRoomDesignerArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    RoomDesigner obj = new RoomDesigner();
                    obj.DesignerID = args.RoomDesigner.DesignerID;
                    if (op.LoadRoomDesignerByDesignerID(obj) == 0)
                    {
                        args.RoomDesigner.Created = DateTime.Now;
                        args.RoomDesigner.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.RoomDesigner.Modified = DateTime.Now;
                        args.RoomDesigner.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertRoomDesigner(args.RoomDesigner);
                    }
                    else
                    {
                        args.RoomDesigner.Modified = DateTime.Now;
                        args.RoomDesigner.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateRoomDesignerByDesignerID(args.RoomDesigner);
                    }

                    if (args.RoomDesignerFiles != null)
                    {
                        foreach (RoomDesignerFile file in args.RoomDesignerFiles)
                        {
                            RoomDesignerFile temp = new RoomDesignerFile();
                            temp.FileID = file.FileID;
                            if (op.LoadRoomDesignerFileByFileID(temp) == 0)
                            {
                                file.Created = DateTime.Now;
                                file.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                file.Modified = DateTime.Now;
                                file.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.InsertRoomDesignerFile(file);
                            }
                            else
                            {
                                file.Modified = DateTime.Now;
                                file.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.UpdateRoomDesignerFileByFileID(file);
                            }
                        }
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
        public RoomDesigner GetRoomDesigner(Sender sender, Guid DesignerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    RoomDesigner obj = new RoomDesigner();
                    obj.DesignerID = DesignerID;
                    if (op.LoadRoomDesignerByDesignerID(obj) == 0)
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
        public bool ExistsRoomDesignersByDesignerNo(Sender sender, int designerNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.ExistsRoomDesignersByDesignerNo(designerNo);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<RoomDesigner> GetRoomDesigners(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadRoomDesigners();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchRoomDesigner(Sender sender, SearchRoomDesignerArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchRoomDesigner(args);
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
