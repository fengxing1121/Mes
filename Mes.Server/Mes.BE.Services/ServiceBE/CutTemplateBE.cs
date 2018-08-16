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
        public List<CutTemplate> GetAllCutTemplates(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCutTemplates();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public CutTemplate GetCutTemplate(Sender sender, Guid TemplateID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    CutTemplate obj = new CutTemplate();
                    obj.TemplateID = TemplateID;
                    if (op.LoadCutTemplateByTemplateID(obj) == 0)
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
        public CutTemplate GetCutTemplateByTemplateCode(Sender sender, string TemplateCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    CutTemplate obj = new CutTemplate();
                    obj.TemplateCode = TemplateCode;
                    if (op.LoadCutTemplateByTemplateCode(obj) == 0)
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
        public void SaveCutTemplate(Sender sender, SaveCutTemplateArgs args)
        {
            try
            {
                if (this.CutTemplateCodeIsDuplicated(sender, args.CutTemplate))
                {
                    throw new PException("模板编号【{0}】已经存在", args.CutTemplate.TemplateCode);
                }
                if (this.CutTemplateNameIsDuplicated(sender, args.CutTemplate))
                {
                    throw new PException("模板名称【{0}】已经存在", args.CutTemplate.TemplateName);
                }
                using (ObjectProxy op = new ObjectProxy(true))
                {

                    CutTemplate obj = new CutTemplate();
                    obj.TemplateID = args.CutTemplate.TemplateID;
                    if (op.LoadCutTemplateByTemplateCode(obj) == 0)
                    {
                        args.CutTemplate.Created = DateTime.Now;
                        args.CutTemplate.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.CutTemplate.Modified = DateTime.Now;
                        args.CutTemplate.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertCutTemplate(args.CutTemplate);
                    }
                    else
                    {
                        args.CutTemplate.Modified = DateTime.Now;
                        args.CutTemplate.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateCutTemplateByTemplateID(args.CutTemplate);
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
        public SearchResult SearchCutTemplate(Sender sender, SearchCutTemplateArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCutTemplate(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool CutTemplateCodeIsDuplicated(Sender sender, CutTemplate template)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    CutTemplate obj = new CutTemplate();
                    obj.TemplateCode = template.TemplateCode;
                    if (op.LoadCutTemplateByTemplateCode(obj) == 0)
                    {
                        return false;
                    }
                    return obj.TemplateID != template.TemplateID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool CutTemplateNameIsDuplicated(Sender sender, CutTemplate template)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    CutTemplate obj = new CutTemplate();
                    obj.TemplateName = template.TemplateName;
                    if (op.LoadCutTemplateByTemplateName(obj) == 0)
                    {
                        return false;
                    }
                    return obj.TemplateID != template.TemplateID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteCutTemplate(Sender sender, Guid TemplateID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteCutTemplateByTemplateID(TemplateID);
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
