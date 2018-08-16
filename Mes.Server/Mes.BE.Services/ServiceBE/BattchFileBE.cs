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
        public void SaveBattchFile(Sender sender, SaveBattchFileArgs args)
        {
            try
            {

                using (ObjectProxy op = new ObjectProxy(true))
                {

                    if (string.IsNullOrEmpty(args.BattchFile.BattchNum))
                    {
                        throw new PException("批次号不能为空。");
                    }
                    else if (BattchFileIsDuplicated(sender, args.BattchFile))
                    {
                        throw new PException("批次号【{0}】已经上传了文件", args.BattchFile.BattchNum);
                    }

                    BattchFile obj = new BattchFile();
                    obj.FileID = args.BattchFile.FileID;
                    if (op.LoadBattchFileByFileID(obj) == 0)
                    {
                        args.BattchFile.Created = DateTime.Now;
                        args.BattchFile.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.BattchFile.Modified = DateTime.Now;
                        args.BattchFile.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertBattchFile(args.BattchFile);
                    }
                    else
                    {
                        args.BattchFile.Modified = DateTime.Now;
                        args.BattchFile.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateBattchFileByFileID(args.BattchFile);
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
        public SearchResult SearchBattchFile(Sender sender, SearchBattchFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchBattchFile(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteBattchFileByBattchNum_FileName(Sender sender, string BattchNum, string FileName)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteBattchFileByBattchNum_FileName(BattchNum, FileName);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteBattchFileByFileID(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteBattchFileByFileID(FileID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public BattchFile GetBattchFile(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    BattchFile obj = new BattchFile();
                    obj.FileID = FileID;
                    if (op.LoadBattchFileByFileID(obj) == 0)
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
        public List<BattchFile> GetBattchFileByBattchNum(Sender sender, string BattchNum)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadBattchFilesByBattchNum(BattchNum);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool BattchFileIsDuplicated(Sender sender, BattchFile battchFile)
        {
            try
            {
                BattchFile obj = new BattchFile();
                obj.BattchNum = battchFile.BattchNum;
                obj.FileName = battchFile.FileName;
                using (ObjectProxy op = new ObjectProxy())
                {
                    if (op.LoadBattchFileByBattchNum_FileName(obj) == 0)
                    {
                        return false;
                    }
                    return obj.FileID != battchFile.FileID;
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
