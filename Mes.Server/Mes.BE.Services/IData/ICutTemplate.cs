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
    public partial interface IServiceBE
    {
        [OperationContract]
        List<CutTemplate> GetAllCutTemplates(Sender sender);
        [OperationContract]
        CutTemplate GetCutTemplate(Sender sender, Guid TemplateID);
        [OperationContract]
        CutTemplate GetCutTemplateByTemplateCode(Sender sender, string TemplateCode);
        [OperationContract]
        void SaveCutTemplate(Sender sender, SaveCutTemplateArgs args);
        [OperationContract]
        SearchResult SearchCutTemplate(Sender sender, SearchCutTemplateArgs args);
        [OperationContract]
        bool CutTemplateCodeIsDuplicated(Sender sender, CutTemplate template);
        [OperationContract]
        bool CutTemplateNameIsDuplicated(Sender sender, CutTemplate template);
        [OperationContract]
        void DeleteCutTemplate(Sender sender, Guid TemplateID);
    }
}
