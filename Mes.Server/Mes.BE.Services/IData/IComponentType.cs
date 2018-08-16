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
        ComponentType GetComponentType(Sender sender, Int32 ComponentTypeID);

        [OperationContract]
        List<ComponentType> GetAllComponentTypes(Sender sender);

        [OperationContract]
        List<ComponentType> GetComponentTypeByComponentTypeID(Sender sender, Int32 ComponentTypeID);

        [OperationContract]
        SearchResult SearchComponentType(Sender sender, SearchComponentTypeArgs args);

        [OperationContract]
        void SaveComponentType(Sender sender, ComponentType obj);

        [OperationContract]
        void SaveComponentTypes(Sender sender, SaveComponentTypeArgs args);
    }
}

