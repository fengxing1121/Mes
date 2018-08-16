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
        #region BE_PartnerUserPassword InsertObject()
        public int InsertPartnerUserPassword(PartnerUserPassword obj)
        {
            string sql = @"INSERT INTO[BE_PartnerUserPassword]([UserID]
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

        #region BE_PartnerUserPassword UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerUserPasswordByUserID_Modified(PartnerUserPassword obj)
        {
            string sql = @"UPDATE [BE_PartnerUserPassword] SET [Password]=@Password
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
        public int DeletePartnerUserPasswordByUserID_Modified(Guid userID, DateTime modified)
        {
            string sql = @"DELETE [BE_PartnerUserPassword] WHERE [UserID]=@UserID AND [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerUserPasswordByUserID_Modified(PartnerUserPassword obj)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [UserID]=@UserID AND [Modified]=@Modified";
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

        #region BE_PartnerUserPassword CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerUserPasswords()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserPasswordsByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserPasswordsByPassword(string password)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserPasswordsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerUserPasswords()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerUserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserPasswordsByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserPasswordsByPassword(string password)
        {
            string sql = "SELECT TOP 1 [Password] FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserPasswordsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PartnerUserPassword] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerUserPasswords()
        {
            string sql = "DELETE FROM [BE_PartnerUserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserPasswordsByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_PartnerUserPassword] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserPasswordsByPassword(string password)
        {
            string sql = "DELETE FROM [BE_PartnerUserPassword] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserPasswordsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PartnerUserPassword] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PartnerUserPassword] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerUserPassword> LoadPartnerUserPasswords()
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserPassword]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerUserPassword> ret = new List<PartnerUserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserPassword iret = new PartnerUserPassword();
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
        public List<PartnerUserPassword> LoadPartnerUserPasswordsByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserPassword] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<PartnerUserPassword> ret = new List<PartnerUserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserPassword iret = new PartnerUserPassword();
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
        public List<PartnerUserPassword> LoadPartnerUserPasswordsByPassword(string password)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserPassword] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            List<PartnerUserPassword> ret = new List<PartnerUserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserPassword iret = new PartnerUserPassword();
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
        public List<PartnerUserPassword> LoadPartnerUserPasswordsByModified(DateTime modified)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserPassword] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PartnerUserPassword> ret = new List<PartnerUserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserPassword iret = new PartnerUserPassword();
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
        public List<PartnerUserPassword> LoadPartnerUserPasswordsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [UserID]
				, [Password]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserPassword] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PartnerUserPassword> ret = new List<PartnerUserPassword>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserPassword iret = new PartnerUserPassword();
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
