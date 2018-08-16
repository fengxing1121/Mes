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
        #region BE_ReviewDetail InsertObject()
        public int InsertReviewDetail(ReviewDetail obj)
        {
            string sql = @"Insert Into [BE_ReviewDetail](
                              [TransID]
                             ,[OrderID]
                             ,[TransDate]
                             ,[Amount]
                             ,[VoucherNo]
                             ,[Payee]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                              @TransID
                             ,@OrderID
                             ,@TransDate
                             ,@Amount
                             ,@VoucherNo
                             ,@Payee
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(obj.TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

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

        #region BE_ReviewDetail UpdateObject()、DeleteObject()
        public int UpdateReviewDetailByTransID(ReviewDetail obj)
        {
            string sql = @"Update [BE_ReviewDetail] Set
                              [OrderID]=@OrderID
                             ,[TransDate]=@TransDate
                             ,[Amount]=@Amount
                             ,[VoucherNo]=@VoucherNo
                             ,[Payee]=@Payee
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where TransID=@TransID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(obj.TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

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

        public int DeleteReviewDetailByTransID(Guid TransID)
        {
            string sql = @"Delete [BE_ReviewDetail]  Where TransID=@TransID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ReviewDetail LoadObject()
        public List<ReviewDetail> LoadReviewDetails()
        {
            string sql = @"Select 
                              [TransID]
                             ,[OrderID]
                             ,[TransDate]
                             ,[Amount]
                             ,[VoucherNo]
                             ,[Payee]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ReviewDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ReviewDetail> ret = new List<ReviewDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ReviewDetail iret = new ReviewDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["VoucherNo"]))
                        iret.VoucherNo = (string)dr["VoucherNo"];
                    if (!Convert.IsDBNull(dr["Payee"]))
                        iret.Payee = (string)dr["Payee"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ReviewDetail> LoadReviewDetailByTransID(ReviewDetail obj)
        {
            string sql = @"Select 
                              [TransID]
                             ,[OrderID]
                             ,[TransDate]
                             ,[Amount]
                             ,[VoucherNo]
                             ,[Payee]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ReviewDetail] With(NoLock) Where TransID=@TransID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(obj.TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            List<ReviewDetail> ret = new List<ReviewDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ReviewDetail iret = new ReviewDetail();
                    if (!Convert.IsDBNull(dr["TransID"]))
                        iret.TransID = (Guid)dr["TransID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        iret.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["VoucherNo"]))
                        iret.VoucherNo = (string)dr["VoucherNo"];
                    if (!Convert.IsDBNull(dr["Payee"]))
                        iret.Payee = (string)dr["Payee"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadReviewDetail(ReviewDetail obj)
        {
            string sql = @"Select 
                              [TransID]
                             ,[OrderID]
                             ,[TransDate]
                             ,[Amount]
                             ,[VoucherNo]
                             ,[Payee]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ReviewDetail] With(NoLock) Where TransID=@TransID";

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
                    if (!Convert.IsDBNull(dr["TransDate"]))
                        obj.TransDate = (DateTime)dr["TransDate"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        obj.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["VoucherNo"]))
                        obj.VoucherNo = (string)dr["VoucherNo"];
                    if (!Convert.IsDBNull(dr["Payee"]))
                        obj.Payee = (string)dr["Payee"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
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

        #region BE_ReviewDetail CountObjects()、ExistsObjects()
        public int CountReviewDetail()
        {
            string sql = @"Select Count(*) From [BE_ReviewDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountReviewDetailTransID(Guid TransID)
        {
            string sql = @"Select Count(*) From [BE_ReviewDetail]  Where TransID=@TransID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsReviewDetail()
        {
            string sql = @"Select Top 1 * From [BE_ReviewDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsReviewDetailTransID(Guid TransID)
        {
            string sql = @"Select Top 1 * From [BE_ReviewDetail]  Where TransID=@TransID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransID = new SqlParameter("TransID", Convert2DBnull(TransID));
            pTransID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

