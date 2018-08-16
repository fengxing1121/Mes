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
        public void SaveSolutionFile(Sender sender, SaveSolutionFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    SolutionFile obj = new SolutionFile();
                    obj.FileID = args.SolutionFile.FileID;
                    if (op.LoadSolutionFileByFileID(obj) == 0)
                    {
                        args.SolutionFile.Created = DateTime.Now;
                        args.SolutionFile.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.SolutionFile.Modified = DateTime.Now;
                        args.SolutionFile.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertSolutionFile(args.SolutionFile);
                    }
                    else
                    {
                        args.SolutionFile.Created = DateTime.Now;
                        args.SolutionFile.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.SolutionFile.Modified = DateTime.Now;
                        args.SolutionFile.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateSolutionFileByFileID(args.SolutionFile);
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
        public SolutionFile GetSolutionFile(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SolutionFile obj = new SolutionFile();
                    obj.FileID = FileID;
                    if (op.LoadSolutionFileByFileID(obj) == 0)
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
        public SolutionFile GetSolutionFileBySourceID(Sender sender, Guid SourceID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SolutionFile obj = new SolutionFile();
                    obj.SourceID = SourceID;
                    if (op.LoadSolutionFileBySourceID(obj) == 0)
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
        public void DeleteSolutionFile(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteSolutionFileByFileID(FileID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchSolutionFile(Sender sender, SearchSolutionFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSolutionFile(args);
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
