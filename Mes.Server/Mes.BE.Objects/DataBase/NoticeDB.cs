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
        
        #region BE_Notice InsertObject()
        public int InsertNotice(Notice obj)
        {
            string sql = @"INSERT INTO[BE_Notice]([NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				) VALUES(@NoticeID
				, @NoticeType
				, @SourceURL
				, @TargetID
				, @Message
				, @NoticeTime
				, @IsNoticeOnSMS
				, @IsNoticeOnEmail
				, @IsRead
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", Convert2DBnull(obj.NoticeID));
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            SqlParameter pNoticeType = new SqlParameter("NoticeType", Convert2DBnull(obj.NoticeType));
            pNoticeType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pNoticeType);

            SqlParameter pSourceURL = new SqlParameter("SourceURL", Convert2DBnull(obj.SourceURL));
            pSourceURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSourceURL);

            SqlParameter pTargetID = new SqlParameter("TargetID", Convert2DBnull(obj.TargetID));
            pTargetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetID);

            SqlParameter pMessage = new SqlParameter("Message", Convert2DBnull(obj.Message));
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            SqlParameter pNoticeTime = new SqlParameter("NoticeTime", Convert2DBnull(obj.NoticeTime));
            pNoticeTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pNoticeTime);

            SqlParameter pIsNoticeOnSMS = new SqlParameter("IsNoticeOnSMS", Convert2DBnull(obj.IsNoticeOnSMS));
            pIsNoticeOnSMS.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnSMS);

            SqlParameter pIsNoticeOnEmail = new SqlParameter("IsNoticeOnEmail", Convert2DBnull(obj.IsNoticeOnEmail));
            pIsNoticeOnEmail.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnEmail);

            SqlParameter pIsRead = new SqlParameter("IsRead", Convert2DBnull(obj.IsRead));
            pIsRead.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsRead);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Notice UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateNoticeByNoticeID(Notice obj)
        {
            string sql = @"UPDATE [BE_Notice] SET [NoticeType]=@NoticeType
				, [SourceURL]=@SourceURL
				, [TargetID]=@TargetID
				, [Message]=@Message
				, [NoticeTime]=@NoticeTime
				, [IsNoticeOnSMS]=@IsNoticeOnSMS
				, [IsNoticeOnEmail]=@IsNoticeOnEmail
				, [IsRead]=@IsRead
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeType = new SqlParameter("NoticeType", Convert2DBnull(obj.NoticeType));
            pNoticeType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pNoticeType);

            SqlParameter pSourceURL = new SqlParameter("SourceURL", Convert2DBnull(obj.SourceURL));
            pSourceURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSourceURL);

            SqlParameter pTargetID = new SqlParameter("TargetID", Convert2DBnull(obj.TargetID));
            pTargetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetID);

            SqlParameter pMessage = new SqlParameter("Message", Convert2DBnull(obj.Message));
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            SqlParameter pNoticeTime = new SqlParameter("NoticeTime", Convert2DBnull(obj.NoticeTime));
            pNoticeTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pNoticeTime);

            SqlParameter pIsNoticeOnSMS = new SqlParameter("IsNoticeOnSMS", Convert2DBnull(obj.IsNoticeOnSMS));
            pIsNoticeOnSMS.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnSMS);

            SqlParameter pIsNoticeOnEmail = new SqlParameter("IsNoticeOnEmail", Convert2DBnull(obj.IsNoticeOnEmail));
            pIsNoticeOnEmail.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnEmail);

            SqlParameter pIsRead = new SqlParameter("IsRead", Convert2DBnull(obj.IsRead));
            pIsRead.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsRead);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", Convert2DBnull(obj.NoticeID));
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticeByNoticeID(Guid noticeID)
        {
            string sql = @"DELETE [BE_Notice] WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", noticeID);
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadNoticeByNoticeID(Notice obj)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
 				FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", Convert2DBnull(obj.NoticeID));
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        obj.NoticeID = (Guid)dr["NoticeID"];
                    obj.NoticeType = dr["NoticeType"].ToString();
                    obj.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        obj.TargetID = (Guid)dr["TargetID"];
                    obj.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        obj.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        obj.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        obj.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        obj.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_Notice CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountNotices()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByNoticeID(Guid noticeID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", noticeID);
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByNoticeType(string noticeType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeType]=@NoticeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeType = new SqlParameter("NoticeType", noticeType);
            pNoticeType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pNoticeType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesBySourceURL(string sourceURL)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [SourceURL]=@SourceURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceURL = new SqlParameter("SourceURL", sourceURL);
            pSourceURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSourceURL);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByTargetID(Guid targetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [TargetID]=@TargetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetID = new SqlParameter("TargetID", targetID);
            pTargetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByMessage(string message)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [Message]=@Message";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMessage = new SqlParameter("Message", message);
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByNoticeTime(DateTime noticeTime)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeTime]=@NoticeTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeTime = new SqlParameter("NoticeTime", noticeTime);
            pNoticeTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pNoticeTime);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByIsNoticeOnSMS(bool isNoticeOnSMS)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [IsNoticeOnSMS]=@IsNoticeOnSMS";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnSMS = new SqlParameter("IsNoticeOnSMS", isNoticeOnSMS);
            pIsNoticeOnSMS.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnSMS);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByIsNoticeOnEmail(bool isNoticeOnEmail)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [IsNoticeOnEmail]=@IsNoticeOnEmail";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnEmail = new SqlParameter("IsNoticeOnEmail", isNoticeOnEmail);
            pIsNoticeOnEmail.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnEmail);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByIsRead(bool isRead)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [IsRead]=@IsRead";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsRead = new SqlParameter("IsRead", isRead);
            pIsRead.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsRead);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountNoticesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Notice] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsNotices()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Notice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByNoticeID(Guid noticeID)
        {
            string sql = "SELECT TOP 1 [NoticeID] FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", noticeID);
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByNoticeType(string noticeType)
        {
            string sql = "SELECT TOP 1 [NoticeType] FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeType]=@NoticeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeType = new SqlParameter("NoticeType", noticeType);
            pNoticeType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pNoticeType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesBySourceURL(string sourceURL)
        {
            string sql = "SELECT TOP 1 [SourceURL] FROM [BE_Notice] WITH(NOLOCK) WHERE [SourceURL]=@SourceURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceURL = new SqlParameter("SourceURL", sourceURL);
            pSourceURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSourceURL);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByTargetID(Guid targetID)
        {
            string sql = "SELECT TOP 1 [TargetID] FROM [BE_Notice] WITH(NOLOCK) WHERE [TargetID]=@TargetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetID = new SqlParameter("TargetID", targetID);
            pTargetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByMessage(string message)
        {
            string sql = "SELECT TOP 1 [Message] FROM [BE_Notice] WITH(NOLOCK) WHERE [Message]=@Message";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMessage = new SqlParameter("Message", message);
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByNoticeTime(DateTime noticeTime)
        {
            string sql = "SELECT TOP 1 [NoticeTime] FROM [BE_Notice] WITH(NOLOCK) WHERE [NoticeTime]=@NoticeTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeTime = new SqlParameter("NoticeTime", noticeTime);
            pNoticeTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pNoticeTime);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByIsNoticeOnSMS(bool isNoticeOnSMS)
        {
            string sql = "SELECT TOP 1 [IsNoticeOnSMS] FROM [BE_Notice] WITH(NOLOCK) WHERE [IsNoticeOnSMS]=@IsNoticeOnSMS";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnSMS = new SqlParameter("IsNoticeOnSMS", isNoticeOnSMS);
            pIsNoticeOnSMS.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnSMS);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByIsNoticeOnEmail(bool isNoticeOnEmail)
        {
            string sql = "SELECT TOP 1 [IsNoticeOnEmail] FROM [BE_Notice] WITH(NOLOCK) WHERE [IsNoticeOnEmail]=@IsNoticeOnEmail";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnEmail = new SqlParameter("IsNoticeOnEmail", isNoticeOnEmail);
            pIsNoticeOnEmail.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnEmail);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByIsRead(bool isRead)
        {
            string sql = "SELECT TOP 1 [IsRead] FROM [BE_Notice] WITH(NOLOCK) WHERE [IsRead]=@IsRead";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsRead = new SqlParameter("IsRead", isRead);
            pIsRead.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsRead);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Notice] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsNoticesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Notice] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteNotices()
        {
            string sql = "DELETE FROM [BE_Notice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByNoticeID(Guid noticeID)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", noticeID);
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByNoticeType(string noticeType)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [NoticeType]=@NoticeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeType = new SqlParameter("NoticeType", noticeType);
            pNoticeType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pNoticeType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesBySourceURL(string sourceURL)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [SourceURL]=@SourceURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceURL = new SqlParameter("SourceURL", sourceURL);
            pSourceURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSourceURL);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByTargetID(Guid targetID)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [TargetID]=@TargetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetID = new SqlParameter("TargetID", targetID);
            pTargetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByMessage(string message)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [Message]=@Message";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMessage = new SqlParameter("Message", message);
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByNoticeTime(DateTime noticeTime)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [NoticeTime]=@NoticeTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeTime = new SqlParameter("NoticeTime", noticeTime);
            pNoticeTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pNoticeTime);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByIsNoticeOnSMS(bool isNoticeOnSMS)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [IsNoticeOnSMS]=@IsNoticeOnSMS";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnSMS = new SqlParameter("IsNoticeOnSMS", isNoticeOnSMS);
            pIsNoticeOnSMS.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnSMS);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByIsNoticeOnEmail(bool isNoticeOnEmail)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [IsNoticeOnEmail]=@IsNoticeOnEmail";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnEmail = new SqlParameter("IsNoticeOnEmail", isNoticeOnEmail);
            pIsNoticeOnEmail.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnEmail);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByIsRead(bool isRead)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [IsRead]=@IsRead";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsRead = new SqlParameter("IsRead", isRead);
            pIsRead.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsRead);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteNoticesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Notice] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Notice> LoadNotices()
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByNoticeID(Guid noticeID)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [NoticeID]=@NoticeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeID = new SqlParameter("NoticeID", noticeID);
            pNoticeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pNoticeID);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByNoticeType(string noticeType)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [NoticeType]=@NoticeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeType = new SqlParameter("NoticeType", noticeType);
            pNoticeType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pNoticeType);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesBySourceURL(string sourceURL)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [SourceURL]=@SourceURL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceURL = new SqlParameter("SourceURL", sourceURL);
            pSourceURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSourceURL);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByTargetID(Guid targetID)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [TargetID]=@TargetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetID = new SqlParameter("TargetID", targetID);
            pTargetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetID);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByMessage(string message)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [Message]=@Message";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMessage = new SqlParameter("Message", message);
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByNoticeTime(DateTime noticeTime)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [NoticeTime]=@NoticeTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pNoticeTime = new SqlParameter("NoticeTime", noticeTime);
            pNoticeTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pNoticeTime);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByIsNoticeOnSMS(bool isNoticeOnSMS)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [IsNoticeOnSMS]=@IsNoticeOnSMS";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnSMS = new SqlParameter("IsNoticeOnSMS", isNoticeOnSMS);
            pIsNoticeOnSMS.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnSMS);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByIsNoticeOnEmail(bool isNoticeOnEmail)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [IsNoticeOnEmail]=@IsNoticeOnEmail";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsNoticeOnEmail = new SqlParameter("IsNoticeOnEmail", isNoticeOnEmail);
            pIsNoticeOnEmail.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsNoticeOnEmail);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByIsRead(bool isRead)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [IsRead]=@IsRead";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsRead = new SqlParameter("IsRead", isRead);
            pIsRead.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsRead);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByCreated(DateTime created)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Notice> LoadNoticesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [NoticeID]
				, [NoticeType]
				, [SourceURL]
				, [TargetID]
				, [Message]
				, [NoticeTime]
				, [IsNoticeOnSMS]
				, [IsNoticeOnEmail]
				, [IsRead]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Notice] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Notice> ret = new List<Notice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Notice iret = new Notice();
                    if (!Convert.IsDBNull(dr["NoticeID"]))
                        iret.NoticeID = (Guid)dr["NoticeID"];
                    iret.NoticeType = dr["NoticeType"].ToString();
                    iret.SourceURL = dr["SourceURL"].ToString();
                    if (!Convert.IsDBNull(dr["TargetID"]))
                        iret.TargetID = (Guid)dr["TargetID"];
                    iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["NoticeTime"]))
                        iret.NoticeTime = (DateTime)dr["NoticeTime"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnSMS"]))
                        iret.IsNoticeOnSMS = (bool)dr["IsNoticeOnSMS"];
                    if (!Convert.IsDBNull(dr["IsNoticeOnEmail"]))
                        iret.IsNoticeOnEmail = (bool)dr["IsNoticeOnEmail"];
                    if (!Convert.IsDBNull(dr["IsRead"]))
                        iret.IsRead = (bool)dr["IsRead"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_Notices SearchObject()
        public SearchResult SearchNotices(SearchNoticeArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Created] DESC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [NoticeID]                                      
                                        ,[SourceURL]
                                        ,[TargetID]
                                        ,[NoticeType]
                                        ,[Message]
                                        ,[NoticeTime]
                                        ,[IsNoticeOnSMS]
                                        ,[IsNoticeOnEmail]
                                        ,[IsRead]
                                        ,[Created]
                                        ,[CreatedBy]
                                    FROM [BE_Notice] with(nolock)
	                                WHERE 1=1");
            if (args.NoticeID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "NoticeID", "mbNoticeID", args.NoticeID);
            }

            if (!string.IsNullOrEmpty(args.TargetID))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "TargetID", "mbTargetID", args.TargetID);
            }
            if (args.IsRead.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsRead", "mbIsRead", args.IsRead.Value);
            }

            this.SetParameters_Between(mbBuilder, cmd, "NoticeTime", "mbNoticeTime", args.NoticeTimeFrom, args.NoticeTimeTo);
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
