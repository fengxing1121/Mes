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
        ComponentMaterial GetComponentMaterial(Sender sender, Int32 ID);

        [OperationContract]
        List<ComponentMaterial> GetAllComponentMaterials(Sender sender);

        [OperationContract]
        List<ComponentMaterial> GetComponentMaterialByID(Sender sender, Int32 ID);


        [OperationContract]
        SearchResult SearchComponentMaterial(Sender sender, SearchComponentMaterialArgs args);

        [OperationContract]
        SearchResult SearchComponentMaterialByComponentID(Sender sender, SearchComponentMaterialArgs args);

        [OperationContract]
        void SaveComponentMaterial(Sender sender, ComponentMaterial obj);

        [OperationContract]
        void SaveComponentMaterials(Sender sender, SaveComponentMaterialArgs args);

        [OperationContract]
        void SaveComponentMaterialAndExtension(Sender sender, SaveComponentMaterialArgs args);
    }
}

