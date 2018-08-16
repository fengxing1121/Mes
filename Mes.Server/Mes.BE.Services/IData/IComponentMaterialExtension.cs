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
        ComponentMaterialExtension GetComponentMaterialExtension(Sender sender, Int32 ID);

        [OperationContract]
        List<ComponentMaterialExtension> GetAllComponentMaterialExtensions(Sender sender);

        [OperationContract]
        List<ComponentMaterialExtension> GetComponentMaterialExtensionByID(Sender sender, Int32 ID);

        [OperationContract]
        SearchResult SearchComponentMaterialExtension(Sender sender, SearchComponentMaterialExtensionArgs args);

        [OperationContract]
        void SaveComponentMaterialExtension(Sender sender, ComponentMaterialExtension obj);

        [OperationContract]
        void SaveComponentMaterialExtensions(Sender sender, SaveComponentMaterialExtensionArgs args);
    }
}