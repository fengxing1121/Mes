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

        #region BE_OrderMadeState InsertObject()
        public int InsertOrderMadeState(OrderMadeState obj)
        {
            string sql = @"INSERT INTO[BE_OrderMadeState]([DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				) VALUES(@DetailID
				, @OrderID
				, @CabinetID
				, @ItemID
				, @Barcode
				, @WorkFlowID
				, @WorkShiftID
				, @Qty
				, @ProcessedBy
				, @Processed
				, @MadeLength
				, @MadeWidth
				, @MadeHeight
				, @TotalAreal
				, @Perimeter
				, @PaymentType
				, @Price
				, @Flag
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pBarcode = new SqlParameter("Barcode", Convert2DBnull(obj.Barcode));
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            SqlParameter pProcessedBy = new SqlParameter("ProcessedBy", Convert2DBnull(obj.ProcessedBy));
            pProcessedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProcessedBy);

            SqlParameter pProcessed = new SqlParameter("Processed", Convert2DBnull(obj.Processed));
            pProcessed.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pProcessed);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pPerimeter = new SqlParameter("Perimeter", Convert2DBnull(obj.Perimeter));
            pPerimeter.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPerimeter);

            SqlParameter pPaymentType = new SqlParameter("PaymentType", Convert2DBnull(obj.PaymentType));
            pPaymentType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPaymentType);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pFlag = new SqlParameter("Flag", Convert2DBnull(obj.Flag));
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderMadeState UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrderMadeStateByDetailID(OrderMadeState obj)
        {
            string sql = @"UPDATE [BE_OrderMadeState] SET [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
				, [ItemID]=@ItemID
				, [Barcode]=@Barcode
				, [WorkFlowID]=@WorkFlowID
				, [WorkShiftID]=@WorkShiftID
				, [Qty]=@Qty
				, [ProcessedBy]=@ProcessedBy
				, [Processed]=@Processed
				, [MadeLength]=@MadeLength
				, [MadeWidth]=@MadeWidth
				, [MadeHeight]=@MadeHeight
				, [TotalAreal]=@TotalAreal
				, [Perimeter]=@Perimeter
				, [PaymentType]=@PaymentType
				, [Price]=@Price
				, [Flag]=@Flag
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pBarcode = new SqlParameter("Barcode", Convert2DBnull(obj.Barcode));
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            SqlParameter pProcessedBy = new SqlParameter("ProcessedBy", Convert2DBnull(obj.ProcessedBy));
            pProcessedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProcessedBy);

            SqlParameter pProcessed = new SqlParameter("Processed", Convert2DBnull(obj.Processed));
            pProcessed.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pProcessed);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pPerimeter = new SqlParameter("Perimeter", Convert2DBnull(obj.Perimeter));
            pPerimeter.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPerimeter);

            SqlParameter pPaymentType = new SqlParameter("PaymentType", Convert2DBnull(obj.PaymentType));
            pPaymentType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPaymentType);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pFlag = new SqlParameter("Flag", Convert2DBnull(obj.Flag));
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStateByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_OrderMadeState] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrderMadeStateByDetailID(OrderMadeState obj)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
 				FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        obj.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    obj.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        obj.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (int)dr["Qty"];
                    obj.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        obj.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        obj.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        obj.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        obj.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        obj.Perimeter = (decimal)dr["Perimeter"];
                    obj.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        obj.Flag = (bool)dr["Flag"];
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

        #region BE_OrderMadeState CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrderMadeStates()
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByBarcode(string barcode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Barcode]=@Barcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcode = new SqlParameter("Barcode", barcode);
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByWorkShiftID(Guid workShiftID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByQty(int qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByProcessedBy(string processedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [ProcessedBy]=@ProcessedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessedBy = new SqlParameter("ProcessedBy", processedBy);
            pProcessedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProcessedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByProcessed(DateTime processed)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Processed]=@Processed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessed = new SqlParameter("Processed", processed);
            pProcessed.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pProcessed);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByMadeLength(decimal madeLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByTotalAreal(decimal totalAreal)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByPerimeter(decimal perimeter)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Perimeter]=@Perimeter";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPerimeter = new SqlParameter("Perimeter", perimeter);
            pPerimeter.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPerimeter);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByPaymentType(string paymentType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [PaymentType]=@PaymentType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPaymentType = new SqlParameter("PaymentType", paymentType);
            pPaymentType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPaymentType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderMadeStatesByFlag(bool flag)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrderMadeStates()
        {
            string sql = "SELECT TOP 1 * FROM [BE_OrderMadeState]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByBarcode(string barcode)
        {
            string sql = "SELECT TOP 1 [Barcode] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Barcode]=@Barcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcode = new SqlParameter("Barcode", barcode);
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT TOP 1 [WorkFlowID] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByWorkShiftID(Guid workShiftID)
        {
            string sql = "SELECT TOP 1 [WorkShiftID] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByQty(int qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByProcessedBy(string processedBy)
        {
            string sql = "SELECT TOP 1 [ProcessedBy] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [ProcessedBy]=@ProcessedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessedBy = new SqlParameter("ProcessedBy", processedBy);
            pProcessedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProcessedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByProcessed(DateTime processed)
        {
            string sql = "SELECT TOP 1 [Processed] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Processed]=@Processed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessed = new SqlParameter("Processed", processed);
            pProcessed.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pProcessed);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByMadeLength(decimal madeLength)
        {
            string sql = "SELECT TOP 1 [MadeLength] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT TOP 1 [MadeWidth] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT TOP 1 [MadeHeight] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByTotalAreal(decimal totalAreal)
        {
            string sql = "SELECT TOP 1 [TotalAreal] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByPerimeter(decimal perimeter)
        {
            string sql = "SELECT TOP 1 [Perimeter] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Perimeter]=@Perimeter";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPerimeter = new SqlParameter("Perimeter", perimeter);
            pPerimeter.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPerimeter);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByPaymentType(string paymentType)
        {
            string sql = "SELECT TOP 1 [PaymentType] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [PaymentType]=@PaymentType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPaymentType = new SqlParameter("PaymentType", paymentType);
            pPaymentType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPaymentType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderMadeStatesByFlag(bool flag)
        {
            string sql = "SELECT TOP 1 [Flag] FROM [BE_OrderMadeState] WITH(NOLOCK) WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrderMadeStates()
        {
            string sql = "DELETE FROM [BE_OrderMadeState]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByItemID(Guid OrderID, Guid CabinetID, Guid ItemID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [ItemID]=@ItemID and OrderID=@OrderID and CabinetID=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", ItemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pOrderID = new SqlParameter("OrderID", OrderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", CabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByItemID(Guid OrderID, Guid itemID)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [ItemID]=@ItemID and OrderID=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pOrderID = new SqlParameter("OrderID", OrderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByBarcode(string barcode)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [Barcode]=@Barcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcode = new SqlParameter("Barcode", barcode);
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByWorkFlowID(Guid workFlowID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByWorkShiftID(Guid workShiftID)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByQty(int qty)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByProcessedBy(string processedBy)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [ProcessedBy]=@ProcessedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessedBy = new SqlParameter("ProcessedBy", processedBy);
            pProcessedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProcessedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByProcessed(DateTime processed)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [Processed]=@Processed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessed = new SqlParameter("Processed", processed);
            pProcessed.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pProcessed);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByMadeLength(decimal madeLength)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByMadeWidth(decimal madeWidth)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByMadeHeight(decimal madeHeight)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByTotalAreal(decimal totalAreal)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByPerimeter(decimal perimeter)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [Perimeter]=@Perimeter";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPerimeter = new SqlParameter("Perimeter", perimeter);
            pPerimeter.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPerimeter);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByPaymentType(string paymentType)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [PaymentType]=@PaymentType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPaymentType = new SqlParameter("PaymentType", paymentType);
            pPaymentType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPaymentType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderMadeStatesByFlag(bool flag)
        {
            string sql = "DELETE FROM [BE_OrderMadeState] WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            return cmd.ExecuteNonQuery();
        }
        public List<OrderMadeState> LoadOrderMadeStates()
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByDetailID(Guid detailID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public SearchResult SearchOrdersByOrderNoList(List<string> orderNoList)
        {

            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT			  [OrderID]
				                                    , [PurchaseNo]
				                                    , [CustomerID]
				                                    , [BE_Order].[PartnerID]
				                                    , [OrderNo]
				                                    , [OutOrderNo]
				                                    , [OrderType]
				                                    , [CabinetType]
				                                    , [CustomerName]
				                                    , [BE_Order].[Address]
				                                    , [BE_Order].[LinkMan]
				                                    , [BE_Order].[Mobile]
                                                    ,convert(varchar(100), [BE_Order].[BookingDate], 23) as [BookingDate]
										            ,convert(varchar(100), [BE_Order].[ShipDate], 23) as [ShipDate]
				                                    , [Status]
				                                    , [BattchNum]
				                                    , [ManufactureDate]
				                                    , [StepNo]
				                                    , [BE_Order].[Remark]
				                                    , [IsStandard]
				                                    , [IsOutsourcing]
				                                    , [BE_Order].[Created]
				                                    , [BE_Order].[CreatedBy]
				                                    , [BE_Order].[Modified]
				                                    , [BE_Order].[ModifiedBy]
			                                         ,[BE_Partner].[PartnerName]								  
                                     FROM [BE_Order] with(nolock) 
                                    LEFT JOIN [BE_Partner] with(nolock) on [BE_Partner].[PartnerID] = [BE_Order].[PartnerID]
                                    WHERE 1=1 and [OrderNo] IN ('" + string.Join("','", orderNoList.ToArray()) + "')");

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, " [Created]", 0, 100);
        }
        public List<OrderMadeState> LoadOrderMadeStatesByOrderID(Guid orderID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByItemID(Guid itemID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByBarcode(string barcode)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [Barcode]=@Barcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcode = new SqlParameter("Barcode", barcode);
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByWorkFlowID(Guid workFlowID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByWorkShiftID(Guid workShiftID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByQty(int qty)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByProcessedBy(string processedBy)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [ProcessedBy]=@ProcessedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessedBy = new SqlParameter("ProcessedBy", processedBy);
            pProcessedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProcessedBy);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByProcessed(DateTime processed)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [Processed]=@Processed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProcessed = new SqlParameter("Processed", processed);
            pProcessed.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pProcessed);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByMadeLength(decimal madeLength)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByMadeWidth(decimal madeWidth)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByMadeHeight(decimal madeHeight)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByTotalAreal(decimal totalAreal)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByPerimeter(decimal perimeter)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [Perimeter]=@Perimeter";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPerimeter = new SqlParameter("Perimeter", perimeter);
            pPerimeter.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPerimeter);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByPaymentType(string paymentType)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [PaymentType]=@PaymentType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPaymentType = new SqlParameter("PaymentType", paymentType);
            pPaymentType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPaymentType);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByPrice(decimal price)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderMadeState> LoadOrderMadeStatesByFlag(bool flag)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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

        #region BE_OrderMadeSate SearchObject()
        public SearchResult SearchOrderMadeSate(SearchOrderMadeStateArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CabinetID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_OrderMadeState].[DetailID]
                                          ,[BE_OrderMadeState].[OrderID]
                                          ,[BE_OrderMadeState].[CabinetID]
                                          ,[BE_OrderMadeState].[ItemID]
                                          ,[BE_OrderMadeState].[Barcode]
                                          ,[BE_OrderMadeState].[WorkFlowID]
                                          ,[BE_OrderMadeState].[WorkShiftID]
                                          ,[BE_OrderMadeState].[Qty] AS [MadeQty]
                                          ,[BE_OrderMadeState].[ProcessedBy]
                                          ,[BE_OrderMadeState].[Processed]
                                          ,[BE_OrderMadeState].[MadeLength]
                                          ,[BE_OrderMadeState].[MadeWidth]
                                          ,[BE_OrderMadeState].[MadeHeight]
                                          ,[BE_OrderMadeState].[TotalAreal]
                                          ,[BE_OrderMadeState].[Perimeter]
                                          ,[BE_OrderMadeState].[PaymentType]
                                          ,[BE_OrderMadeState].[Price]
                                          ,[BE_OrderMadeState].[Flag]
	                                      ,[BE_OrderDetail].[ItemName]	                                      
	                                      ,[BE_OrderDetail].[Qty]	 
	                                      ,[BE_WorkFlow].[WorkFlowName]
                                      FROM 
	                                      [BE_OrderMadeState] with(nolock)
	                                      LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_OrderMadeState].[ItemID] = [BE_OrderDetail].[ItemID]	
	                                      LEFT JOIN [BE_WorkFlow] with(nolock) on   [BE_WorkFlow].[WorkFlowID] = [BE_OrderMadeState].[WorkFlowID]
	                                  WHERE 1=1");



            if (args.WorkFlowID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderMadeState].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID.Value);
            }
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderMadeState].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (args.ItemID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderMadeState].[ItemID", "mbItemID", args.ItemID.Value);
            }
            if (args.WorkShiftID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderMadeState].[WorkShiftID", "mbWorkShiftID", args.WorkShiftID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkFlowName", "mbWorkFlowName", args.WorkFlowName);
            }
            if (!string.IsNullOrEmpty(args.ProcessedBy))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ProcessedBy", "mbProcessedBy", args.ProcessedBy);
            }
            this.SetParameters_Between(mbBuilder, cmd, "Processed", "mbProcessed", args.ProcessedFrom, args.ProcessedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);

        }

        public List<OrderMadeState> LoadOrderMadeStatesByItemID_WorkFlowID(Guid itemID, Guid WorkFlowID)
        {
            string sql = @"SELECT [DetailID]
				, [OrderID]
				, [CabinetID]
				, [ItemID]
				, [Barcode]
				, [WorkFlowID]
				, [WorkShiftID]
				, [Qty]
				, [ProcessedBy]
				, [Processed]
				, [MadeLength]
				, [MadeWidth]
				, [MadeHeight]
				, [TotalAreal]
				, [Perimeter]
				, [PaymentType]
				, [Price]
				, [Flag]
				 FROM [BE_OrderMadeState] WHERE [ItemID]=@ItemID and WorkFlowID=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", WorkFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<OrderMadeState> ret = new List<OrderMadeState>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderMadeState iret = new OrderMadeState();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.Barcode = dr["Barcode"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.ProcessedBy = dr["ProcessedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = (DateTime)dr["Processed"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Perimeter"]))
                        iret.Perimeter = (decimal)dr["Perimeter"];
                    iret.PaymentType = dr["PaymentType"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int CountOrderMadeStatesByBarcode_WorkFlowID(string barcode, Guid WorkFlowID)
        {
            string sql = "SELECT Count(1) as Qty FROM [BE_OrderMadeState] WHERE [Barcode]=@Barcode and [WorkFlowID] = @WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcode = new SqlParameter("Barcode", barcode);
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", WorkFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);
            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        #endregion
    }
}
