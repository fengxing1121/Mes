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
       
        #region BE_PartnerTransDetail InsertObject()
        public int InsertPartnerTransDetail(PartnerTransDetail obj)
        {
            string sql = @"INSERT INTO[BE_PartnerTransDetail]([TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				) VALUES(@TransID
				, @OrderID
				, @PartnerID
				, @TransDate
				, @Amount
				, @VoucherNo
				, @Payee
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(obj.TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTransDate = new SqlParameter("TransDate", Convert2DBnull(obj.TransDate));
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            SqlParameter pAmount = new SqlParameter("Amount", Convert2DBnull(obj.Amount));
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", Convert2DBnull(obj.VoucherNo));
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            SqlParameter pPayee = new SqlParameter("Payee", Convert2DBnull(obj.Payee));
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PartnerTransDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerTransDetailByTransID(PartnerTransDetail obj)
        {
            string sql = @"UPDATE [BE_PartnerTransDetail] SET [OrderID]=@OrderID
				, [PartnerID]=@PartnerID
				, [TransDate]=@TransDate
				, [Amount]=@Amount
				, [VoucherNo]=@VoucherNo
				, [Payee]=@Payee
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTransDate = new SqlParameter("TransDate", Convert2DBnull(obj.TransDate));
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            SqlParameter pAmount = new SqlParameter("Amount", Convert2DBnull(obj.Amount));
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", Convert2DBnull(obj.VoucherNo));
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            SqlParameter pPayee = new SqlParameter("Payee", Convert2DBnull(obj.Payee));
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(obj.TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailByTransID(Guid transID)
        {
            string sql = @"DELETE [BE_PartnerTransDetail] WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerTransDetailByTransID(PartnerTransDetail obj)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
 				FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(obj.TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TransID"]))
                        obj.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        obj.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        obj.Amount = (decimal)dr["Amount"];
                    obj.VoucherNo = dr["VoucherNo"].ToString();
                    obj.Payee = dr["Payee"].ToString();
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

        #region BE_PartnerTransDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerTransDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByTransID(Guid transID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByAmount(decimal amount)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByPayee(string payee)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerTransDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByTransID(Guid transID)
        {
            string sql = "SELECT TOP 1 [TransID] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = "SELECT TOP 1 [TransDate] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByAmount(decimal amount)
        {
            string sql = "SELECT TOP 1 [Amount] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = "SELECT TOP 1 [VoucherNo] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByPayee(string payee)
        {
            string sql = "SELECT TOP 1 [Payee] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PartnerTransDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerTransDetails()
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByTransID(Guid transID)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByAmount(decimal amount)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByPayee(string payee)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PartnerTransDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerTransDetail> LoadPartnerTransDetails()
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByTransID(Guid transID)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByAmount(decimal amount)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByPayee(string payee)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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
        public List<PartnerTransDetail> LoadPartnerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [TransID]
				, [OrderID]
				, [PartnerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_PartnerTransDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PartnerTransDetail> ret = new List<PartnerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTransDetail iret = new PartnerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    iret.VoucherNo = dr["VoucherNo"].ToString();
                    iret.Payee = dr["Payee"].ToString();
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

        #region BE_PartnerTransDetail SearchObject()
        public SearchResult SearchPartnerTransDetail(SearchPartnerTransDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[QuoteNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_PartnerTransDetail].[TransID]  
                                        ,[BE_PartnerTransDetail].[OrderID]                                     
                                        ,[BE_PartnerTransDetail].[PartnerID]
                                        ,[BE_PartnerTransDetail].[TransDate]
                                        ,[BE_PartnerTransDetail].[Amount]
                                        ,[BE_PartnerTransDetail].[VoucherNo]
                                        ,[BE_PartnerTransDetail].[Payee]
                                        ,[BE_PartnerTransDetail].[Created]
                                        ,[BE_PartnerTransDetail].[CreatedBy]	                                 
	                                    ,[BE_Order].[QuoteAmount]
	                                    ,[BE_Order].[DiscountAmount]
	                                    ,[BE_Order].[Discount]
	                                    ,[BE_Customer].[CustomerName]
	                                    ,[BE_Customer].[LinkMan]
	                                    ,[BE_Customer].[Mobile]
	                                    ,[BE_Customer].[Address]
										,[BE_Partner].[PartnerCode]
										,[BE_Partner].[PartnerName]										
                                    FROM 
                                        [BE_PartnerTransDetail] with(nolock)	                                   
										LEFT JOIN [BE_Order] with(nolock) on [BE_Order].[OrderID] = [BE_PartnerTransDetail].[OrderID]
	                                    LEFT JOIN [BE_Customer] with(nolock) on [BE_Order].[CustomerID] = [BE_Customer].[CustomerID]
										LEFT JOIN [BE_Partner]  with(nolock) on [BE_Customer].[PartnerID] = [BE_Partner].[PartnerID]
                                   WHERE 1=1");

            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerTransDetail].[OrderID", "mbOrderID", args.OrderID);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerTransDetail].[PartnerID", "mbPartnerID", args.PartnerID);
            }
            if (args.TransID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerTransDetail].[TransID", "mbSolutionID", args.TransID);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerTransDetail].[CustomerID", "mbCustomerID", args.CustomerID);
            }

            if (!string.IsNullOrEmpty(args.VoucherNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerTransDetail].[VoucherNo", "mbStatus", args.VoucherNo);
            }
            if (!string.IsNullOrEmpty(args.PartnerCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerCode", "mbPartnerCode", args.PartnerCode);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.LinkMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[LinkMan", "mbLinkMan", args.LinkMan);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }

            this.SetParameters_Between(mbBuilder, cmd, "TransDate", "mbTransDate", args.TransDateFrom, args.TransDateTo);

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
