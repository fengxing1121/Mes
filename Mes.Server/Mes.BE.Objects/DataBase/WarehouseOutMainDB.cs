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
      
        #region BE_WarehouseOutMain InsertObject()
        public int InsertWarehouseOutMain(WarehouseOutMain obj)
        {
            string sql = @"INSERT INTO[BE_WarehouseOutMain]([OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@OutID
				, @BillNo
				, @WorkShopID
				, @Remark
				, @CheckOutDate
				, @HandlerMan
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", Convert2DBnull(obj.OutID));
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            SqlParameter pBillNo = new SqlParameter("BillNo", Convert2DBnull(obj.BillNo));
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCheckOutDate = new SqlParameter("CheckOutDate", Convert2DBnull(obj.CheckOutDate));
            pCheckOutDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckOutDate);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", Convert2DBnull(obj.HandlerMan));
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

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

        #region BE_WarehouseOutMain UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWarehouseOutMainByOutID(WarehouseOutMain obj)
        {
            string sql = @"UPDATE [BE_WarehouseOutMain] SET [BillNo]=@BillNo
				, [WorkShopID]=@WorkShopID
				, [Remark]=@Remark
				, [CheckOutDate]=@CheckOutDate
				, [HandlerMan]=@HandlerMan
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", Convert2DBnull(obj.BillNo));
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCheckOutDate = new SqlParameter("CheckOutDate", Convert2DBnull(obj.CheckOutDate));
            pCheckOutDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckOutDate);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", Convert2DBnull(obj.HandlerMan));
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

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

            SqlParameter pOutID = new SqlParameter("OutID", Convert2DBnull(obj.OutID));
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainByOutID(Guid outID)
        {
            string sql = @"DELETE [BE_WarehouseOutMain] WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWarehouseOutMainByOutID(WarehouseOutMain obj)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", Convert2DBnull(obj.OutID));
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["OutID"]))
                        obj.OutID = (Guid)dr["OutID"];
                    obj.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        obj.WorkShopID = (Guid)dr["WorkShopID"];
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        obj.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    obj.HandlerMan = dr["HandlerMan"].ToString();
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

        #region BE_WarehouseOutMain CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWarehouseOutMains()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByOutID(Guid outID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByBillNo(string billNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByCheckOutDate(DateTime checkOutDate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [CheckOutDate]=@CheckOutDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckOutDate = new SqlParameter("CheckOutDate", checkOutDate);
            pCheckOutDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckOutDate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByHandlerMan(string handlerMan)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWarehouseOutMains()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WarehouseOutMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByOutID(Guid outID)
        {
            string sql = "SELECT TOP 1 [OutID] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByBillNo(string billNo)
        {
            string sql = "SELECT TOP 1 [BillNo] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT TOP 1 [WorkShopID] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByCheckOutDate(DateTime checkOutDate)
        {
            string sql = "SELECT TOP 1 [CheckOutDate] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [CheckOutDate]=@CheckOutDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckOutDate = new SqlParameter("CheckOutDate", checkOutDate);
            pCheckOutDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckOutDate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByHandlerMan(string handlerMan)
        {
            string sql = "SELECT TOP 1 [HandlerMan] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WarehouseOutMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWarehouseOutMains()
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByOutID(Guid outID)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByBillNo(string billNo)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByWorkShopID(Guid workShopID)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByCheckOutDate(DateTime checkOutDate)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [CheckOutDate]=@CheckOutDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckOutDate = new SqlParameter("CheckOutDate", checkOutDate);
            pCheckOutDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckOutDate);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByHandlerMan(string handlerMan)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutMainsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WarehouseOutMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WarehouseOutMain> LoadWarehouseOutMains()
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByOutID(Guid outID)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByBillNo(string billNo)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByWorkShopID(Guid workShopID)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByRemark(string remark)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByCheckOutDate(DateTime checkOutDate)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [CheckOutDate]=@CheckOutDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckOutDate = new SqlParameter("CheckOutDate", checkOutDate);
            pCheckOutDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckOutDate);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByHandlerMan(string handlerMan)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByCreated(DateTime created)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByModified(DateTime modified)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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
        public List<WarehouseOutMain> LoadWarehouseOutMainsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [OutID]
				, [BillNo]
				, [WorkShopID]
				, [Remark]
				, [CheckOutDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseOutMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WarehouseOutMain> ret = new List<WarehouseOutMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutMain iret = new WarehouseOutMain();
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckOutDate"]))
                        iret.CheckOutDate = (DateTime)dr["CheckOutDate"];
                    iret.HandlerMan = dr["HandlerMan"].ToString();
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

        #region BE_WarehouseOutMain SearchObject()
        public SearchResult SearchWarehouseOutMain(SearchWarehouseOutMainArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BillNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WarehouseOutMain].[OutID]
                                          ,[BE_WarehouseOutMain].[BillNo]
                                          ,[BE_WarehouseOutMain].[WorkShopID]
                                          ,[BE_WarehouseOutMain].[Remark]
                                          ,[BE_WarehouseOutMain].[CheckOutDate]
                                          ,[BE_WarehouseOutMain].[HandlerMan]
                                          ,[BE_WarehouseOutMain].[Created]
                                          ,[BE_WarehouseOutMain].[CreatedBy]
                                          ,[BE_WarehouseOutMain].[Modified]
                                          ,[BE_WarehouseOutMain].[ModifiedBy]
	                                      ,[BE_WorkShop].[WorkShopName]
                                      FROM 
	                                        [BE_WarehouseOutMain] with(nolock)
		                                    LEFT JOIN [BE_WorkShop] with(nolock) on [BE_WarehouseOutMain].[WorkShopID] = [BE_WorkShop].[WorkShopID]
	                                  WHERE 1=1");


            if (args.OutID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "OutID", "mbOutID", args.OutID.Value);
            }
            if (!string.IsNullOrEmpty(args.BillNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BillNo", "mbBillNo", args.BillNo);
            }
            if (!string.IsNullOrEmpty(args.HandlerMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "HandlerMan", "mbHandlerMan", args.HandlerMan);
            }

            if (args.WorkShopID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseOutMain].[WorkShopID", "mbWorkShopID", args.WorkShopID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkShopName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkShopName", "mbWorkShopName", args.WorkShopName);
            }
            this.SetParameters_Between(mbBuilder, cmd, "CheckOutDate", "mbCheckOutDate", args.CheckOutDateFrom, args.CheckOutDateTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
