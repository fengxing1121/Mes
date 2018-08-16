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
     
        #region BE_OrderProcessFile InsertObject()
        public int InsertOrderProcessFile(OrderProcessFile obj)
        {
            string sql = @"INSERT INTO[BE_OrderProcessFile]([FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@FileID
				, @FileType
				, @Tag
				, @OrderID
				, @CabinetID
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

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pTag = new SqlParameter("Tag", Convert2DBnull(obj.Tag));
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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

        #region BE_OrderProcessFile UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrderProcessFileByFileType_OrderID_FileName(OrderProcessFile obj)
        {
            string sql = @"UPDATE [BE_OrderProcessFile] SET [FileID]=@FileID
				, [Tag]=@Tag
				, [CabinetID]=@CabinetID
				, [FilePath]=@FilePath
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FileType]=@FileType AND [OrderID]=@OrderID AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pTag = new SqlParameter("Tag", Convert2DBnull(obj.Tag));
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderProcessFileByFileID(OrderProcessFile obj)
        {
            string sql = @"UPDATE [BE_OrderProcessFile] SET [FileType]=@FileType
				, [Tag]=@Tag
				, [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
				, [FileName]=@FileName
				, [FilePath]=@FilePath
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pTag = new SqlParameter("Tag", Convert2DBnull(obj.Tag));
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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
        public int DeleteOrderProcessFileByFileType_OrderID_FileName(string fileType, Guid orderID, string fileName)
        {
            string sql = @"DELETE [BE_OrderProcessFile] WHERE [FileType]=@FileType AND [OrderID]=@OrderID AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFileByFileID(Guid fileID)
        {
            string sql = @"DELETE [BE_OrderProcessFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrderProcessFileByFileType_OrderID_FileName(OrderProcessFile obj)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileType]=@FileType AND [OrderID]=@OrderID AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

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
                    obj.FileType = dr["FileType"].ToString();
                    obj.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
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
        public int LoadOrderProcessFileByFileID(OrderProcessFile obj)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
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
                    obj.FileType = dr["FileType"].ToString();
                    obj.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
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

        #region BE_OrderProcessFile CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrderProcessFiles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByFileID(Guid fileID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByFileType(string fileType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByTag(string tag)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByFileName(string fileName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByFilePath(string filePath)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrderProcessFiles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_OrderProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByFileID(Guid fileID)
        {
            string sql = "SELECT TOP 1 [FileID] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByFileType(string fileType)
        {
            string sql = "SELECT TOP 1 [FileType] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByTag(string tag)
        {
            string sql = "SELECT TOP 1 [Tag] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByFileName(string fileName)
        {
            string sql = "SELECT TOP 1 [FileName] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByFilePath(string filePath)
        {
            string sql = "SELECT TOP 1 [FilePath] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_OrderProcessFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrderProcessFiles()
        {
            string sql = "DELETE FROM [BE_OrderProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByFileID(Guid fileID)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByFileType(string fileType)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByTag(string tag)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByFileName(string fileName)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByFilePath(string filePath)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_OrderProcessFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<OrderProcessFile> LoadOrderProcessFiles()
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByFileID(Guid fileID)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByFileType(string fileType)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByTag(string tag)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [Tag]=@Tag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTag = new SqlParameter("Tag", tag);
            pTag.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTag);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByOrderID(Guid orderID)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByFileName(string fileName)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByFilePath(string filePath)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByCreated(DateTime created)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByModified(DateTime modified)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<OrderProcessFile> LoadOrderProcessFilesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [FileID]
				, [FileType]
				, [Tag]
				, [OrderID]
				, [CabinetID]
				, [FileName]
				, [FilePath]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderProcessFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<OrderProcessFile> ret = new List<OrderProcessFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProcessFile iret = new OrderProcessFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.Tag = dr["Tag"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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

        #region BE_OrderProcessFile SearchObject()
        public SearchResult SearchOrderProcessFile(SearchOrderProcessFileArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[FileType] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [FileID]
                                        ,[FileType]
                                        ,[Tag]
                                        ,[BE_OrderProcessFile].[OrderID]
                                        ,[BE_OrderProcessFile].[CabinetID]
                                        ,[FileName]
                                        ,[FilePath]
                                        ,[BE_OrderProcessFile].[Created]
                                        ,[BE_OrderProcessFile].[CreatedBy]
                                        ,[BE_OrderProcessFile].[Modified]
                                        ,[BE_OrderProcessFile].[ModifiedBy]
										,[CabinetName]
                                    FROM 
										[BE_OrderProcessFile] with(nolock)
										LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_OrderProcessFile].[CabinetID] = [BE_Order2Cabinet].[CabinetID]
										LEFT JOIN [BE_Order] with(nolock) on [BE_OrderProcessFile].[OrderID]=[BE_Order].[OrderID]
	                                WHERE 1=1");
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderProcessFile].[OrderID", "mbCabinetID", args.OrderID);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderProcessFile].[CabinetID", "mbCabinetID", args.CabinetID);
            }

            this.SetParameters_In(mbBuilder, cmd, "FileType", "mbFileType", args.FileType);

            if (!string.IsNullOrEmpty(args.CabinetName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetName);
            }
            if (!string.IsNullOrEmpty(args.Tag))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Tag", "mbTag", args.Tag);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.BattchNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchNum", "mbBattchNum", args.BattchNum);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
