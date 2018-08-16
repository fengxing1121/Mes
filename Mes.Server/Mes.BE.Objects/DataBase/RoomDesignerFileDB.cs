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
        #region BE_RoomDesignerFile InsertObject()
        public int InsertRoomDesignerFile(RoomDesignerFile obj)
        {
            string sql = @"INSERT INTO[BE_RoomDesignerFile]([FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@FileID
				, @DesignerID
				, @Title
				, @FileName
				, @Remark
				, @FileURL
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", Convert2DBnull(obj.FileID));
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            SqlParameter pTitle = new SqlParameter("Title", Convert2DBnull(obj.Title));
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pFileURL = new SqlParameter("FileURL", Convert2DBnull(obj.FileURL));
            pFileURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileURL);

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

        #region BE_RoomDesignerFile UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateRoomDesignerFileByFileID(RoomDesignerFile obj)
        {
            string sql = @"UPDATE [BE_RoomDesignerFile] SET [DesignerID]=@DesignerID
				, [Title]=@Title
				, [FileName]=@FileName
				, [Remark]=@Remark
				, [FileURL]=@FileURL
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            SqlParameter pTitle = new SqlParameter("Title", Convert2DBnull(obj.Title));
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            SqlParameter pFileName = new SqlParameter("FileName", Convert2DBnull(obj.FileName));
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pFileURL = new SqlParameter("FileURL", Convert2DBnull(obj.FileURL));
            pFileURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileURL);

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
        public int DeleteRoomDesignerFileByFileID(Guid fileID)
        {
            string sql = @"DELETE [BE_RoomDesignerFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadRoomDesignerFileByFileID(RoomDesignerFile obj)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
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
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        obj.DesignerID = (Guid)dr["DesignerID"];
                    obj.Title = dr["Title"].ToString();
                    obj.FileName = dr["FileName"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.FileURL = dr["FileURL"].ToString();
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

        #region BE_RoomDesignerFile CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountRoomDesignerFiles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByFileID(Guid fileID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByDesignerID(Guid designerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByTitle(string title)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByFileName(string fileName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByFileURL(string fileURL)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileURL]=@FileURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileURL = new SqlParameter("FileURL", fileURL);
            pFileURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileURL);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignerFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsRoomDesignerFiles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_RoomDesignerFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByFileID(Guid fileID)
        {
            string sql = "SELECT TOP 1 [FileID] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByDesignerID(Guid designerID)
        {
            string sql = "SELECT TOP 1 [DesignerID] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByTitle(string title)
        {
            string sql = "SELECT TOP 1 [Title] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByFileName(string fileName)
        {
            string sql = "SELECT TOP 1 [FileName] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByFileURL(string fileURL)
        {
            string sql = "SELECT TOP 1 [FileURL] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [FileURL]=@FileURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileURL = new SqlParameter("FileURL", fileURL);
            pFileURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileURL);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignerFilesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_RoomDesignerFile] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteRoomDesignerFiles()
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByFileID(Guid fileID)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByDesignerID(Guid designerID)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByTitle(string title)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByFileName(string fileName)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByFileURL(string fileURL)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [FileURL]=@FileURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileURL = new SqlParameter("FileURL", fileURL);
            pFileURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileURL);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerFilesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_RoomDesignerFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<RoomDesignerFile> LoadRoomDesignerFiles()
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByFileID(Guid fileID)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [FileID]=@FileID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileID = new SqlParameter("FileID", fileID);
            pFileID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFileID);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByDesignerID(Guid designerID)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByTitle(string title)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByFileName(string fileName)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [FileName]=@FileName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileName = new SqlParameter("FileName", fileName);
            pFileName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileName);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByRemark(string remark)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByFileURL(string fileURL)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [FileURL]=@FileURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileURL = new SqlParameter("FileURL", fileURL);
            pFileURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFileURL);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByCreated(DateTime created)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByModified(DateTime modified)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
        public List<RoomDesignerFile> LoadRoomDesignerFilesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [FileID]
				, [DesignerID]
				, [Title]
				, [FileName]
				, [Remark]
				, [FileURL]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesignerFile] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<RoomDesignerFile> ret = new List<RoomDesignerFile>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesignerFile iret = new RoomDesignerFile();
                    if (!Convert.IsDBNull(dr["FileID"]))
                        iret.FileID = (Guid)dr["FileID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    iret.Title = dr["Title"].ToString();
                    iret.FileName = dr["FileName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.FileURL = dr["FileURL"].ToString();
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
