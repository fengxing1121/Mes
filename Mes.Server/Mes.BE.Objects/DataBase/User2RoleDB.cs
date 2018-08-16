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
        #region BE_User2Role InsertObject()
        public int InsertUser2Role(User2Role obj)
        {
            string sql = @"INSERT INTO[BE_User2Role]([UserID]
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

        #region BE_User2Role UpdateObject()、DeleteObject()、LoadObject()
        public int DeleteUser2RoleByUserID_RoleID(Guid userID, Guid roleID)
        {
            string sql = @"DELETE [BE_User2Role] WHERE [UserID]=@UserID AND [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadUser2RoleByUserID_RoleID(User2Role obj)
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
 				FROM [BE_User2Role] WITH(NOLOCK) WHERE [UserID]=@UserID AND [RoleID]=@RoleID";
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

        #region BE_User2Role CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountUser2Roles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_User2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUser2RolesByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User2Role] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUser2RolesByRoleID(Guid roleID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User2Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsUser2Roles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_User2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUser2RolesByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_User2Role] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUser2RolesByRoleID(Guid roleID)
        {
            string sql = "SELECT TOP 1 [RoleID] FROM [BE_User2Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteUser2Roles()
        {
            string sql = "DELETE FROM [BE_User2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUser2RolesByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_User2Role] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUser2RolesByRoleID(Guid roleID)
        {
            string sql = "DELETE FROM [BE_User2Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public List<User2Role> LoadUser2Roles()
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
				 FROM [BE_User2Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<User2Role> ret = new List<User2Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User2Role iret = new User2Role();
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
        public List<User2Role> LoadUser2RolesByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
				 FROM [BE_User2Role] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<User2Role> ret = new List<User2Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User2Role iret = new User2Role();
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
        public List<User2Role> LoadUser2RolesByRoleID(Guid roleID)
        {
            string sql = @"SELECT [UserID]
				, [RoleID]
				 FROM [BE_User2Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<User2Role> ret = new List<User2Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User2Role iret = new User2Role();
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
