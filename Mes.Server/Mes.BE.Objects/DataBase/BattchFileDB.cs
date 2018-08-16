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

        #region BE_BattchFile InsertObject()
        public int InsertBattchFile(BattchFile obj)
        {
            string sql = @"INSERT INTO[BE_BattchFile]([FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@FileID
				, @BattchNum
				, @DeviceID
				, @FileType
				, @FileName
				, @FilePath
				, @IsDownload
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", Convert2DBnull(obj.DeviceID));
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFilePath = new SqlParameter("FilePath", Convert2DBnull(obj.FilePath));
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", Convert2DBnull(obj.IsDownload));
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

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

        #region BE_BattchFile UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateBattchFileByBattchNum_FileName(BattchFile obj)
        {
            string sql = @"UPDATE [BE_BattchFile] SET [FileID]=@FileID
				, [DeviceID]=@DeviceID
				, [FileType]=@FileType
				, [FilePath]=@FilePath
				, [IsDownload]=@IsDownload
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [BattchNum]=@BattchNum AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", Convert2DBnull(obj.DeviceID));
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pFilePath = new SqlParameter("FilePath", Convert2DBnull(obj.FilePath));
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", Convert2DBnull(obj.IsDownload));
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

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

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateBattchFileByFileID(BattchFile obj)
        {
            string sql = @"UPDATE [BE_BattchFile] SET [BattchNum]=@BattchNum
				, [DeviceID]=@DeviceID
				, [FileType]=@FileType
				, [FileName]=@FileName
				, [FilePath]=@FilePath
				, [IsDownload]=@IsDownload
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", Convert2DBnull(obj.DeviceID));
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            SqlParameter pFileType = new SqlParameter("FileType", Convert2DBnull(obj.FileType));
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFilePath = new SqlParameter("FilePath", Convert2DBnull(obj.FilePath));
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", Convert2DBnull(obj.IsDownload));
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

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
        public int DeleteBattchFileByBattchNum_FileName(string battchNum, string fileName)
        {
            string sql = @"DELETE [BE_BattchFile] WHERE [BattchNum]=@BattchNum AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFileByFileID(Guid fileID)
        {
            string sql = @"DELETE [BE_BattchFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadBattchFileByBattchNum_FileName(BattchFile obj)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_BattchFile] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum AND [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

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
                    obj.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        obj.DeviceID = (Guid)dr["DeviceID"];
                    obj.FileType = dr["FileType"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        obj.IsDownload = (bool)dr["IsDownload"];
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
        public int LoadBattchFileByFileID(BattchFile obj)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
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
                    obj.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        obj.DeviceID = (Guid)dr["DeviceID"];
                    obj.FileType = dr["FileType"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        obj.IsDownload = (bool)dr["IsDownload"];
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

        #region BE_BattchFile CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountBattchFiles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByFileID(Guid fileID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByBattchNum(string battchNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByDeviceID(Guid deviceID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [DeviceID]=@DeviceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", deviceID);
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByFileType(string fileType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByFileName(string fileName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByFilePath(string filePath)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByIsDownload(bool isDownload)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [IsDownload]=@IsDownload";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", isDownload);
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountBattchFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_BattchFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsBattchFiles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_BattchFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByFileID(Guid fileID)
        {
            string sql = "SELECT TOP 1 [FileID] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByBattchNum(string battchNum)
        {
            string sql = "SELECT TOP 1 [BattchNum] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByDeviceID(Guid deviceID)
        {
            string sql = "SELECT TOP 1 [DeviceID] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [DeviceID]=@DeviceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", deviceID);
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByFileType(string fileType)
        {
            string sql = "SELECT TOP 1 [FileType] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByFileName(string fileName)
        {
            string sql = "SELECT TOP 1 [FileName] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByFilePath(string filePath)
        {
            string sql = "SELECT TOP 1 [FilePath] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByIsDownload(bool isDownload)
        {
            string sql = "SELECT TOP 1 [IsDownload] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [IsDownload]=@IsDownload";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", isDownload);
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsBattchFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_BattchFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteBattchFiles()
        {
            string sql = "DELETE FROM [BE_BattchFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByFileID(Guid fileID)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByBattchNum(string battchNum)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByDeviceID(Guid deviceID)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [DeviceID]=@DeviceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", deviceID);
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByFileType(string fileType)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByFileName(string fileName)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByFilePath(string filePath)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByIsDownload(bool isDownload)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [IsDownload]=@IsDownload";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", isDownload);
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteBattchFilesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_BattchFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<BattchFile> LoadBattchFiles()
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByFileID(Guid fileID)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByBattchNum(string battchNum)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByDeviceID(Guid deviceID)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [DeviceID]=@DeviceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeviceID = new SqlParameter("DeviceID", deviceID);
            pDeviceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDeviceID);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByFileType(string fileType)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [FileType]=@FileType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileType = new SqlParameter("FileType", fileType);
            pFileType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileType);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByFileName(string fileName)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByFilePath(string filePath)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [FilePath]=@FilePath";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFilePath = new SqlParameter("FilePath", filePath);
            pFilePath.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFilePath);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByIsDownload(bool isDownload)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [IsDownload]=@IsDownload";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDownload = new SqlParameter("IsDownload", isDownload);
            pIsDownload.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDownload);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByCreated(DateTime created)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByModified(DateTime modified)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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
        public List<BattchFile> LoadBattchFilesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [FileID]
				, [BattchNum]
				, [DeviceID]
				, [FileType]
				, [FileName]
				, [FilePath]
				, [IsDownload]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_BattchFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<BattchFile> ret = new List<BattchFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    BattchFile iret = new BattchFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["DeviceID"]))
                        iret.DeviceID = (Guid)dr["DeviceID"];
                    iret.FileType = dr["FileType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FilePath = dr["FilePath"].ToString();
                    if (!Convert.IsDBNull(dr["IsDownload"]))
                        iret.IsDownload = (bool)dr["IsDownload"];
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

        #region BE_BattchFile SearchObject()
        public SearchResult SearchBattchFile(SearchBattchFileArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkingLineID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_BattchFile].[FileID]
                                          ,[BE_BattchFile].[BattchNum]
                                          ,[BE_BattchFile].[DeviceID]
                                          ,[BE_BattchFile].[FileType]
                                          ,[BE_BattchFile].[FileName]
                                          ,[BE_BattchFile].[FilePath]
                                          ,[BE_BattchFile].[IsDownload]
                                          ,[BE_BattchFile].[Created]
                                          ,[BE_BattchFile].[CreatedBy]
                                          ,[BE_BattchFile].[Modified]
                                          ,[BE_BattchFile].[ModifiedBy]
	                                      ,[BE_WorkCenter].[WorkCenterCode]
	                                      ,[BE_WorkCenter].[WorkCenterName]
                                      FROM [BE_BattchFile] with(nolock)
                                      LEFT JOIN [BE_WorkCenter] with(nolock) on [BE_BattchFile].[DeviceID]=[BE_WorkCenter].[WorkCenterID]
                                  WHERE 1=1");

            if (args.WorkingLineID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_BattchFile].[WorkingLineID", "mbWorkingLineID", args.WorkingLineID);
            }
            if (args.FileID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_BattchFile].[FileID", "mbFileID", args.FileID);
            }
            if (args.IsDownload.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_BattchFile].[IsDownload", "mbIsDownload", args.IsDownload);
            }
            if (!string.IsNullOrEmpty(args.WorkCenterName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkCenterName", "mbWorkCenterName", args.WorkCenterName);
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
