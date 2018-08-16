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
       
        #region BE_OrderScheduling InsertObject()
        public int InsertOrderScheduling(OrderScheduling obj)
        {
            string sql = @"INSERT INTO[BE_OrderScheduling]([MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@MadeID
				, @OrderID
				, @CabinetID
				, @BattchNum
				, @WorkFlowID
				, @TotalQty
				, @MadeTotalQty
				, @TotalAreal
				, @MadeTotalAreal
				, @TotalLength
				, @MadeTotalLength
				, @Estimated
				, @MadeStarted
				, @MadeEnded
				, @ProductionPeriod
				, @Sequence
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", Convert2DBnull(obj.MadeID));
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", Convert2DBnull(obj.MadeTotalQty));
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", Convert2DBnull(obj.MadeTotalAreal));
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", Convert2DBnull(obj.MadeTotalLength));
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            SqlParameter pEstimated = new SqlParameter("Estimated", Convert2DBnull(obj.Estimated));
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", Convert2DBnull(obj.MadeStarted));
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", Convert2DBnull(obj.MadeEnded));
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", Convert2DBnull(obj.ProductionPeriod));
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

        #region BE_OrderScheduling UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrderSchedulingByCabinetID_WorkFlowID(OrderScheduling obj)
        {
            string sql = @"UPDATE [BE_OrderScheduling] SET [MadeID]=@MadeID
				, [OrderID]=@OrderID
				, [BattchNum]=@BattchNum
				, [TotalQty]=@TotalQty
				, [MadeTotalQty]=@MadeTotalQty
				, [TotalAreal]=@TotalAreal
				, [MadeTotalAreal]=@MadeTotalAreal
				, [TotalLength]=@TotalLength
				, [MadeTotalLength]=@MadeTotalLength
				, [Estimated]=@Estimated
				, [MadeStarted]=@MadeStarted
				, [MadeEnded]=@MadeEnded
				, [ProductionPeriod]=@ProductionPeriod
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CabinetID]=@CabinetID AND [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", Convert2DBnull(obj.MadeID));
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", Convert2DBnull(obj.MadeTotalQty));
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", Convert2DBnull(obj.MadeTotalAreal));
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", Convert2DBnull(obj.MadeTotalLength));
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            SqlParameter pEstimated = new SqlParameter("Estimated", Convert2DBnull(obj.Estimated));
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", Convert2DBnull(obj.MadeStarted));
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", Convert2DBnull(obj.MadeEnded));
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", Convert2DBnull(obj.ProductionPeriod));
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderSchedulingByMadeID(OrderScheduling obj)
        {
            string sql = @"UPDATE [BE_OrderScheduling] SET [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
				, [BattchNum]=@BattchNum
				, [WorkFlowID]=@WorkFlowID
				, [TotalQty]=@TotalQty
				, [MadeTotalQty]=@MadeTotalQty
				, [TotalAreal]=@TotalAreal
				, [MadeTotalAreal]=@MadeTotalAreal
				, [TotalLength]=@TotalLength
				, [MadeTotalLength]=@MadeTotalLength
				, [Estimated]=@Estimated
				, [MadeStarted]=@MadeStarted
				, [MadeEnded]=@MadeEnded
				, [ProductionPeriod]=@ProductionPeriod
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", Convert2DBnull(obj.MadeTotalQty));
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", Convert2DBnull(obj.MadeTotalAreal));
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", Convert2DBnull(obj.MadeTotalLength));
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            SqlParameter pEstimated = new SqlParameter("Estimated", Convert2DBnull(obj.Estimated));
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", Convert2DBnull(obj.MadeStarted));
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", Convert2DBnull(obj.MadeEnded));
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", Convert2DBnull(obj.ProductionPeriod));
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pMadeID = new SqlParameter("MadeID", Convert2DBnull(obj.MadeID));
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingByCabinetID_WorkFlowID(Guid cabinetID, Guid workFlowID)
        {
            string sql = @"DELETE [BE_OrderScheduling] WHERE [CabinetID]=@CabinetID AND [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingByMadeID(Guid madeID)
        {
            string sql = @"DELETE [BE_OrderScheduling] WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", madeID);
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrderSchedulingByCabinetID_WorkFlowID(OrderScheduling obj)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID AND [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        obj.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    obj.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        obj.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        obj.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        obj.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        obj.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        obj.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        obj.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        obj.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        obj.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        obj.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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
        public int LoadOrderSchedulingByMadeID(OrderScheduling obj)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", Convert2DBnull(obj.MadeID));
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        obj.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    obj.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        obj.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        obj.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        obj.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        obj.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        obj.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        obj.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        obj.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        obj.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        obj.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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

        #region BE_OrderScheduling CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrderSchedulings()
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByMadeID(Guid madeID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", madeID);
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByBattchNum(string battchNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByTotalQty(int totalQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByMadeTotalQty(int madeTotalQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeTotalQty]=@MadeTotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", madeTotalQty);
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByTotalAreal(decimal totalAreal)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByMadeTotalAreal(decimal madeTotalAreal)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeTotalAreal]=@MadeTotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", madeTotalAreal);
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByTotalLength(decimal totalLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByMadeTotalLength(decimal madeTotalLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeTotalLength]=@MadeTotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", madeTotalLength);
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByEstimated(DateTime estimated)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Estimated]=@Estimated";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEstimated = new SqlParameter("Estimated", estimated);
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByMadeStarted(DateTime madeStarted)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeStarted]=@MadeStarted";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", madeStarted);
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByMadeEnded(DateTime madeEnded)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeEnded]=@MadeEnded";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", madeEnded);
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByProductionPeriod(decimal productionPeriod)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [ProductionPeriod]=@ProductionPeriod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", productionPeriod);
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrderSchedulings()
        {
            string sql = "SELECT TOP 1 * FROM [BE_OrderScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByMadeID(Guid madeID)
        {
            string sql = "SELECT TOP 1 [MadeID] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", madeID);
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByBattchNum(string battchNum)
        {
            string sql = "SELECT TOP 1 [BattchNum] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT TOP 1 [WorkFlowID] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByTotalQty(int totalQty)
        {
            string sql = "SELECT TOP 1 [TotalQty] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByMadeTotalQty(int madeTotalQty)
        {
            string sql = "SELECT TOP 1 [MadeTotalQty] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeTotalQty]=@MadeTotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", madeTotalQty);
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByTotalAreal(decimal totalAreal)
        {
            string sql = "SELECT TOP 1 [TotalAreal] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByMadeTotalAreal(decimal madeTotalAreal)
        {
            string sql = "SELECT TOP 1 [MadeTotalAreal] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeTotalAreal]=@MadeTotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", madeTotalAreal);
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByTotalLength(decimal totalLength)
        {
            string sql = "SELECT TOP 1 [TotalLength] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByMadeTotalLength(decimal madeTotalLength)
        {
            string sql = "SELECT TOP 1 [MadeTotalLength] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeTotalLength]=@MadeTotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", madeTotalLength);
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByEstimated(DateTime estimated)
        {
            string sql = "SELECT TOP 1 [Estimated] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Estimated]=@Estimated";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEstimated = new SqlParameter("Estimated", estimated);
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByMadeStarted(DateTime madeStarted)
        {
            string sql = "SELECT TOP 1 [MadeStarted] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeStarted]=@MadeStarted";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", madeStarted);
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByMadeEnded(DateTime madeEnded)
        {
            string sql = "SELECT TOP 1 [MadeEnded] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [MadeEnded]=@MadeEnded";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", madeEnded);
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByProductionPeriod(decimal productionPeriod)
        {
            string sql = "SELECT TOP 1 [ProductionPeriod] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [ProductionPeriod]=@ProductionPeriod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", productionPeriod);
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_OrderScheduling] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrderSchedulings()
        {
            string sql = "DELETE FROM [BE_OrderScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByMadeID(Guid madeID)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", madeID);
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByBattchNum(string battchNum)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByWorkFlowID(Guid workFlowID)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByTotalQty(int totalQty)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByMadeTotalQty(int madeTotalQty)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [MadeTotalQty]=@MadeTotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", madeTotalQty);
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByTotalAreal(decimal totalAreal)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByMadeTotalAreal(decimal madeTotalAreal)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [MadeTotalAreal]=@MadeTotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", madeTotalAreal);
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByTotalLength(decimal totalLength)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByMadeTotalLength(decimal madeTotalLength)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [MadeTotalLength]=@MadeTotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", madeTotalLength);
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByEstimated(DateTime estimated)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [Estimated]=@Estimated";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEstimated = new SqlParameter("Estimated", estimated);
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByMadeStarted(DateTime madeStarted)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [MadeStarted]=@MadeStarted";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", madeStarted);
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByMadeEnded(DateTime madeEnded)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [MadeEnded]=@MadeEnded";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", madeEnded);
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByProductionPeriod(decimal productionPeriod)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [ProductionPeriod]=@ProductionPeriod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", productionPeriod);
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_OrderScheduling] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<OrderScheduling> LoadOrderSchedulings()
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByMadeID(Guid madeID)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [MadeID]=@MadeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeID = new SqlParameter("MadeID", madeID);
            pMadeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMadeID);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByBattchNum(string battchNum)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByWorkFlowID(Guid workFlowID)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByTotalQty(int totalQty)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByMadeTotalQty(int madeTotalQty)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [MadeTotalQty]=@MadeTotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalQty = new SqlParameter("MadeTotalQty", madeTotalQty);
            pMadeTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeTotalQty);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByTotalAreal(decimal totalAreal)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByMadeTotalAreal(decimal madeTotalAreal)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [MadeTotalAreal]=@MadeTotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", madeTotalAreal);
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByTotalLength(decimal totalLength)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByMadeTotalLength(decimal madeTotalLength)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [MadeTotalLength]=@MadeTotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalLength = new SqlParameter("MadeTotalLength", madeTotalLength);
            pMadeTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalLength);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByEstimated(DateTime estimated)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [Estimated]=@Estimated";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEstimated = new SqlParameter("Estimated", estimated);
            pEstimated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEstimated);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByMadeStarted(DateTime madeStarted)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [MadeStarted]=@MadeStarted";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeStarted = new SqlParameter("MadeStarted", madeStarted);
            pMadeStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeStarted);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByMadeEnded(DateTime madeEnded)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [MadeEnded]=@MadeEnded";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeEnded = new SqlParameter("MadeEnded", madeEnded);
            pMadeEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pMadeEnded);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByProductionPeriod(decimal productionPeriod)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [ProductionPeriod]=@ProductionPeriod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionPeriod = new SqlParameter("ProductionPeriod", productionPeriod);
            pProductionPeriod.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pProductionPeriod);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsBySequence(int sequence)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByCreated(DateTime created)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByModified(DateTime modified)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<OrderScheduling> LoadOrderSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [MadeID]
				, [OrderID]
				, [CabinetID]
				, [BattchNum]
				, [WorkFlowID]
				, [TotalQty]
				, [MadeTotalQty]
				, [TotalAreal]
				, [MadeTotalAreal]
				, [TotalLength]
				, [MadeTotalLength]
				, [Estimated]
				, [MadeStarted]
				, [MadeEnded]
				, [ProductionPeriod]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderScheduling] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<OrderScheduling> ret = new List<OrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderScheduling iret = new OrderScheduling();
                    if (!Convert.IsDBNull(dr["MadeID"]))
                        iret.MadeID = (Guid)dr["MadeID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeTotalQty"]))
                        iret.MadeTotalQty = (int)dr["MadeTotalQty"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["MadeTotalLength"]))
                        iret.MadeTotalLength = (decimal)dr["MadeTotalLength"];
                    if (!Convert.IsDBNull(dr["Estimated"]))
                        iret.Estimated = (DateTime)dr["Estimated"];
                    if (!Convert.IsDBNull(dr["MadeStarted"]))
                        iret.MadeStarted = (DateTime)dr["MadeStarted"];
                    if (!Convert.IsDBNull(dr["MadeEnded"]))
                        iret.MadeEnded = (DateTime)dr["MadeEnded"];
                    if (!Convert.IsDBNull(dr["ProductionPeriod"]))
                        iret.ProductionPeriod = (decimal)dr["ProductionPeriod"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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

        #region BE_OrderScheduling SearchObject()
        public SearchResult SearchOrderScheduling(SearchOrderSchedulingArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BattchNum],[Sequence]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_OrderScheduling].[MadeID]
                                          ,[BE_OrderScheduling].[OrderID]
                                          ,[BE_OrderScheduling].[BattchNum]
                                          ,[BE_OrderScheduling].[WorkFlowID]
                                          ,[BE_OrderScheduling].[TotalQty]
                                          ,[BE_OrderScheduling].[TotalAreal]
                                          ,[BE_OrderScheduling].[TotalLength]
                                          ,[BE_OrderScheduling].[MadeTotalQty]      
                                          ,[BE_OrderScheduling].[MadeTotalAreal]   
                                          ,[BE_OrderScheduling].[MadeTotalLength]
                                          ,[BE_OrderScheduling].[Estimated]
                                          ,[BE_OrderScheduling].[MadeStarted]
                                          ,[BE_OrderScheduling].[MadeEnded]
                                          ,[BE_OrderScheduling].[ProductionPeriod]
                                          ,[BE_OrderScheduling].[Created]
                                          ,[BE_OrderScheduling].[CreatedBy]
                                          ,[BE_OrderScheduling].[Modified]
                                          ,[BE_OrderScheduling].[ModifiedBy]
                                          ,[BE_OrderScheduling].[Sequence]
	                                      ,[BE_WorkFlow].[WorkFlowCode]
	                                      ,[BE_WorkFlow].[WorkFlowName]
	                                      ,[BE_WorkFlow].[ImageUrl]
	                                      ,[BE_Order].[OrderNo]
	                                      ,[BE_Order].[OrderType]
	                                      ,[BE_Order].[BookingDate]
	                                      ,[BE_Order].[ShipDate]
	                                      ,[BE_Order2Cabinet].[CabinetName]	
	                                      ,[BE_Order2Cabinet].[CabinetCode]		   
                                      FROM 
	                                    [BE_OrderScheduling] with(nolock) 
                                        LEFT JOIN [BE_WorkFlow] with(nolock) on [BE_OrderScheduling].[WorkFlowID] = [BE_WorkFlow].[WorkFlowID]
	                                    LEFT JOIN [BE_Order] with(nolock) on [BE_OrderScheduling].[OrderID] = [BE_Order].[OrderID]  
                                        LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_OrderScheduling].[CabinetID] = [BE_Order2Cabinet].[CabinetID]                                                                               
	                                  WHERE 1=1");


            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderScheduling].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (args.WorkFlowID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderScheduling].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkFlowCode", "mbWorkFlowCode", args.WorkFlowCode);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkFlowName", "mbWorkFlowName", args.WorkFlowName);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.BatchNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderScheduling].[BattchNum", "mbBatchNo", args.BatchNo);
            }
            this.SetParameters_Between(mbBuilder, cmd, "BookingDate", "mbBookingDate", args.BookingDateFrom, args.BookingDateTo);
            this.SetParameters_Between(mbBuilder, cmd, "ShipDate", "mbShipDate", args.ShipDateFrom, args.ShipDateTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
