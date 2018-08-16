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
        #region BE_UserPassword InsertObject()
        public int InsertUserPassword(UserPassword obj)
        {
            string sql = @"INSERT INTO[BE_UserPassword]([UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@UserID
				, @Password
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPassword = new SqlParameter("Password", Convert2DBnull(obj.Password));
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_UserPassword UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateUserPasswordByUserID_Modified(UserPassword obj)
        {
            string sql = @"UPDATE [BE_UserPassword] SET [Password]=@Password
				, [ModifiedBy]=@ModifiedBy
 				WHERE [UserID]=@UserID AND [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", Convert2DBnull(obj.Password));
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserPasswordByUserID_Modified(Guid userID, DateTime modified)
        {
            string sql = @"DELETE [BE_UserPassword] WHERE [UserID]=@UserID AND [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int LoadUserPasswordByUserID_Modified(UserPassword obj)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_UserPassword] WITH(NOLOCK) WHERE [UserID]=@UserID AND [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["UserID"]))
                        obj.UserID = (Guid)dr["UserID"];
                    obj.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    obj.ModifiedBy = dr["ModifiedBy"].ToString();
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

        #region BE_UserPassword CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountUserPasswords()
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserPasswordsByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserPassword] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserPasswordsByPassword(string password)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserPassword] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserPasswordsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserPassword] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserPassword] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsUserPasswords()
        {
            string sql = "SELECT TOP 1 * FROM [BE_UserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserPasswordsByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_UserPassword] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserPasswordsByPassword(string password)
        {
            string sql = "SELECT TOP 1 [Password] FROM [BE_UserPassword] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserPasswordsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_UserPassword] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_UserPassword] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteUserPasswords()
        {
            string sql = "DELETE FROM [BE_UserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserPasswordsByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_UserPassword] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserPasswordsByPassword(string password)
        {
            string sql = "DELETE FROM [BE_UserPassword] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserPasswordsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_UserPassword] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_UserPassword] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<UserPassword> LoadUserPasswords()
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<UserPassword> ret = new List<UserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserPassword iret = new UserPassword();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<UserPassword> LoadUserPasswordsByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserPassword] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<UserPassword> ret = new List<UserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserPassword iret = new UserPassword();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<UserPassword> LoadUserPasswordsByPassword(string password)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserPassword] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            List<UserPassword> ret = new List<UserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserPassword iret = new UserPassword();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<UserPassword> LoadUserPasswordsByModified(DateTime modified)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserPassword] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<UserPassword> ret = new List<UserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserPassword iret = new UserPassword();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<UserPassword> LoadUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserPassword] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<UserPassword> ret = new List<UserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserPassword iret = new UserPassword();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
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
