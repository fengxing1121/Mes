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

        #region BE_WorkingLine InsertObject()
        public int InsertWorkingLine(WorkingLine obj)
        {
            string sql = @"INSERT INTO[BE_WorkingLine]([WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@WorkingLineID
				, @WorkingLineName
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", Convert2DBnull(obj.WorkingLineID));
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", Convert2DBnull(obj.WorkingLineName));
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

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

        #region BE_WorkingLine UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWorkingLineByWorkingLineName(WorkingLine obj)
        {
            string sql = @"UPDATE [BE_WorkingLine] SET [WorkingLineID]=@WorkingLineID
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", Convert2DBnull(obj.WorkingLineID));
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

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

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", Convert2DBnull(obj.WorkingLineName));
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateWorkingLineByWorkingLineID(WorkingLine obj)
        {
            string sql = @"UPDATE [BE_WorkingLine] SET [WorkingLineName]=@WorkingLineName
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", Convert2DBnull(obj.WorkingLineName));
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

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

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", Convert2DBnull(obj.WorkingLineID));
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLineByWorkingLineName(string workingLineName)
        {
            string sql = @"DELETE [BE_WorkingLine] WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", workingLineName);
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLineByWorkingLineID(Guid workingLineID)
        {
            string sql = @"DELETE [BE_WorkingLine] WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWorkingLineByWorkingLineName(WorkingLine obj)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", Convert2DBnull(obj.WorkingLineName));
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        obj.WorkingLineID = (Guid)dr["WorkingLineID"];
                    obj.WorkingLineName = dr["WorkingLineName"].ToString();
                    obj.Remark = dr["Remark"].ToString();
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
        public int LoadWorkingLineByWorkingLineID(WorkingLine obj)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", Convert2DBnull(obj.WorkingLineID));
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        obj.WorkingLineID = (Guid)dr["WorkingLineID"];
                    obj.WorkingLineName = dr["WorkingLineName"].ToString();
                    obj.Remark = dr["Remark"].ToString();
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

        #region BE_WorkingLine CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWorkingLines()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByWorkingLineID(Guid workingLineID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByWorkingLineName(string workingLineName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", workingLineName);
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkingLinesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWorkingLines()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WorkingLine]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByWorkingLineID(Guid workingLineID)
        {
            string sql = "SELECT TOP 1 [WorkingLineID] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByWorkingLineName(string workingLineName)
        {
            string sql = "SELECT TOP 1 [WorkingLineName] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", workingLineName);
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkingLinesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WorkingLine] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWorkingLines()
        {
            string sql = "DELETE FROM [BE_WorkingLine]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByWorkingLineID(Guid workingLineID)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByWorkingLineName(string workingLineName)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", workingLineName);
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkingLinesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WorkingLine] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WorkingLine> LoadWorkingLines()
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByWorkingLineID(Guid workingLineID)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByWorkingLineName(string workingLineName)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [WorkingLineName]=@WorkingLineName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineName = new SqlParameter("WorkingLineName", workingLineName);
            pWorkingLineName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkingLineName);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByRemark(string remark)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByCreated(DateTime created)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByModified(DateTime modified)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<WorkingLine> LoadWorkingLinesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [WorkingLineID]
				, [WorkingLineName]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkingLine] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WorkingLine> ret = new List<WorkingLine>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkingLine iret = new WorkingLine();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
                    iret.WorkingLineName = dr["WorkingLineName"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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

        #region BE_WorkingLine SearchObject()
        public SearchResult SearchWorkingLine(SearchWorkingLineArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkingLineID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
                                      [WorkingLineID]
                                      ,[WorkingLineName]
                                      ,[Remark]
                                      ,[Created]
                                      ,[CreatedBy]
                                      ,[Modified]
                                      ,[ModifiedBy]
                                  FROM 
                                     [BE_WorkingLine] with(nolock)
                                  WHERE 1=1");

            if (args.WorkingLineID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "WorkingLineID", "mbWorkingLineID", args.WorkingLineID);
            }

            if (!string.IsNullOrEmpty(args.WorkingLineName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkingLineName", "mbWorkingLineName", args.WorkingLineName);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
