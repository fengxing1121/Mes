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
        #region BE_PartnerUser2Role InsertObject()
        public int InsertPartnerUser2Role(PartnerUser2Role obj)
        {
            string sql = @"INSERT INTO[BE_PartnerUser2Role]([UserID]
				, [RoleID]
				) VALUES(@UserID
				, @RoleID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PartnerUser2Role UpdateObject()、DeleteObject()、LoadObject()
        public int DeletePartnerUser2RoleByUserID_RoleID(Guid userID, Guid roleID)
        {
            string sql = @"DELETE [BE_PartnerUser2Role] WHERE [UserID]=@UserID AND [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerUser2RoleByUserID_RoleID(PartnerUser2Role obj)
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
 				FROM [BE_PartnerUser2Role] WITH(NOLOCK) WHERE [UserID]=@UserID AND [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["UserID"]))
                        obj.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        obj.RoleID = (Guid)dr["RoleID"];
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

        #region BE_PartnerUser2Role CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerUser2Roles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUser2RolesByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser2Role] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUser2RolesByRoleID(Guid roleID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser2Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerUser2Roles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerUser2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUser2RolesByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_PartnerUser2Role] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUser2RolesByRoleID(Guid roleID)
        {
            string sql = "SELECT TOP 1 [RoleID] FROM [BE_PartnerUser2Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerUser2Roles()
        {
            string sql = "DELETE FROM [BE_PartnerUser2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUser2RolesByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_PartnerUser2Role] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUser2RolesByRoleID(Guid roleID)
        {
            string sql = "DELETE FROM [BE_PartnerUser2Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerUser2Role> LoadPartnerUser2Roles()
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
				 FROM [BE_PartnerUser2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerUser2Role> ret = new List<PartnerUser2Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser2Role iret = new PartnerUser2Role();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerUser2Role> LoadPartnerUser2RolesByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
				 FROM [BE_PartnerUser2Role] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<PartnerUser2Role> ret = new List<PartnerUser2Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser2Role iret = new PartnerUser2Role();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerUser2Role> LoadPartnerUser2RolesByRoleID(Guid roleID)
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
				 FROM [BE_PartnerUser2Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<PartnerUser2Role> ret = new List<PartnerUser2Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser2Role iret = new PartnerUser2Role();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
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
    }
}
