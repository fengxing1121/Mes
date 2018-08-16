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

        #region BE_ProductProcessFile InsertObject()
        public int InsertProductProcessFile(ProductProcessFile obj)
        {
            string sql = @"INSERT INTO[BE_ProductProcessFile]([FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@FileID
				, @ProductID
				, @FileType
				, @Tag
				, @FileName
				, @FilePath
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pTag = new SqlParameter("Tag", Convert2DBnull(obj.Tag));
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFilePath = new SqlParameter("FilePath", Convert2DBnull(obj.FilePath));
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

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

        #region BE_ProductProcessFile UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateProductProcessFileByProductID_FileType_FileName(ProductProcessFile obj)
        {
            string sql = @"UPDATE [BE_ProductProcessFile] SET [FileID]=@FileID
				, [Tag]=@Tag
				, [FilePath]=@FilePath
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ProductID]=@ProductID AND [FileType]=@FileType AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pTag = new SqlParameter("Tag", Convert2DBnull(obj.Tag));
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            SqlParameter pFilePath = new SqlParameter("FilePath", Convert2DBnull(obj.FilePath));
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

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

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateProductProcessFileByFileID(ProductProcessFile obj)
        {
            string sql = @"UPDATE [BE_ProductProcessFile] SET [ProductID]=@ProductID
				, [FileType]=@FileType
				, [Tag]=@Tag
				, [FileName]=@FileName
				, [FilePath]=@FilePath
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pTag = new SqlParameter("Tag", Convert2DBnull(obj.Tag));
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFilePath = new SqlParameter("FilePath", Convert2DBnull(obj.FilePath));
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

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

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFileByProductID_FileType_FileName(Guid productID, string fileType, string fileName)
        {
            string sql = @"DELETE [BE_ProductProcessFile] WHERE [ProductID]=@ProductID AND [FileType]=@FileType AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFileByFileID(Guid fileID)
        {
            string sql = @"DELETE [BE_ProductProcessFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadProductProcessFileByProductID_FileType_FileName(ProductProcessFile obj)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [ProductID]=@ProductID AND [FileType]=@FileType AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["FileID"]))
                        obj.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    obj.FileType = dr["FileType"].ToString();
                    obj.Tag = dr["Tag"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.FilePath = dr["FilePath"].ToString();
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
        public int LoadProductProcessFileByFileID(ProductProcessFile obj)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["FileID"]))
                        obj.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    obj.FileType = dr["FileType"].ToString();
                    obj.Tag = dr["Tag"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.FilePath = dr["FilePath"].ToString();
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

        #region BE_ProductProcessFile CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountProductProcessFiles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByFileID(Guid fileID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByProductID(Guid productID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByFileType(string fileType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByTag(string tag)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByFileName(string fileName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByFilePath(string filePath)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsProductProcessFiles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_ProductProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByFileID(Guid fileID)
        {
            string sql = "SELECT TOP 1 [FileID] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByProductID(Guid productID)
        {
            string sql = "SELECT TOP 1 [ProductID] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByFileType(string fileType)
        {
            string sql = "SELECT TOP 1 [FileType] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByTag(string tag)
        {
            string sql = "SELECT TOP 1 [Tag] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByFileName(string fileName)
        {
            string sql = "SELECT TOP 1 [FileName] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByFilePath(string filePath)
        {
            string sql = "SELECT TOP 1 [FilePath] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_ProductProcessFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteProductProcessFiles()
        {
            string sql = "DELETE FROM [BE_ProductProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByFileID(Guid fileID)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByProductID(Guid productID)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByFileType(string fileType)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByTag(string tag)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByFileName(string fileName)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByFilePath(string filePath)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_ProductProcessFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<ProductProcessFile> LoadProductProcessFiles()
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByFileID(Guid fileID)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByProductID(Guid productID)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByFileType(string fileType)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByTag(string tag)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByFileName(string fileName)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByFilePath(string filePath)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByCreated(DateTime created)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByModified(DateTime modified)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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
        public List<ProductProcessFile> LoadProductProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [FileID]
				, [ProductID]
				, [FileType]
				, [Tag]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductProcessFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<ProductProcessFile> ret = new List<ProductProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductProcessFile iret = new ProductProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
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

        #region BE_ProductProcessFile SearchObject()
        public SearchResult SearchProductProcessFile(SearchProductProcessFileArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CategoryID] ASC,[ProductCode]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
                                            [BE_ProductMain].[ProductID]                                       
                                            ,[BE_ProductMain].[CategoryID]
                                            ,[BE_Category].[CategoryName]
                                            ,[ProductCode]
                                            ,[ProductName]
                                            ,[Size]
                                            ,[Color]
                                            ,[MaterialStyle]
                                            ,[MaterialCategory]
                                            ,[Price]
                                            ,[FileID]
                                            ,[BE_ProductProcessFile].[ProductID]
                                            ,[FileType]
                                            ,[Tag]
                                            ,[FileName]
                                            ,[FilePath]
                                            ,[BE_ProductProcessFile].[Created]
                                            ,[BE_ProductProcessFile].[CreatedBy]
                                            ,[BE_ProductProcessFile].[Modified]
                                            ,[BE_ProductProcessFile].[ModifiedBy]
                                        FROM 
                                            [BE_ProductProcessFile] with(nolock)
                                            LEFT JOIN [BE_ProductMain] with(nolock) on [BE_ProductProcessFile].[ProductID] = [BE_ProductMain].[ProductID]
                                            LEFT JOIN [BE_Category] with(nolock)  with(nolock) on [BE_ProductMain].[CategoryID] = [BE_Category].[CategoryID]
                                        WHERE 1=1");


            if (args.ProductID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductMain].[ProductID", "mbProductID", args.ProductID.Value);
            }
            if (!string.IsNullOrEmpty(args.ProductCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ProductCode", "mbProductCode", args.ProductCode);
            }
            if (!string.IsNullOrEmpty(args.CategoryName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CategoryName", "mbCategoryName", args.CategoryName);
            }
            if (!string.IsNullOrEmpty(args.ProductName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_ProductMain].[ProductName", "mbProductName", args.ProductName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_ProductMain].[Color", "mbColor", args.Color);
            }

            if (!string.IsNullOrEmpty(args.Size))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_ProductMain].[Size", "mbSize", args.Size);
            }

            if (!string.IsNullOrEmpty(args.MaterialCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialCategory", "mbMaterialCategory", args.MaterialCategory);
            }
            if (!string.IsNullOrEmpty(args.MaterialStyle))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialStyle", "mbMaterialStyle", args.MaterialStyle);
            }
            this.SetParameters_Between(mbBuilder, cmd, "Price", "mbPrice", args.MinPrice, args.MaxPrice);
            if (args.ItemID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "ItemID", "mbItemID", args.ItemID.Value);
            }
            if (!string.IsNullOrEmpty(args.FileType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "FileType", "mbFileType", args.FileType);
            }
            if (!string.IsNullOrEmpty(args.Tag))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Tag", "mbTag", args.Tag);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
