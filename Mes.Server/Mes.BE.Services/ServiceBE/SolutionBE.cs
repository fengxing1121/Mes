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

        public Solution GetSolution(Sender sender, Guid SolutionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Solution obj = new Solution();
                    obj.SolutionID = SolutionID;
                    if (op.LoadSolutionBySolutionID(obj) == 0)
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
        public Solution GetSolutionByDesignerID(Sender sender, Guid DesignerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Solution obj = new Solution();
                    obj.DesignerID = DesignerID;
                    if (op.LoadSolutionByDesignerID(obj) == 0)
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
        public Solution GetSolutionBySolutionCode(Sender sender, string SolutionCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Solution obj = new Solution();
                    obj.SolutionCode = SolutionCode;
                    if (op.LoadSolutionBySolutionCode(obj) == 0)
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
        public void SaveSolution(Sender sender, SaveSolutionArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Solution obj = new Solution();
                    obj.SolutionID = args.Solution.SolutionID;


                    if (op.LoadSolutionBySolutionID(obj) == 0)
                    {
                        args.Solution.Created = DateTime.Now;
                        args.Solution.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Solution.Modified = DateTime.Now;
                        args.Solution.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertSolution(args.Solution);
                    }
                    else
                    {
                        args.Solution.Modified = DateTime.Now;
                        args.Solution.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateSolutionBySolutionID(args.Solution);
                    }

                    if (args.Solution2Cabinets != null)
                    {
                        op.DeleteSolutionDetailsBySolutionID(args.Solution.SolutionID);
                        op.DeleteSolution2HardwaresBySolutionID(args.Solution.SolutionID);
                        op.DeleteSolution2CabinetsBySolutionID(args.Solution.SolutionID);
                        foreach (Solution2Cabinet item in args.Solution2Cabinets)
                        {
                            Solution2Cabinet subItem = new Solution2Cabinet();
                            subItem.CabinetID = item.CabinetID;
                            if (op.LoadSolution2CabinetByCabinetID(subItem) == 0)
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
                        }
                    }

                    if (args.Solution2Hardwares != null)
                    {
                        op.DeleteSolution2HardwaresBySolutionID(args.Solution.SolutionID);
                        foreach (Solution2Hardware item in args.Solution2Hardwares)
                        {
                            item.Created = DateTime.Now;
                            item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            item.Modified = DateTime.Now;
                            item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertSolution2Hardware(item);
                        }
                    }

                    if (args.SolutionDetails != null)
                    {
                        op.DeleteSolutionDetailsBySolutionID(args.Solution.SolutionID);
                        foreach (SolutionDetail item in args.SolutionDetails)
                        {
                            if (IsSolutionBarcodeDuplicated(sender, item))
                            {
                                throw new PException("产品条码【{0}】已存在。", item.BarcodeNo);
                            }
                            item.Created = DateTime.Now;
                            item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            item.Modified = DateTime.Now;
                            item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertSolutionDetail(item);
                        }
                    }
                    if (args.SolutionOthers != null)
                    {
                        op.DeleteSolutionOtherssBySolutionID(args.Solution.SolutionID);
                        foreach (SolutionOthers item in args.SolutionOthers)
                        {
                            op.InsertSolutionOthers(item);
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
        
        public SearchResult SearchSolution(Sender sender, SearchSolutionArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSolution(args);
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
