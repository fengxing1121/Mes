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
        public void SaveRoomDesignerKJLRelation(Sender sender, SaveRoomDesignerKJLRelationArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    //string designID = args.RoomDesignerKJLRelation.KJLDesignID;
                    if (op.LoadRoomDesignerKJLRelatioByDesignID(args.RoomDesignerKJLRelation) == 0)
                    {
                        args.RoomDesignerKJLRelation.ID = Guid.NewGuid();
                        args.RoomDesignerKJLRelation.Status = false;
                        args.RoomDesignerKJLRelation.Created = DateTime.Now;
                        args.RoomDesignerKJLRelation.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertRoomDesignerKJLRelation(args.RoomDesignerKJLRelation);
                    }
                    //else
                    //{
                    //    args.RoomDesignerKJLRelation.KJLDesignID = designID;
                    //    op.UpdateRoomDesignerKJLRelationByDesignID(args.RoomDesignerKJLRelation);
                    //}
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool ExistsRoomDesignerKJLRelatioByDesignerNo(Sender sender, int designerNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.ExistsRoomDesignerKJLRelationByDesignerNo(designerNo);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public RoomDesignerKJLRelation LoadRoomDesignerKJLRelatioByDesignID(Sender sender, SaveRoomDesignerKJLRelationArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    RoomDesignerKJLRelation obj = new RoomDesignerKJLRelation();
                    obj.KJLDesignID = args.RoomDesignerKJLRelation.KJLDesignID;
                    obj.DesignerNo = args.RoomDesignerKJLRelation.DesignerNo;
                    if (op.LoadRoomDesignerKJLRelatioByDesignID(obj) == 0)
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
    }
}
