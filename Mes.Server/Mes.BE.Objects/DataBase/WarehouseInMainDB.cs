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
       
        #region BE_WarehouseInMain InsertObject()
        public int InsertWarehouseInMain(WarehouseInMain obj)
        {
            string sql = @"INSERT INTO[BE_WarehouseInMain]([InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@InID
				, @BillNo
				, @BattchNo
				, @SupplierID
				, @Remark
				, @CheckInDate
				, @HandlerMan
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            SqlParameter pBillNo = new SqlParameter("BillNo", Convert2DBnull(obj.BillNo));
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", Convert2DBnull(obj.BattchNo));
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCheckInDate = new SqlParameter("CheckInDate", Convert2DBnull(obj.CheckInDate));
            pCheckInDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckInDate);

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

        #region BE_WarehouseInMain UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWarehouseInMainByInID(WarehouseInMain obj)
        {
            string sql = @"UPDATE [BE_WarehouseInMain] SET [BillNo]=@BillNo
				, [BattchNo]=@BattchNo
				, [SupplierID]=@SupplierID
				, [Remark]=@Remark
				, [CheckInDate]=@CheckInDate
				, [HandlerMan]=@HandlerMan
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", Convert2DBnull(obj.BillNo));
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", Convert2DBnull(obj.BattchNo));
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCheckInDate = new SqlParameter("CheckInDate", Convert2DBnull(obj.CheckInDate));
            pCheckInDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckInDate);

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

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainByInID(Guid inID)
        {
            string sql = @"DELETE [BE_WarehouseInMain] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWarehouseInMainByInID(WarehouseInMain obj)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["InID"]))
                        obj.InID = (Guid)dr["InID"];
                    obj.BillNo = dr["BillNo"].ToString();
                    obj.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        obj.SupplierID = (Guid)dr["SupplierID"];
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        obj.CheckInDate = (DateTime)dr["CheckInDate"];
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

        #region BE_WarehouseInMain CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWarehouseInMains()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByInID(Guid inID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByBillNo(string billNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByBattchNo(string battchNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsBySupplierID(Guid supplierID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByCheckInDate(DateTime checkInDate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [CheckInDate]=@CheckInDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckInDate = new SqlParameter("CheckInDate", checkInDate);
            pCheckInDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckInDate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByHandlerMan(string handlerMan)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWarehouseInMains()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WarehouseInMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByInID(Guid inID)
        {
            string sql = "SELECT TOP 1 [InID] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByBillNo(string billNo)
        {
            string sql = "SELECT TOP 1 [BillNo] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByBattchNo(string battchNo)
        {
            string sql = "SELECT TOP 1 [BattchNo] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsBySupplierID(Guid supplierID)
        {
            string sql = "SELECT TOP 1 [SupplierID] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByCheckInDate(DateTime checkInDate)
        {
            string sql = "SELECT TOP 1 [CheckInDate] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [CheckInDate]=@CheckInDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckInDate = new SqlParameter("CheckInDate", checkInDate);
            pCheckInDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckInDate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByHandlerMan(string handlerMan)
        {
            string sql = "SELECT TOP 1 [HandlerMan] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WarehouseInMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWarehouseInMains()
        {
            string sql = "DELETE FROM [BE_WarehouseInMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByInID(Guid inID)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByBillNo(string billNo)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByBattchNo(string battchNo)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsBySupplierID(Guid supplierID)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByCheckInDate(DateTime checkInDate)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [CheckInDate]=@CheckInDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckInDate = new SqlParameter("CheckInDate", checkInDate);
            pCheckInDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckInDate);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByHandlerMan(string handlerMan)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInMainsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WarehouseInMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WarehouseInMain> LoadWarehouseInMains()
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByInID(Guid inID)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByBillNo(string billNo)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByBattchNo(string battchNo)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsBySupplierID(Guid supplierID)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByRemark(string remark)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByCheckInDate(DateTime checkInDate)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [CheckInDate]=@CheckInDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckInDate = new SqlParameter("CheckInDate", checkInDate);
            pCheckInDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCheckInDate);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByHandlerMan(string handlerMan)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [HandlerMan]=@HandlerMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHandlerMan = new SqlParameter("HandlerMan", handlerMan);
            pHandlerMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHandlerMan);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByCreated(DateTime created)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByModified(DateTime modified)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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
        public List<WarehouseInMain> LoadWarehouseInMainsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [BattchNo]
				, [SupplierID]
				, [Remark]
				, [CheckInDate]
				, [HandlerMan]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WarehouseInMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WarehouseInMain> ret = new List<WarehouseInMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInMain iret = new WarehouseInMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["CheckInDate"]))
                        iret.CheckInDate = (DateTime)dr["CheckInDate"];
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

        #region BE_WarehouseInMain SearchObject()
        public SearchResult SearchWarehouseInMain(SearchWarehouseInMainArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BillNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WarehouseInMain].[InID]
                                          ,[BE_WarehouseInMain].[BillNo]
                                          ,[BE_WarehouseInMain].[BattchNo]
                                          ,[BE_WarehouseInMain].[SupplierID]
                                          ,[BE_WarehouseInMain].[Remark]
                                          ,[BE_WarehouseInMain].[CheckInDate]
                                          ,[BE_WarehouseInMain].[HandlerMan]
                                          ,[BE_WarehouseInMain].[Created]
                                          ,[BE_WarehouseInMain].[CreatedBy]
                                          ,[BE_WarehouseInMain].[Modified]
                                          ,[BE_WarehouseInMain].[ModifiedBy]
	                                      ,[BE_Supplier].[SupplierCode]
	                                      ,[BE_Supplier].[SupplierName]
                                      FROM 
		                                    [BE_WarehouseInMain] with(nolock)
		                                    LEFT JOIN [BE_Supplier] with(nolock) on [BE_WarehouseInMain].[SupplierID] = [BE_Supplier].[SupplierID]
	                                  WHERE 1=1");

            if (!string.IsNullOrEmpty(args.SupplierCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SupplierCode", "mbSupplierCode", args.SupplierCode);
            }
            if (!string.IsNullOrEmpty(args.SupplierName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SupplierName", "mbSupplierName", args.SupplierName);
            }
            if (args.InID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "InID", "mbInID", args.InID.Value);
            }
            if (args.SupplierID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseInMain].[SupplierID", "mbSupplierID", args.SupplierID.Value);
            }
            if (!string.IsNullOrEmpty(args.BillNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BillNo", "mbBillNo", args.BillNo);
            }
            if (!string.IsNullOrEmpty(args.HandlerMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "HandlerMan", "mbHandlerMan", args.HandlerMan);
            }
            this.SetParameters_Between(mbBuilder, cmd, "CheckInDate", "mbCheckInDate", args.CheckInDateFrom, args.CheckInDateTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
