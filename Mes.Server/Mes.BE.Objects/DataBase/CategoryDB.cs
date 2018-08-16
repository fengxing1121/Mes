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

        #region BE_Category InsertObject()
        public int InsertCategory(Category obj)
        {
            string sql = @"INSERT INTO[BE_Category]([CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@CategoryID
				, @ParentID
				, @CategoryCode
				, @CategoryName
				, @ShortName
				, @Sequence
				, @IsDisabled
				, @Remark
				, @Extend
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pParentID = new SqlParameter("ParentID", Convert2DBnull(obj.ParentID));
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            SqlParameter pShortName = new SqlParameter("ShortName", Convert2DBnull(obj.ShortName));
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pExtend = new SqlParameter("Extend", Convert2DBnull(obj.Extend));
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

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

        #region BE_Category UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCategoryByParentID_CategoryCode(Category obj)
        {
            string sql = @"UPDATE [BE_Category] SET [CategoryID]=@CategoryID
				, [CategoryName]=@CategoryName
				, [ShortName]=@ShortName
				, [Sequence]=@Sequence
				, [IsDisabled]=@IsDisabled
				, [Remark]=@Remark
				, [Extend]=@Extend
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ParentID]=@ParentID AND [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            SqlParameter pShortName = new SqlParameter("ShortName", Convert2DBnull(obj.ShortName));
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pExtend = new SqlParameter("Extend", Convert2DBnull(obj.Extend));
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

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

            SqlParameter pParentID = new SqlParameter("ParentID", Convert2DBnull(obj.ParentID));
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateCategoryByCategoryID(Category obj)
        {
            string sql = @"UPDATE [BE_Category] SET [ParentID]=@ParentID
				, [CategoryCode]=@CategoryCode
				, [CategoryName]=@CategoryName
				, [ShortName]=@ShortName
				, [Sequence]=@Sequence
				, [IsDisabled]=@IsDisabled
				, [Remark]=@Remark
				, [Extend]=@Extend
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", Convert2DBnull(obj.ParentID));
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", Convert2DBnull(obj.CategoryName));
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            SqlParameter pShortName = new SqlParameter("ShortName", Convert2DBnull(obj.ShortName));
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pExtend = new SqlParameter("Extend", Convert2DBnull(obj.Extend));
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

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
        public int DeleteCategoryByParentID_CategoryCode(Guid parentID, string categoryCode)
        {
            string sql = @"DELETE [BE_Category] WHERE [ParentID]=@ParentID AND [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", parentID);
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategoryByCategoryID(Guid categoryID)
        {
            string sql = @"DELETE [BE_Category] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCategoryByParentID_CategoryCode(Category obj)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Category] WITH(NOLOCK) WHERE [ParentID]=@ParentID AND [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", Convert2DBnull(obj.ParentID));
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        obj.ParentID = (Guid)dr["ParentID"];
                    obj.CategoryCode = dr["CategoryCode"].ToString();
                    obj.CategoryName = dr["CategoryName"].ToString();
                    obj.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.Remark = dr["Remark"].ToString();
                    obj.Extend = dr["Extend"].ToString();
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
        public int LoadCategoryByCategoryID(Category obj)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
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
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        obj.ParentID = (Guid)dr["ParentID"];
                    obj.CategoryCode = dr["CategoryCode"].ToString();
                    obj.CategoryName = dr["CategoryName"].ToString();
                    obj.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.Remark = dr["Remark"].ToString();
                    obj.Extend = dr["Extend"].ToString();
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

        #region BE_Category CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCategorys()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByCategoryID(Guid categoryID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByParentID(Guid parentID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [ParentID]=@ParentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", parentID);
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByCategoryCode(string categoryCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByCategoryName(string categoryName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByShortName(string shortName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [ShortName]=@ShortName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShortName = new SqlParameter("ShortName", shortName);
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByExtend(string extend)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [Extend]=@Extend";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExtend = new SqlParameter("Extend", extend);
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCategorysByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Category] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCategorys()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Category]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByCategoryID(Guid categoryID)
        {
            string sql = "SELECT TOP 1 [CategoryID] FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByParentID(Guid parentID)
        {
            string sql = "SELECT TOP 1 [ParentID] FROM [BE_Category] WITH(NOLOCK) WHERE [ParentID]=@ParentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", parentID);
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByCategoryCode(string categoryCode)
        {
            string sql = "SELECT TOP 1 [CategoryCode] FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByCategoryName(string categoryName)
        {
            string sql = "SELECT TOP 1 [CategoryName] FROM [BE_Category] WITH(NOLOCK) WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByShortName(string shortName)
        {
            string sql = "SELECT TOP 1 [ShortName] FROM [BE_Category] WITH(NOLOCK) WHERE [ShortName]=@ShortName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShortName = new SqlParameter("ShortName", shortName);
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_Category] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_Category] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Category] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByExtend(string extend)
        {
            string sql = "SELECT TOP 1 [Extend] FROM [BE_Category] WITH(NOLOCK) WHERE [Extend]=@Extend";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExtend = new SqlParameter("Extend", extend);
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Category] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Category] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Category] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCategorysByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Category] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCategorys()
        {
            string sql = "DELETE FROM [BE_Category]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByCategoryID(Guid categoryID)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByParentID(Guid parentID)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [ParentID]=@ParentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", parentID);
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByCategoryCode(string categoryCode)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByCategoryName(string categoryName)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByShortName(string shortName)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [ShortName]=@ShortName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShortName = new SqlParameter("ShortName", shortName);
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByExtend(string extend)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [Extend]=@Extend";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExtend = new SqlParameter("Extend", extend);
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCategorysByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Category] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Category> LoadCategorys()
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByCategoryID(Guid categoryID)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByParentID(Guid parentID)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [ParentID]=@ParentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pParentID = new SqlParameter("ParentID", parentID);
            pParentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pParentID);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByCategoryCode(string categoryCode)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByCategoryName(string categoryName)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [CategoryName]=@CategoryName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryName = new SqlParameter("CategoryName", categoryName);
            pCategoryName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryName);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByShortName(string shortName)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [ShortName]=@ShortName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShortName = new SqlParameter("ShortName", shortName);
            pShortName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pShortName);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysBySequence(int sequence)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByRemark(string remark)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByExtend(string extend)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [Extend]=@Extend";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExtend = new SqlParameter("Extend", extend);
            pExtend.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pExtend);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByCreated(DateTime created)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByModified(DateTime modified)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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
        public List<Category> LoadCategorysByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [CategoryID]
				, [ParentID]
				, [CategoryCode]
				, [CategoryName]
				, [ShortName]
				, [Sequence]
				, [IsDisabled]
				, [Remark]
				, [Extend]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Category] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Category> ret = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Category iret = new Category();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (Guid)dr["ParentID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.CategoryName = dr["CategoryName"].ToString();
                    iret.ShortName = dr["ShortName"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Extend = dr["Extend"].ToString();
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

        #region BE_Category SearchObject()
        public SearchResult SearchCategory(SearchCategoryArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Sequence] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [CategoryID]
                                          ,[ParentID]
                                          ,[CategoryCode]
                                          ,[CategoryName]
                                          ,[ShortName]
                                          ,[Sequence]
                                          ,[IsDisabled]
                                          ,[Remark]
                                          ,[Extend]
                                          ,[Created]
                                          ,[CreatedBy]
                                          ,[Modified]
                                          ,[ModifiedBy]
                                      FROM [BE_Category] with(nolock)
	                                  WHERE 1=1");


            this.SetParameters_In(mbBuilder, cmd, "CategoryID", "mbCategoryID", args.CategoryIDs);
            if (!string.IsNullOrEmpty(args.CategoryCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CategoryCode", "mbCategoryCode", args.CategoryCode);
            }
            if (!string.IsNullOrEmpty(args.CategoryName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CategoryName", "mbCategoryName", args.CategoryName);
            }
            if (!string.IsNullOrEmpty(args.ShortName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ShortName", "mbShortName", args.ShortName);
            }
            if (args.ParentID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "ParentID", "mbParentID", args.ParentID.Value);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsDisabled", "mbIsDisabled", args.IsDisabled.Value);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
