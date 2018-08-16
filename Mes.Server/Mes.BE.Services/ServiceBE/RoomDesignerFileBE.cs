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
        //量尺文件
        public void SaveRoomDesignerFile(Sender sender, SaveRoomDesignerFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    RoomDesignerFile obj = new RoomDesignerFile();
                    obj.FileID = args.RoomDesignerFile.FileID;
                    if (op.LoadRoomDesignerFileByFileID(obj) == 0)
                    {
                        args.RoomDesignerFile.Created = DateTime.Now;
                        args.RoomDesignerFile.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.RoomDesignerFile.Modified = DateTime.Now;
                        args.RoomDesignerFile.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertRoomDesignerFile(args.RoomDesignerFile);
                    }
                    else
                    {
                        args.RoomDesignerFile.Modified = DateTime.Now;
                        args.RoomDesignerFile.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateRoomDesignerFileByFileID(args.RoomDesignerFile);
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
        public RoomDesignerFile GetRoomDesignerFile(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    RoomDesignerFile obj = new RoomDesignerFile();
                    obj.FileID = FileID;
                    if (op.LoadRoomDesignerFileByFileID(obj) == 0)
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
        public List<RoomDesignerFile> GetRoomDesignerFilesByDesignerID(Sender sender, Guid DesignerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadRoomDesignerFilesByDesignerID(DesignerID);
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
