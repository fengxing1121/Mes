using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using MES.Libraries;
using System.Linq;

namespace Mes.BE.Objects
{
    public partial class ObjectProxy
    {
     
        #region BE_Favorite InsertObject()
        public int InsertFavorite(Favorite obj)
        {
            string sql = @"INSERT INTO[BE_Favorite]([UserID]
				, [PrivilegeID]
				) VALUES(@UserID
				, @PrivilegeID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Favorite UpdateObject()、DeleteObject()、LoadObject()
        public int DeleteFavoriteByUserID_PrivilegeID(Guid userID, Guid privilegeID)
        {
            string sql = @"DELETE [BE_Favorite] WHERE [UserID]=@UserID AND [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadFavoriteByUserID_PrivilegeID(Favorite obj)
        {
            string sql = @"SELECT [UserID]
				, [PrivilegeID]
 				FROM [BE_Favorite] WITH(NOLOCK) WHERE [UserID]=@UserID AND [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["UserID"]))
                        obj.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        #endregion

        #region BE_Favorite CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountFavorites()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Favorite]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountFavoritesByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Favorite] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountFavoritesByPrivilegeID(Guid privilegeID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Favorite] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsFavorites()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Favorite]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsFavoritesByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_Favorite] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsFavoritesByPrivilegeID(Guid privilegeID)
        {
            string sql = "SELECT TOP 1 [PrivilegeID] FROM [BE_Favorite] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteFavorites()
        {
            string sql = "DELETE FROM [BE_Favorite]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteFavoritesByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_Favorite] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteFavoritesByPrivilegeID(Guid privilegeID)
        {
            string sql = "DELETE FROM [BE_Favorite] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        public List<Favorite> LoadFavorites()
        {
            string sql = @"SELECT [UserID]
				, [PrivilegeID]
				 FROM [BE_Favorite]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Favorite> ret = new List<Favorite>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Favorite iret = new Favorite();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Favorite> LoadFavoritesByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [PrivilegeID]
				 FROM [BE_Favorite] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<Favorite> ret = new List<Favorite>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Favorite iret = new Favorite();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Favorite> LoadFavoritesByPrivilegeID(Guid privilegeID)
        {
            string sql = @"SELECT [UserID]
				, [PrivilegeID]
				 FROM [BE_Favorite] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<Favorite> ret = new List<Favorite>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Favorite iret = new Favorite();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        #endregion

        #region BE_Favorite SearchObject()
        public SearchResult SearchFavorite(SearchFavoriteArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CategoryID],[Sequence] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Favorite].[UserID]
                                          ,[BE_Favorite].[PrivilegeID]
	                                      ,[BE_User].[UserCode]
	                                      ,[BE_User].[UserName]
	                                      ,[BE_Privilege].[PrivilegeCode]
	                                      ,[BE_Privilege].[CategoryID]
	                                      ,[BE_PrivilegeCategory].[CategoryName]	                                  
	                                      ,[BE_Privilege].[PrivilegeName]
		                                  ,[BE_Privilege].[FavoriteCategory]
	                                      ,[BE_Privilege].[PageURL]
	                                      ,[BE_Privilege].[IconClass]
	                                      ,[BE_Privilege].[IsDisabled]	 
	                                      ,[BE_Privilege].[Sequence]
                                      FROM [BE_Favorite] with(nolock)
                                          LEFT JOIN [BE_User] with(nolock) on [BE_User].[UserID] = [BE_Favorite].[UserID]
                                          LEFT JOIN [BE_Privilege] with(nolock) on [BE_Privilege].[PrivilegeID] = [BE_Favorite].[PrivilegeID]
                                          LEFT JOIN [BE_PrivilegeCategory] with(nolock) on [BE_Privilege].[CategoryID] = [BE_PrivilegeCategory].[CategoryID]
	                                  WHERE 1=1");


            this.SetParameters_Equals(mbBuilder, cmd, "BE_Favorite].[UserID", "mbUserID", args.UserID);
            if (args.PrivilegeID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Favorite].[PrivilegeID", "mbPrivilegeID", args.PrivilegeID);
            }
            if (args.CategoryID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Privilege].[CategoryID", "mbCategoryID", args.CategoryID);
            }
            if (!string.IsNullOrEmpty(args.FavoriteCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Privilege].[FavoriteCategory", "mbFavoriteCategory", args.FavoriteCategory);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Privilege].[IsDisabled", "mbIsDisabled", args.IsDisabled);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
