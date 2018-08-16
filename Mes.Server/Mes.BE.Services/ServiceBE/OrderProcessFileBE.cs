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
        public OrderProcessFile GetOrderProcessFile(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderProcessFile obj = new OrderProcessFile();
                    obj.FileID = FileID;
                    if (op.LoadOrderProcessFileByFileID(obj) == 0)
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
        public OrderProcessFile GetOrderProcessFileByOrderID_FileType_FileName(Sender sender, Guid OrderID, string FileType, string Filename)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderProcessFile obj = new OrderProcessFile();
                    obj.FileName = Filename;
                    obj.FileType = FileType;
                    obj.OrderID = OrderID;
                    if (op.LoadOrderProcessFileByFileType_OrderID_FileName(obj) == 0)
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
        public void SaveOrderProcessFile(Sender sender, SaveOrderProcessFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {

                    OrderProcessFile obj = new OrderProcessFile();
                    obj.FileID = args.OrderProcessFile.FileID;
                    if (op.LoadOrderProcessFileByFileID(obj) == 0)
                    {
                        args.OrderProcessFile.Created = DateTime.Now;
                        args.OrderProcessFile.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.OrderProcessFile.Modified = DateTime.Now;
                        args.OrderProcessFile.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertOrderProcessFile(args.OrderProcessFile);
                    }
                    else
                    {
                        args.OrderProcessFile.Modified = DateTime.Now;
                        args.OrderProcessFile.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateOrderProcessFileByFileID(args.OrderProcessFile);
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
        public List<OrderProcessFile> GetOrderProcessFilesByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderProcessFilesByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<OrderProcessFile> GetOrderProcessFilesByOrderID_FileType(Sender sender, Guid OrderID, string FileType)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    List<OrderProcessFile> files = op.LoadOrderProcessFilesByOrderID(OrderID);
                    return files.FindAll(x => x.FileType == FileType);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchOrderProcessFile(Sender sender, SearchOrderProcessFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrderProcessFile(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrderProcessFileByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrderProcessFilesByCabinetID(CabinetID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrderProcessFileByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrderProcessFilesByOrderID(OrderID);
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
