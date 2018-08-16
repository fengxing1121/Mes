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
        List<Material> GetAllMaterials(Sender sender);
        [OperationContract]
        Material GetMaterial(Sender sender, Guid MaterialID);
        [OperationContract]
        void SaveMaterial(Sender sender, SaveMaterialArgs args);
        [OperationContract]
        SearchResult SearchMaterial(Sender sender, SearchMaterialArgs args);
        [OperationContract]
        Material GetMaterialByMaterialCode(Sender sender, string MaterialCode);

    }
}
