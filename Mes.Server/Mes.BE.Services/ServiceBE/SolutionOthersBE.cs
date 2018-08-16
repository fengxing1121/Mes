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
        #region 方案其他部件
        public SolutionOthers GetSolutionOthers(Sender sender, Guid DetailID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SolutionOthers obj = new SolutionOthers();
                    obj.DetailID = DetailID;
                    if (op.LoadSolutionOthersByDetailID(obj) == 0)
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
        public List<SolutionOthers> GetSolutionOthersByCabinetGroup(Sender sender, Guid SolutionID, string CabinetGroup)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    List<SolutionOthers> lists = op.LoadSolutionOtherssBySolutionID(SolutionID);
                    if (lists != null)
                        return lists.FindAll(li => li.CabinetGroup == CabinetGroup);
                    else
                        return new List<SolutionOthers>();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<SolutionOthers> GetSolutionOthersBySolutionID(Sender sender, Guid SolutionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadSolutionOtherssBySolutionID(SolutionID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveSolutionOthers(Sender sender, SaveSolutionOthersArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    SolutionOthers obj = new SolutionOthers();
                    obj.DetailID = args.SolutionOthers.DetailID;
                    if (op.LoadSolutionOthersByDetailID(obj) == 0)
                    {
                        op.InsertSolutionOthers(args.SolutionOthers);
                    }
                    else
                    {
                        op.UpdateSolutionOthersByDetailID(args.SolutionOthers);
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
        public void DeleteSolutionOthers(Sender sender, Guid DetailID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteSolutionOtherssByDetailID(DetailID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchSolutionOthers(Sender sender, SearchSolutionOthersArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchSolutionOthers(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
