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
       
        #region BE_SolutionFile InsertObject()
        public int InsertSolutionFile(SolutionFile obj)
        {
            string sql = @"INSERT INTO[BE_SolutionFile]([FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@FileID
				, @SolutionID
				, @SourceID
				, @SourceType
				, @FileName
				, @FileUrl
				, @Status
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pSourceID = new SqlParameter("SourceID", Convert2DBnull(obj.SourceID));
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            SqlParameter pSourceType = new SqlParameter("SourceType", Convert2DBnull(obj.SourceType));
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", Convert2DBnull(obj.FileUrl));
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

        #region BE_SolutionFile UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSolutionFileBySourceID(SolutionFile obj)
        {
            string sql = @"UPDATE [BE_SolutionFile] SET [FileID]=@FileID
				, [SolutionID]=@SolutionID
				, [SourceType]=@SourceType
				, [FileName]=@FileName
				, [FileUrl]=@FileUrl
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pSourceType = new SqlParameter("SourceType", Convert2DBnull(obj.SourceType));
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", Convert2DBnull(obj.FileUrl));
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

            SqlParameter pSourceID = new SqlParameter("SourceID", Convert2DBnull(obj.SourceID));
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateSolutionFileByFileID(SolutionFile obj)
        {
            string sql = @"UPDATE [BE_SolutionFile] SET [SolutionID]=@SolutionID
				, [SourceID]=@SourceID
				, [SourceType]=@SourceType
				, [FileName]=@FileName
				, [FileUrl]=@FileUrl
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pSourceID = new SqlParameter("SourceID", Convert2DBnull(obj.SourceID));
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            SqlParameter pSourceType = new SqlParameter("SourceType", Convert2DBnull(obj.SourceType));
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", Convert2DBnull(obj.FileUrl));
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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
        public int DeleteSolutionFileBySourceID(Guid sourceID)
        {
            string sql = @"DELETE [BE_SolutionFile] WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFileByFileID(Guid fileID)
        {
            string sql = @"DELETE [BE_SolutionFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSolutionFileBySourceID(SolutionFile obj)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", Convert2DBnull(obj.SourceID));
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["FileID"]))
                        obj.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        obj.SourceID = (Guid)dr["SourceID"];
                    obj.SourceType = dr["SourceType"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.FileUrl = dr["FileUrl"].ToString();
                    obj.Status = dr["Status"].ToString();
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
        public int LoadSolutionFileByFileID(SolutionFile obj)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
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
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        obj.SourceID = (Guid)dr["SourceID"];
                    obj.SourceType = dr["SourceType"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.FileUrl = dr["FileUrl"].ToString();
                    obj.Status = dr["Status"].ToString();
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

        #region BE_SolutionFile CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSolutionFiles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByFileID(Guid fileID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesBySourceID(Guid sourceID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesBySourceType(string sourceType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SourceType]=@SourceType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceType = new SqlParameter("SourceType", sourceType);
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByFileName(string fileName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByFileUrl(string fileUrl)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileUrl]=@FileUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", fileUrl);
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByStatus(string status)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSolutionFiles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_SolutionFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByFileID(Guid fileID)
        {
            string sql = "SELECT TOP 1 [FileID] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesBySourceID(Guid sourceID)
        {
            string sql = "SELECT TOP 1 [SourceID] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesBySourceType(string sourceType)
        {
            string sql = "SELECT TOP 1 [SourceType] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [SourceType]=@SourceType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceType = new SqlParameter("SourceType", sourceType);
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByFileName(string fileName)
        {
            string sql = "SELECT TOP 1 [FileName] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByFileUrl(string fileUrl)
        {
            string sql = "SELECT TOP 1 [FileUrl] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [FileUrl]=@FileUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", fileUrl);
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByStatus(string status)
        {
            string sql = "SELECT TOP 1 [Status] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_SolutionFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSolutionFiles()
        {
            string sql = "DELETE FROM [BE_SolutionFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByFileID(Guid fileID)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesBySourceID(Guid sourceID)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesBySourceType(string sourceType)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [SourceType]=@SourceType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceType = new SqlParameter("SourceType", sourceType);
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByFileName(string fileName)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByFileUrl(string fileUrl)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [FileUrl]=@FileUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", fileUrl);
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByStatus(string status)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionFilesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_SolutionFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<SolutionFile> LoadSolutionFiles()
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByFileID(Guid fileID)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesBySourceID(Guid sourceID)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesBySourceType(string sourceType)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [SourceType]=@SourceType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceType = new SqlParameter("SourceType", sourceType);
            pSourceType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pSourceType);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByFileName(string fileName)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByFileUrl(string fileUrl)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [FileUrl]=@FileUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUrl = new SqlParameter("FileUrl", fileUrl);
            pFileUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileUrl);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByStatus(string status)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByCreated(DateTime created)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByModified(DateTime modified)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<SolutionFile> LoadSolutionFilesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [FileID]
				, [SolutionID]
				, [SourceID]
				, [SourceType]
				, [FileName]
				, [FileUrl]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<SolutionFile> ret = new List<SolutionFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionFile iret = new SolutionFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.SourceType = dr["SourceType"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.FileUrl = dr["FileUrl"].ToString();
                    iret.Status = dr["Status"].ToString();
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

        #region BE_SolutionFile SearchObject()
        public SearchResult SearchSolutionFile(SearchSolutionFileArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[FileID] ASC,[Created] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
								      [BE_SolutionFile].[SolutionID]
									  ,[BE_SolutionFile].[FileID]
                                      ,[BE_SolutionFile].[SourceID]
                                      ,[BE_SolutionFile].[SourceType]
                                      ,[BE_SolutionFile].[FileName]
                                      ,[BE_SolutionFile].[FileUrl]
                                      ,[BE_SolutionFile].[Status]
                                      ,[BE_SolutionFile].[Created]
                                      ,[BE_SolutionFile].[CreatedBy]
                                      ,[BE_SolutionFile].[Modified]
                                      ,[BE_SolutionFile].[ModifiedBy]
									  ,[BE_Solution].[SolutionCode]
									  ,[BE_Solution].[SolutionName]
                                  FROM 
                                      [BE_SolutionFile] with(nolock)	                                 
	                                  LEFT JOIN [BE_Solution] with(nolock) on [BE_Solution].[SolutionID] = [BE_SolutionFile].[SolutionID]
                                   WHERE 1=1");

            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_SolutionFile].[SolutionID", "mbSolutionID", args.SolutionID);
            }
            if (args.FileID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "FileID", "mbFileID", args.FileID);
            }
            if (!string.IsNullOrEmpty(args.FileName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "FileName", "mbFileName", args.FileName);
            }
            if (!string.IsNullOrEmpty(args.SourceType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SourceType", "mbSourceType", args.SourceType);
            }
            if (!string.IsNullOrEmpty(args.Status))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_SolutionFile].[Status", "mbStatus", args.Status);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_SolutionFile].[CabinetID", "mbCabinetID", args.CabinetID);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
