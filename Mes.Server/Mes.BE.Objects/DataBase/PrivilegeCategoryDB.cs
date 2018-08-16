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

        #region BE_PrivilegeCategory InsertObject()
        public int InsertPrivilegeCategory(PrivilegeCategory obj)
        {
            string sql = @"INSERT INTO[BE_PrivilegeCategory]([CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@CategoryID
				, @CategoryName
				, @IconClass
				, @Sequence
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            SqlParameter pIconClass = new SqlParameter("IconClass", Convert2DBnull(obj.IconClass));
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PrivilegeCategory UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePrivilegeCategoryByCategoryName(PrivilegeCategory obj)
        {
            string sql = @"UPDATE [BE_PrivilegeCategory] SET [CategoryID]=@CategoryID
				, [IconClass]=@IconClass
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pIconClass = new SqlParameter("IconClass", Convert2DBnull(obj.IconClass));
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePrivilegeCategoryByCategoryID(PrivilegeCategory obj)
        {
            string sql = @"UPDATE [BE_PrivilegeCategory] SET [CategoryName]=@CategoryName
				, [IconClass]=@IconClass
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            SqlParameter pIconClass = new SqlParameter("IconClass", Convert2DBnull(obj.IconClass));
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategoryByCategoryName(string categoryName)
        {
            string sql = @"DELETE [BE_PrivilegeCategory] WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategoryByCategoryID(Guid categoryID)
        {
            string sql = @"DELETE [BE_PrivilegeCategory] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPrivilegeCategoryByCategoryName(PrivilegeCategory obj)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    obj.CategoryName = dr["CategoryName"].ToString();
                    obj.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
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
        public int LoadPrivilegeCategoryByCategoryID(PrivilegeCategory obj)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    obj.CategoryName = dr["CategoryName"].ToString();
                    obj.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_PrivilegeCategory CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPrivilegeCategorys()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByCategoryID(Guid categoryID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByCategoryName(string categoryName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByIconClass(string iconClass)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeCategorysByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPrivilegeCategorys()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PrivilegeCategory]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByCategoryID(Guid categoryID)
        {
            string sql = "SELECT TOP 1 [CategoryID] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByCategoryName(string categoryName)
        {
            string sql = "SELECT TOP 1 [CategoryName] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByIconClass(string iconClass)
        {
            string sql = "SELECT TOP 1 [IconClass] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeCategorysByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PrivilegeCategory] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePrivilegeCategorys()
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByCategoryID(Guid categoryID)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByCategoryName(string categoryName)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByIconClass(string iconClass)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeCategorysByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PrivilegeCategory] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PrivilegeCategory> LoadPrivilegeCategorys()
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByCategoryID(Guid categoryID)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByCategoryName(string categoryName)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByIconClass(string iconClass)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysBySequence(int sequence)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByCreated(DateTime created)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByModified(DateTime modified)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
        public List<PrivilegeCategory> LoadPrivilegeCategorysByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [CategoryID]
				, [CategoryName]
				, [IconClass]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeCategory] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PrivilegeCategory> ret = new List<PrivilegeCategory>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeCategory iret = new PrivilegeCategory();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_PrivilegeCategory SearchObject()
        public SearchResult SearchPrivilegeCategory(SearchPrivilegeCategoryArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Sequence] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat("SELECT * from [BE_PrivilegeCategory] WHERE 1=1 ");
            this.SetParameters_In(mbBuilder, cmd, "CategoryID", "mbCategoryIDs", args.CategoryIDs);

            if (!string.IsNullOrEmpty(args.CategoryName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CategoryName", "mbCategoryName", args.CategoryName);
            }
            if (args.PrivilegeIDs != null)
            {
                mbBuilder.AppendFormat(" and CategoryID IN ( Select Distinct CategoryID From BE_Privilege where 1=1");
                this.SetParameters_In(mbBuilder, cmd, "PrivilegeID", "mbPrivilegeIDs", args.PrivilegeIDs);
                mbBuilder.AppendFormat(")");
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
