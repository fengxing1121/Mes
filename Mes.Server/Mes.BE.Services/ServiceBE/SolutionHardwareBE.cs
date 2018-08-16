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
        public SearchResult SearchSolutionHardware(Sender sender, SearchSolution2HardwareArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSolutionHardware(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteSolution2HardwareBySolutionID(Sender sender, Guid SolutionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteSolution2HardwaresBySolutionID(SolutionID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteSolution2HardwareByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteSolution2HardwaresByCabinetID(CabinetID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveSolution2Hardware(Sender sender, Solution2Hardware item)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Solution2Hardware obj = new Solution2Hardware();
                    obj.CabinetID = item.CabinetID;
                    if (op.LoadSolution2HardwareByItemID(obj) == 0)
                    {
                        item.Created = DateTime.Now;
                        item.CreatedBy = sender.UserCode + "." + sender.UserName;
                        item.Modified = DateTime.Now;
                        item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertSolution2Hardware(item);
                    }
                    else
                    {
                        item.Modified = DateTime.Now;
                        item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateSolution2HardwareByItemID(item);
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
