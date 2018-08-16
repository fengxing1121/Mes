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

        #region BE_Privilege InsertObject()
        public int InsertPrivilege(Privilege obj)
        {
            string sql = @"INSERT INTO[BE_Privilege]([PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@PrivilegeID
				, @CategoryID
				, @PrivilegeName
				, @PrivilegeCode
				, @PageURL
				, @IconClass
				, @Description
				, @IsDisabled
				, @FavoriteCategory
				, @Sequence
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", Convert2DBnull(obj.PrivilegeName));
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", Convert2DBnull(obj.PrivilegeCode));
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            SqlParameter pPageURL = new SqlParameter("PageURL", Convert2DBnull(obj.PageURL));
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            SqlParameter pIconClass = new SqlParameter("IconClass", Convert2DBnull(obj.IconClass));
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", Convert2DBnull(obj.FavoriteCategory));
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

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

        #region BE_Privilege UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePrivilegeByPrivilegeCode(Privilege obj)
        {
            string sql = @"UPDATE [BE_Privilege] SET [PrivilegeID]=@PrivilegeID
				, [CategoryID]=@CategoryID
				, [PrivilegeName]=@PrivilegeName
				, [PageURL]=@PageURL
				, [IconClass]=@IconClass
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [FavoriteCategory]=@FavoriteCategory
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", Convert2DBnull(obj.PrivilegeName));
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            SqlParameter pPageURL = new SqlParameter("PageURL", Convert2DBnull(obj.PageURL));
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            SqlParameter pIconClass = new SqlParameter("IconClass", Convert2DBnull(obj.IconClass));
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", Convert2DBnull(obj.FavoriteCategory));
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

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

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", Convert2DBnull(obj.PrivilegeCode));
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePrivilegeByPrivilegeID(Privilege obj)
        {
            string sql = @"UPDATE [BE_Privilege] SET [CategoryID]=@CategoryID
				, [PrivilegeName]=@PrivilegeName
				, [PrivilegeCode]=@PrivilegeCode
				, [PageURL]=@PageURL
				, [IconClass]=@IconClass
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [FavoriteCategory]=@FavoriteCategory
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", Convert2DBnull(obj.PrivilegeName));
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", Convert2DBnull(obj.PrivilegeCode));
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            SqlParameter pPageURL = new SqlParameter("PageURL", Convert2DBnull(obj.PageURL));
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            SqlParameter pIconClass = new SqlParameter("IconClass", Convert2DBnull(obj.IconClass));
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", Convert2DBnull(obj.FavoriteCategory));
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

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

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeByPrivilegeCode(string privilegeCode)
        {
            string sql = @"DELETE [BE_Privilege] WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeByPrivilegeID(Guid privilegeID)
        {
            string sql = @"DELETE [BE_Privilege] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPrivilegeByPrivilegeCode(Privilege obj)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", Convert2DBnull(obj.PrivilegeCode));
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    obj.PrivilegeName = dr["PrivilegeName"].ToString();
                    obj.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    obj.PageURL = dr["PageURL"].ToString();
                    obj.IconClass = dr["IconClass"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public int LoadPrivilegeByPrivilegeID(Privilege obj)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    obj.PrivilegeName = dr["PrivilegeName"].ToString();
                    obj.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    obj.PageURL = dr["PageURL"].ToString();
                    obj.IconClass = dr["IconClass"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.FavoriteCategory = dr["FavoriteCategory"].ToString();
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

        #region BE_Privilege CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPrivileges()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByPrivilegeID(Guid privilegeID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByCategoryID(Guid categoryID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByPrivilegeName(string privilegeName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeName]=@PrivilegeName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", privilegeName);
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByPrivilegeCode(string privilegeCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByPageURL(string pageURL)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [PageURL]=@PageURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPageURL = new SqlParameter("PageURL", pageURL);
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByIconClass(string iconClass)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByFavoriteCategory(string favoriteCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [FavoriteCategory]=@FavoriteCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", favoriteCategory);
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Privilege] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPrivileges()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Privilege]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByPrivilegeID(Guid privilegeID)
        {
            string sql = "SELECT TOP 1 [PrivilegeID] FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByCategoryID(Guid categoryID)
        {
            string sql = "SELECT TOP 1 [CategoryID] FROM [BE_Privilege] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByPrivilegeName(string privilegeName)
        {
            string sql = "SELECT TOP 1 [PrivilegeName] FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeName]=@PrivilegeName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", privilegeName);
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByPrivilegeCode(string privilegeCode)
        {
            string sql = "SELECT TOP 1 [PrivilegeCode] FROM [BE_Privilege] WITH(NOLOCK) WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByPageURL(string pageURL)
        {
            string sql = "SELECT TOP 1 [PageURL] FROM [BE_Privilege] WITH(NOLOCK) WHERE [PageURL]=@PageURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPageURL = new SqlParameter("PageURL", pageURL);
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByIconClass(string iconClass)
        {
            string sql = "SELECT TOP 1 [IconClass] FROM [BE_Privilege] WITH(NOLOCK) WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_Privilege] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_Privilege] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByFavoriteCategory(string favoriteCategory)
        {
            string sql = "SELECT TOP 1 [FavoriteCategory] FROM [BE_Privilege] WITH(NOLOCK) WHERE [FavoriteCategory]=@FavoriteCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", favoriteCategory);
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_Privilege] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Privilege] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Privilege] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Privilege] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Privilege] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePrivileges()
        {
            string sql = "DELETE FROM [BE_Privilege]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByPrivilegeID(Guid privilegeID)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByCategoryID(Guid categoryID)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByPrivilegeName(string privilegeName)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [PrivilegeName]=@PrivilegeName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", privilegeName);
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByPrivilegeCode(string privilegeCode)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByPageURL(string pageURL)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [PageURL]=@PageURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPageURL = new SqlParameter("PageURL", pageURL);
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByIconClass(string iconClass)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByDescription(string description)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByFavoriteCategory(string favoriteCategory)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [FavoriteCategory]=@FavoriteCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", favoriteCategory);
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Privilege] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Privilege> LoadPrivileges()
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByPrivilegeID(Guid privilegeID)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByCategoryID(Guid categoryID)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByPrivilegeName(string privilegeName)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [PrivilegeName]=@PrivilegeName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeName = new SqlParameter("PrivilegeName", privilegeName);
            pPrivilegeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeName);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByPrivilegeCode(string privilegeCode)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [PrivilegeCode]=@PrivilegeCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByPageURL(string pageURL)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [PageURL]=@PageURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPageURL = new SqlParameter("PageURL", pageURL);
            pPageURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPageURL);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByIconClass(string iconClass)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [IconClass]=@IconClass";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIconClass = new SqlParameter("IconClass", iconClass);
            pIconClass.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIconClass);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByDescription(string description)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByFavoriteCategory(string favoriteCategory)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [FavoriteCategory]=@FavoriteCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFavoriteCategory = new SqlParameter("FavoriteCategory", favoriteCategory);
            pFavoriteCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFavoriteCategory);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesBySequence(int sequence)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByCreated(DateTime created)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByModified(DateTime modified)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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
        public List<Privilege> LoadPrivilegesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [PrivilegeID]
				, [CategoryID]
				, [PrivilegeName]
				, [PrivilegeCode]
				, [PageURL]
				, [IconClass]
				, [Description]
				, [IsDisabled]
				, [FavoriteCategory]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Privilege] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.IconClass = dr["IconClass"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.FavoriteCategory = dr["FavoriteCategory"].ToString();
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

        #region BE_Privilege SearchObject()
        public SearchResult SearchPrivilege(SearchPrivilegeArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[MainSequence],[Sequence]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
		                                [BE_Privilege].[PrivilegeID]
		                                ,[BE_Privilege].[CategoryID]
		                                ,[CategoryName]
		                                ,[BE_Privilege].[PrivilegeName]
		                                ,[BE_Privilege].[PrivilegeCode]
		                                ,[BE_Privilege].[PageURL]
		                                ,[BE_Privilege].[IconClass]
		                                ,[BE_Privilege].[Description]
		                                ,[BE_Privilege].[IsDisabled]
                                        ,[BE_PrivilegeCategory].[Sequence] as [MainSequence]
		                                ,[BE_Privilege].[Sequence]
		                                ,[BE_Privilege].[FavoriteCategory]
		                                ,[BE_Privilege].[Created]
		                                ,[BE_Privilege].[CreatedBy]
		                                ,[BE_Privilege].[Modified]
		                                ,[BE_Privilege].[ModifiedBy] 
	                                from 
		                                [BE_Privilege] with(nolock) 
		                                LEFT JOIN [BE_PrivilegeCategory] on [BE_Privilege].[CategoryID] = [BE_PrivilegeCategory].[CategoryID]
                                    where 1=1");
            this.SetParameters_In(mbBuilder, cmd, "PrivilegeID", "mbPrivilegeIDs", args.PrivilegeIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_Privilege].[CategoryID", "mbCategoryIDs", args.CategoryIDs);
            if (!string.IsNullOrEmpty(args.PrivilegeCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PrivilegeCode", "mbPrivilegeCode", args.PrivilegeCode);
            }
            if (!string.IsNullOrEmpty(args.PrivilegeName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PrivilegeName", "mbPrivilegeName", args.PrivilegeName);
            }
            if (args.RKeyUserIDs != null || args.RKeyRoleIDs != null)
            {
                mbBuilder.Append(" AND [PrivilegeID] IN (SELECT DISTINCT [PrivilegeID] FROM [BE_PrivilegeItem] ");
                mbBuilder.Append(" LEFT JOIN [BE_Role2PrivilegeItem] ON [BE_Role2PrivilegeItem].[PrivilegeItemID] = [BE_PrivilegeItem].[PrivilegeItemID]");
                mbBuilder.Append(" LEFT JOIN [BE_User2Role] ON [BE_Role2PrivilegeItem].[RoleID] = [BE_User2Role].[RoleID] WHERE 1=1");

                if (args.RKeyUserIDs != null)
                {
                    this.SetParameters_In(mbBuilder, cmd, "UserID", "rkUserID", args.RKeyUserIDs);
                }
                if (args.RKeyRoleIDs != null)
                {
                    this.SetParameters_In(mbBuilder, cmd, "BE_Role2PrivilegeItem].[RoleID", "rkRoleID", args.RKeyRoleIDs);
                }
                mbBuilder.Append(")");
            }
            //if (args.RKeyRoleIDs != null)
            //{
            //    mbBuilder.Append(" AND [PrivilegeID] IN (SELECT DISTINCT [PrivilegeID] FROM [BE_PrivilegeItem] ");
            //    mbBuilder.Append(" LEFT JOIN [BE_Role2PrivilegeItem] ON [BE_Role2PrivilegeItem].[PrivilegeItemID] = [BE_PrivilegeItem].[PrivilegeItemID]");
            //    mbBuilder.Append(" LEFT JOIN [BE_User2Role] ON [BE_Role2PrivilegeItem].[RoleID] = [BE_User2Role].[RoleID] WHERE 1=1");
            //    this.SetParameters_In(mbBuilder, cmd, "RoleID", "rkRoleID", args.RKeyRoleIDs);
            //    mbBuilder.Append(")");
            //}
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Privilege].[IsDisabled", "mbIsDisabled", args.IsDisabled.Value.ToString());
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public List<Privilege> LoadPrivilegesByUserID(Guid userID)
        {
            string sql = @"SELECT [PrivilegeID]
                                , [CategoryID]				               
				                , [PrivilegeName]
				                , [PrivilegeCode]
				                , [PageURL]
				                , [Description]
				                , [IsDisabled]
                                , [Sequence]
				                , [Created]
				                , [CreatedBy]
				                , [Modified]
				                , [ModifiedBy]				
                            FROM 
	                            [BE_Privilege]
                            WHERE
								[IsDisabled] = 0
                                AND [PrivilegeID] IN 
                                (
	                                SELECT 
		                                DISTINCT [PrivilegeID] 
	                                FROM 
									    [BE_PrivilegeItem]		                            
	                                WHERE	                            
									    [PrivilegeItemID] IN
									    (SELECT
											    DISTINCT [PrivilegeItemID]
										    FROM
											    [BE_Role2PrivilegeItem]
										    WHERE
											    [RoleID] IN
											    (SELECT
													    DISTINCT [RoleID]
												    FROM
													    [BE_User2Role]
												    WHERE						                            
													    1 = 1
													    and [UserID] = @UserID
											    )											
									    )		                            		
                                )
                               Order By Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("UserID", userID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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

        public List<Privilege> LoadPrivilegesByPartnerUserID(Guid userID)
        {
            string sql = @"SELECT [PrivilegeID]
                                , [CategoryID]				               
				                , [PrivilegeName]
				                , [PrivilegeCode]
				                , [PageURL]
				                , [Description]
				                , [IsDisabled]
                                , [Sequence]
				                , [Created]
				                , [CreatedBy]
				                , [Modified]
				                , [ModifiedBy]				
                            FROM 
	                            [BE_Privilege]
                            WHERE
								[IsDisabled] = 0
                                AND [PrivilegeID] IN 
                                (
	                                SELECT 
		                                DISTINCT [PrivilegeID] 
	                                FROM 
									    [BE_PrivilegeItem]		                            
	                                WHERE	                            
									    [PrivilegeItemID] IN
									    (SELECT
											    DISTINCT [PrivilegeItemID]
										    FROM
											    [BE_PartnerRole2PrivilegeItem]
										    WHERE
											    [RoleID] IN
											    (SELECT
													    DISTINCT [RoleID]
												    FROM
													    [BE_PartnerUser2Role]
												    WHERE						                            
													    1 = 1
													    and [UserID] = @UserID
											    )											
									    )		                            		
                                )
                               Order By Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("UserID", userID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<Privilege> ret = new List<Privilege>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Privilege iret = new Privilege();
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.PrivilegeName = dr["PrivilegeName"].ToString();
                    iret.PrivilegeCode = dr["PrivilegeCode"].ToString();
                    iret.PageURL = dr["PageURL"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
    }
}
