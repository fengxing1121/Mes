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
        void SaveFavorite(Sender sender, SaveFavoriteArgs args);
        [OperationContract]
        void SaveFavorites(Sender sender, SaveFavoritesArgs args);
        [OperationContract]
        void DeleteFavorite(Sender sender, Guid UserID, Guid PrivilegeID);
        [OperationContract]
        void DeleteFavoritesByUserID(Sender sender, Guid UserID);
        [OperationContract]
        SearchResult SearchFavorite(Sender sender, SearchFavoriteArgs args);
    }
}
