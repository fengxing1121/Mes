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
      
        #region BE_WorkShop InsertObject()
        public int InsertWorkShop(WorkShop obj)
        {
            string sql = @"INSERT INTO[BE_WorkShop]([WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@WorkShopID
				, @WorkShopCode
				, @WorkShopName
				, @WorkingLineID
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", Convert2DBnull(obj.WorkShopCode));
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", Convert2DBnull(obj.WorkShopName));
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

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

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkShop UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWorkShopByWorkShopCode(WorkShop obj)
        {
            string sql = @"UPDATE [BE_WorkShop] SET [WorkShopID]=@WorkShopID
				, [WorkShopName]=@WorkShopName
				, [WorkingLineID]=@WorkingLineID
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", Convert2DBnull(obj.WorkShopName));
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

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

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", Convert2DBnull(obj.WorkShopCode));
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateWorkShopByWorkShopID(WorkShop obj)
        {
            string sql = @"UPDATE [BE_WorkShop] SET [WorkShopCode]=@WorkShopCode
				, [WorkShopName]=@WorkShopName
				, [WorkingLineID]=@WorkingLineID
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", Convert2DBnull(obj.WorkShopCode));
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", Convert2DBnull(obj.WorkShopName));
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

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

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopByWorkShopCode(string workShopCode)
        {
            string sql = @"DELETE [BE_WorkShop] WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", workShopCode);
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopByWorkShopID(Guid workShopID)
        {
            string sql = @"DELETE [BE_WorkShop] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWorkShopByWorkShopCode(WorkShop obj)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", Convert2DBnull(obj.WorkShopCode));
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        obj.WorkShopID = (Guid)dr["WorkShopID"];
                    obj.WorkShopCode = dr["WorkShopCode"].ToString();
                    obj.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        obj.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public int LoadWorkShopByWorkShopID(WorkShop obj)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        obj.WorkShopID = (Guid)dr["WorkShopID"];
                    obj.WorkShopCode = dr["WorkShopCode"].ToString();
                    obj.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        obj.WorkingLineID = (Guid)dr["WorkingLineID"];
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

        #region BE_WorkShop CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWorkShops()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByWorkShopCode(string workShopCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", workShopCode);
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByWorkShopName(string workShopName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopName]=@WorkShopName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", workShopName);
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByWorkingLineID(Guid workingLineID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShopsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShop] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWorkShops()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT TOP 1 [WorkShopID] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByWorkShopCode(string workShopCode)
        {
            string sql = "SELECT TOP 1 [WorkShopCode] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", workShopCode);
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByWorkShopName(string workShopName)
        {
            string sql = "SELECT TOP 1 [WorkShopName] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkShopName]=@WorkShopName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", workShopName);
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByWorkingLineID(Guid workingLineID)
        {
            string sql = "SELECT TOP 1 [WorkingLineID] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShopsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WorkShop] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWorkShops()
        {
            string sql = "DELETE FROM [BE_WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByWorkShopCode(string workShopCode)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", workShopCode);
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByWorkShopName(string workShopName)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [WorkShopName]=@WorkShopName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", workShopName);
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByWorkingLineID(Guid workingLineID)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShopsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WorkShop] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WorkShop> LoadWorkShops()
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByWorkShopCode(string workShopCode)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [WorkShopCode]=@WorkShopCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopCode = new SqlParameter("WorkShopCode", workShopCode);
            pWorkShopCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopCode);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByWorkShopName(string workShopName)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [WorkShopName]=@WorkShopName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopName = new SqlParameter("WorkShopName", workShopName);
            pWorkShopName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShopName);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByWorkingLineID(Guid workingLineID)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [WorkingLineID]=@WorkingLineID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingLineID = new SqlParameter("WorkingLineID", workingLineID);
            pWorkingLineID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingLineID);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByRemark(string remark)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByCreated(DateTime created)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByModified(DateTime modified)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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
        public List<WorkShop> LoadWorkShopsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [WorkShopID]
				, [WorkShopCode]
				, [WorkShopName]
				, [WorkingLineID]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShop] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WorkShop> ret = new List<WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShop iret = new WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkShopCode = dr["WorkShopCode"].ToString();
                    iret.WorkShopName = dr["WorkShopName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkingLineID"]))
                        iret.WorkingLineID = (Guid)dr["WorkingLineID"];
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

        #region BE_WorkShop SearchObject()
        public SearchResult SearchWorkShop(SearchWorkShopArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkShopCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WorkShop].[WorkShopID]
                                          ,[BE_WorkShop].[WorkShopCode]
                                          ,[BE_WorkShop].[WorkShopName]
                                          ,[BE_WorkShop].[Remark]
                                          ,[BE_WorkShop].[Created]
                                          ,[BE_WorkShop].[CreatedBy]
                                          ,[BE_WorkShop].[Modified]
                                          ,[BE_WorkShop].[ModifiedBy]
										  ,[BE_WorkShop].[WorkingLineID]
										  ,[BE_WorkingLine].[WorkingLineName]                                            
                                      FROM 
                                          [BE_WorkShop] with(nolock)
                                          LEFT JOIN [BE_WorkingLine] with(nolock) on [BE_WorkingLine].[WorkingLineID] = [BE_WorkShop].[WorkingLineID]
	                                  WHERE 1=1");


            if (!string.IsNullOrEmpty(args.WorkShopCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkShopCode", "mbWorkShopCode", args.WorkShopCode);
            }
            if (!string.IsNullOrEmpty(args.WorkShopName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkShopName", "mbWorkShopName", args.WorkShopName);
            }
            if (args.WorkShopID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "WorkShopID", "mbWorkFlowID", args.WorkShopID.Value);
            }
            if (args.WorkingLineID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkShop].[WorkingLineID", "mbWorkingLineID", args.WorkingLineID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkingLineName))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkingLine].[WorkingLineName", "mbWorkingLineName", args.WorkingLineName);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
