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
        public void SaveFavorite(Sender sender, SaveFavoriteArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Favorite obj = new Favorite();
                    obj.UserID = args.Favorite.UserID;
                    obj.PrivilegeID = args.Favorite.PrivilegeID;
                    if (op.LoadFavoriteByUserID_PrivilegeID(obj) == 0)
                    {
                        op.InsertFavorite(args.Favorite);
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
        public void SaveFavorites(Sender sender, SaveFavoritesArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    foreach (Favorite obj in args.Favorites)
                    {
                        if (op.LoadFavoriteByUserID_PrivilegeID(obj) == 0)
                        {
                            op.InsertFavorite(obj);
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
        public void DeleteFavorite(Sender sender, Guid UserID, Guid PrivilegeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteFavoriteByUserID_PrivilegeID(UserID, PrivilegeID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteFavoritesByUserID(Sender sender, Guid UserID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteFavoritesByUserID(UserID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchFavorite(Sender sender, SearchFavoriteArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchFavorite(args);
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
