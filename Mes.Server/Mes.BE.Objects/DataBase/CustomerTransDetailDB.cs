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
        
        #region BE_CustomerTransDetail InsertObject()
        public int InsertCustomerTransDetail(CustomerTransDetail obj)
        {
            string sql = @"INSERT INTO[BE_CustomerTransDetail]([TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				) VALUES(@TransID
				, @QuoteID
				, @CustomerID
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

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

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

        #region BE_CustomerTransDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCustomerTransDetailByTransID(CustomerTransDetail obj)
        {
            string sql = @"UPDATE [BE_CustomerTransDetail] SET [QuoteID]=@QuoteID
				, [CustomerID]=@CustomerID
				, [TransDate]=@TransDate
				, [Amount]=@Amount
				, [VoucherNo]=@VoucherNo
				, [Payee]=@Payee
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

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
        public int DeleteCustomerTransDetailByTransID(Guid transID)
        {
            string sql = @"DELETE [BE_CustomerTransDetail] WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCustomerTransDetailByTransID(CustomerTransDetail obj)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
 				FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [TransID]=@TransID";
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
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        obj.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
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

        #region BE_CustomerTransDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCustomerTransDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByTransID(Guid transID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByQuoteID(Guid quoteID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByCustomerID(Guid customerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByAmount(decimal amount)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByPayee(string payee)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCustomerTransDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_CustomerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByTransID(Guid transID)
        {
            string sql = "SELECT TOP 1 [TransID] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByQuoteID(Guid quoteID)
        {
            string sql = "SELECT TOP 1 [QuoteID] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByCustomerID(Guid customerID)
        {
            string sql = "SELECT TOP 1 [CustomerID] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = "SELECT TOP 1 [TransDate] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByAmount(decimal amount)
        {
            string sql = "SELECT TOP 1 [Amount] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = "SELECT TOP 1 [VoucherNo] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByPayee(string payee)
        {
            string sql = "SELECT TOP 1 [Payee] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_CustomerTransDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCustomerTransDetails()
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByTransID(Guid transID)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByQuoteID(Guid quoteID)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByCustomerID(Guid customerID)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByAmount(decimal amount)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByPayee(string payee)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_CustomerTransDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<CustomerTransDetail> LoadCustomerTransDetails()
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByTransID(Guid transID)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [TransID]=@TransID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", transID);
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByQuoteID(Guid quoteID)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByCustomerID(Guid customerID)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByTransDate(DateTime transDate)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [TransDate]=@TransDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransDate = new SqlParameter("TransDate", transDate);
            pTransDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pTransDate);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByAmount(decimal amount)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [Amount]=@Amount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAmount = new SqlParameter("Amount", amount);
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByVoucherNo(string voucherNo)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [VoucherNo]=@VoucherNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVoucherNo = new SqlParameter("VoucherNo", voucherNo);
            pVoucherNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVoucherNo);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByPayee(string payee)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [Payee]=@Payee";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPayee = new SqlParameter("Payee", payee);
            pPayee.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPayee);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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
        public List<CustomerTransDetail> LoadCustomerTransDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [TransID]
				, [QuoteID]
				, [CustomerID]
				, [TransDate]
				, [Amount]
				, [VoucherNo]
				, [Payee]
				, [Created]
				, [CreatedBy]
				 FROM [BE_CustomerTransDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<CustomerTransDetail> ret = new List<CustomerTransDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerTransDetail iret = new CustomerTransDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
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

        #region BE_CustomerTransDetail SearchObject()
        public SearchResult SearchCustomerTransDetail(SearchCustomerTransDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[QuoteNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_CustomerTransDetail].[TransID]
                                        ,[BE_CustomerTransDetail].[QuoteID]
                                        ,[BE_CustomerTransDetail].[CustomerID]
                                        ,[BE_CustomerTransDetail].[TransDate]
                                        ,[BE_CustomerTransDetail].[Amount]
                                        ,[BE_CustomerTransDetail].[VoucherNo]
                                        ,[BE_CustomerTransDetail].[Payee]
                                        ,[BE_CustomerTransDetail].[Created]
                                        ,[BE_CustomerTransDetail].[CreatedBy]
	                                    ,[BE_QuoteMain].[QuoteNo]
	                                    ,[BE_QuoteMain].[TotalAmount]
	                                    ,[BE_QuoteMain].[DiscountAmount]
	                                    ,[BE_QuoteMain].[DiscountPercent]
	                                    ,[BE_Customer].[CustomerName]
	                                    ,[BE_Customer].[LinkMan]
	                                    ,[BE_Customer].[Mobile]
	                                    ,[BE_Customer].[Address]
										,[BE_Partner].[PartnerCode]
										,[BE_Partner].[PartnerName]
                                    FROM 
                                        [BE_CustomerTransDetail] with(nolock)
	                                    LEFT JOIN [BE_QuoteMain]  with(nolock) on [BE_CustomerTransDetail].[QuoteID] = [BE_QuoteMain].[QuoteID]
	                                    LEFT JOIN [BE_Customer] with(nolock) on [BE_CustomerTransDetail].[CustomerID] = [BE_Customer].[CustomerID]
										LEFT JOIN [BE_Partner]  with(nolock) on [BE_Customer].[PartnerID] = [BE_Partner].[PartnerID]
                                   WHERE 1=1");

            if (args.QuoteID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_CustomerTransDetail].[QuoteID", "mbQuoteID", args.QuoteID);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[PartnerID", "mbPartnerID", args.PartnerID);
            }
            if (args.TransID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[TransID", "mbSolutionID", args.TransID);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_CustomerTransDetail].[CustomerID", "mbCustomerID", args.CustomerID);
            }
            if (!string.IsNullOrEmpty(args.QuoteNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "QuoteNo", "mbQuoteNo", args.QuoteNo);
            }
            if (!string.IsNullOrEmpty(args.VoucherNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_CustomerTransDetail].[VoucherNo", "mbStatus", args.VoucherNo);
            }
            if (!string.IsNullOrEmpty(args.PartnerCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerCode", "mbSolutionCode", args.PartnerCode);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.LinkMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[LinkMan", "mbLinkMan", args.LinkMan);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[CustomerName", "mbCustomerName", args.CustomerName);
            }

            this.SetParameters_Between(mbBuilder, cmd, "TransDate", "mbTransDate", args.TransDateFrom, args.TransDateTo);

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
