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
        public Solution2Cabinet GetSolution2Cabinet(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Solution2Cabinet obj = new Solution2Cabinet();
                    obj.CabinetID = CabinetID;
                    if (op.LoadSolution2CabinetByCabinetID(obj) == 0)
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
        public List<Solution2Cabinet> GetSolution2CabinetsBySolutionID(Sender sender, Guid SolutionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadSolution2CabinetsBySolutionID(SolutionID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveSolution2Cabinet(Sender sender, Solution2Cabinet item)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Solution2Cabinet obj = new Solution2Cabinet();
                    obj.CabinetID = item.CabinetID;
                    if (op.LoadSolution2CabinetByCabinetID(obj) == 0)
                    {
                        item.Created = DateTime.Now;
                        item.CreatedBy = sender.UserCode + "." + sender.UserName;
                        item.Modified = DateTime.Now;
                        item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertSolution2Cabinet(item);
                    }
                    else
                    {
                        item.Modified = DateTime.Now;
                        item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateSolution2CabinetByCabinetID(item);
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
    }
}
