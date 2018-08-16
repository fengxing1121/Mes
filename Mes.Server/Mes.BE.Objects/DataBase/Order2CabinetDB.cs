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
       
        #region BE_Order2Cabinet InsertObject()
        public int InsertOrder2Cabinet(Order2Cabinet obj)
        {
            string sql = @"INSERT INTO[BE_Order2Cabinet]([CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@CabinetID
				, @OrderID
				, @CabinetGroup
				, @CabinetCode
				, @CabinetName
				, @Size
				, @MaterialStyle
				, @MaterialCategory
				, @Color
				, @Unit
				, @Qty
				, @Price
				, @CostPrice
				, @DealerPrice
				, @TotalAreal
				, @TotalLength
				, @FileUploadFlag
				, @IsTestAssemble
				, @BattchCode
				, @BattchIndex
				, @Sequence
				, @CabinetStatus
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", Convert2DBnull(obj.CabinetCode));
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", Convert2DBnull(obj.CabinetName));
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            SqlParameter pSize = new SqlParameter("Size", Convert2DBnull(obj.Size));
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", Convert2DBnull(obj.MaterialStyle));
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", Convert2DBnull(obj.MaterialCategory));
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", Convert2DBnull(obj.CostPrice));
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", Convert2DBnull(obj.DealerPrice));
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", Convert2DBnull(obj.FileUploadFlag));
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", Convert2DBnull(obj.IsTestAssemble));
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", Convert2DBnull(obj.BattchCode));
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", Convert2DBnull(obj.BattchIndex));
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", Convert2DBnull(obj.CabinetStatus));
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

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

        #region BE_Order2Cabinet UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrder2CabinetByOrderID_CabinetName(Order2Cabinet obj)
        {
            string sql = @"UPDATE [BE_Order2Cabinet] SET [CabinetID]=@CabinetID
				, [CabinetGroup]=@CabinetGroup
				, [CabinetCode]=@CabinetCode
				, [Size]=@Size
				, [MaterialStyle]=@MaterialStyle
				, [MaterialCategory]=@MaterialCategory
				, [Color]=@Color
				, [Unit]=@Unit
				, [Qty]=@Qty
				, [Price]=@Price
				, [CostPrice]=@CostPrice
				, [DealerPrice]=@DealerPrice
				, [TotalAreal]=@TotalAreal
				, [TotalLength]=@TotalLength
				, [FileUploadFlag]=@FileUploadFlag
				, [IsTestAssemble]=@IsTestAssemble
				, [BattchCode]=@BattchCode
				, [BattchIndex]=@BattchIndex
				, [Sequence]=@Sequence
				, [CabinetStatus]=@CabinetStatus
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [OrderID]=@OrderID AND [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", Convert2DBnull(obj.CabinetCode));
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            SqlParameter pSize = new SqlParameter("Size", Convert2DBnull(obj.Size));
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", Convert2DBnull(obj.MaterialStyle));
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", Convert2DBnull(obj.MaterialCategory));
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", Convert2DBnull(obj.CostPrice));
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", Convert2DBnull(obj.DealerPrice));
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", Convert2DBnull(obj.FileUploadFlag));
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", Convert2DBnull(obj.IsTestAssemble));
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", Convert2DBnull(obj.BattchCode));
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", Convert2DBnull(obj.BattchIndex));
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", Convert2DBnull(obj.CabinetStatus));
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

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

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", Convert2DBnull(obj.CabinetName));
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrder2CabinetByCabinetID(Order2Cabinet obj)
        {
            string sql = @"UPDATE [BE_Order2Cabinet] SET [OrderID]=@OrderID
				, [CabinetGroup]=@CabinetGroup
				, [CabinetCode]=@CabinetCode
				, [CabinetName]=@CabinetName
				, [Size]=@Size
				, [MaterialStyle]=@MaterialStyle
				, [MaterialCategory]=@MaterialCategory
				, [Color]=@Color
				, [Unit]=@Unit
				, [Qty]=@Qty
				, [Price]=@Price
				, [CostPrice]=@CostPrice
				, [DealerPrice]=@DealerPrice
				, [TotalAreal]=@TotalAreal
				, [TotalLength]=@TotalLength
				, [FileUploadFlag]=@FileUploadFlag
				, [IsTestAssemble]=@IsTestAssemble
				, [BattchCode]=@BattchCode
				, [BattchIndex]=@BattchIndex
				, [Sequence]=@Sequence
				, [CabinetStatus]=@CabinetStatus
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", Convert2DBnull(obj.CabinetCode));
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", Convert2DBnull(obj.CabinetName));
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            SqlParameter pSize = new SqlParameter("Size", Convert2DBnull(obj.Size));
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", Convert2DBnull(obj.MaterialStyle));
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", Convert2DBnull(obj.MaterialCategory));
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", Convert2DBnull(obj.CostPrice));
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", Convert2DBnull(obj.DealerPrice));
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", Convert2DBnull(obj.FileUploadFlag));
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", Convert2DBnull(obj.IsTestAssemble));
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", Convert2DBnull(obj.BattchCode));
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", Convert2DBnull(obj.BattchIndex));
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", Convert2DBnull(obj.CabinetStatus));
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

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

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetByOrderID_CabinetName(Guid orderID, string cabinetName)
        {
            string sql = @"DELETE [BE_Order2Cabinet] WHERE [OrderID]=@OrderID AND [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetByCabinetID(Guid cabinetID)
        {
            string sql = @"DELETE [BE_Order2Cabinet] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrder2CabinetByOrderID_CabinetName(Order2Cabinet obj)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [OrderID]=@OrderID AND [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", Convert2DBnull(obj.CabinetName));
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    obj.CabinetGroup = dr["CabinetGroup"].ToString();
                    obj.CabinetCode = dr["CabinetCode"].ToString();
                    obj.CabinetName = dr["CabinetName"].ToString();
                    obj.Size = dr["Size"].ToString();
                    obj.MaterialStyle = dr["MaterialStyle"].ToString();
                    obj.MaterialCategory = dr["MaterialCategory"].ToString();
                    obj.Color = dr["Color"].ToString();
                    obj.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        obj.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        obj.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        obj.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        obj.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        obj.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    obj.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        obj.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
                    obj.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public int LoadOrder2CabinetByCabinetID(Order2Cabinet obj)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    obj.CabinetGroup = dr["CabinetGroup"].ToString();
                    obj.CabinetCode = dr["CabinetCode"].ToString();
                    obj.CabinetName = dr["CabinetName"].ToString();
                    obj.Size = dr["Size"].ToString();
                    obj.MaterialStyle = dr["MaterialStyle"].ToString();
                    obj.MaterialCategory = dr["MaterialCategory"].ToString();
                    obj.Color = dr["Color"].ToString();
                    obj.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        obj.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        obj.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        obj.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        obj.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        obj.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    obj.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        obj.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
                    obj.CabinetStatus = dr["CabinetStatus"].ToString();
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

        #region BE_Order2Cabinet CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrder2Cabinets()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCabinetCode(string cabinetCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetCode]=@CabinetCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", cabinetCode);
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCabinetName(string cabinetName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsBySize(string size)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByColor(string color)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCostPrice(decimal costPrice)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CostPrice]=@CostPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", costPrice);
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByDealerPrice(decimal dealerPrice)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [DealerPrice]=@DealerPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", dealerPrice);
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByTotalAreal(decimal totalAreal)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByTotalLength(decimal totalLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByIsTestAssemble(bool isTestAssemble)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [IsTestAssemble]=@IsTestAssemble";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", isTestAssemble);
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByBattchCode(string battchCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [BattchCode]=@BattchCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", battchCode);
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByBattchIndex(int battchIndex)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [BattchIndex]=@BattchIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", battchIndex);
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCabinetStatus(string cabinetStatus)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetStatus]=@CabinetStatus";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", cabinetStatus);
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrder2Cabinets()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Order2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = "SELECT TOP 1 [CabinetGroup] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCabinetCode(string cabinetCode)
        {
            string sql = "SELECT TOP 1 [CabinetCode] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetCode]=@CabinetCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", cabinetCode);
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCabinetName(string cabinetName)
        {
            string sql = "SELECT TOP 1 [CabinetName] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsBySize(string size)
        {
            string sql = "SELECT TOP 1 [Size] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = "SELECT TOP 1 [MaterialStyle] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = "SELECT TOP 1 [MaterialCategory] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByColor(string color)
        {
            string sql = "SELECT TOP 1 [Color] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCostPrice(decimal costPrice)
        {
            string sql = "SELECT TOP 1 [CostPrice] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CostPrice]=@CostPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", costPrice);
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByDealerPrice(decimal dealerPrice)
        {
            string sql = "SELECT TOP 1 [DealerPrice] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [DealerPrice]=@DealerPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", dealerPrice);
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByTotalAreal(decimal totalAreal)
        {
            string sql = "SELECT TOP 1 [TotalAreal] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByTotalLength(decimal totalLength)
        {
            string sql = "SELECT TOP 1 [TotalLength] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = "SELECT TOP 1 [FileUploadFlag] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByIsTestAssemble(bool isTestAssemble)
        {
            string sql = "SELECT TOP 1 [IsTestAssemble] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [IsTestAssemble]=@IsTestAssemble";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", isTestAssemble);
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByBattchCode(string battchCode)
        {
            string sql = "SELECT TOP 1 [BattchCode] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [BattchCode]=@BattchCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", battchCode);
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByBattchIndex(int battchIndex)
        {
            string sql = "SELECT TOP 1 [BattchIndex] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [BattchIndex]=@BattchIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", battchIndex);
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCabinetStatus(string cabinetStatus)
        {
            string sql = "SELECT TOP 1 [CabinetStatus] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CabinetStatus]=@CabinetStatus";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", cabinetStatus);
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Order2Cabinet] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrder2Cabinets()
        {
            string sql = "DELETE FROM [BE_Order2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCabinetCode(string cabinetCode)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CabinetCode]=@CabinetCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", cabinetCode);
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCabinetName(string cabinetName)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsBySize(string size)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByColor(string color)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCostPrice(decimal costPrice)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CostPrice]=@CostPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", costPrice);
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByDealerPrice(decimal dealerPrice)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [DealerPrice]=@DealerPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", dealerPrice);
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByTotalAreal(decimal totalAreal)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByTotalLength(decimal totalLength)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByIsTestAssemble(bool isTestAssemble)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [IsTestAssemble]=@IsTestAssemble";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", isTestAssemble);
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByBattchCode(string battchCode)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [BattchCode]=@BattchCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", battchCode);
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByBattchIndex(int battchIndex)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [BattchIndex]=@BattchIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", battchIndex);
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCabinetStatus(string cabinetStatus)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CabinetStatus]=@CabinetStatus";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", cabinetStatus);
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Order2Cabinet] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Order2Cabinet> LoadOrder2Cabinets()
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCabinetCode(string cabinetCode)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CabinetCode]=@CabinetCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetCode = new SqlParameter("CabinetCode", cabinetCode);
            pCabinetCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetCode);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCabinetName(string cabinetName)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsBySize(string size)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByColor(string color)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByUnit(string unit)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByQty(decimal qty)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByPrice(decimal price)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCostPrice(decimal costPrice)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CostPrice]=@CostPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCostPrice = new SqlParameter("CostPrice", costPrice);
            pCostPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pCostPrice);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByDealerPrice(decimal dealerPrice)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [DealerPrice]=@DealerPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDealerPrice = new SqlParameter("DealerPrice", dealerPrice);
            pDealerPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDealerPrice);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByTotalAreal(decimal totalAreal)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByTotalLength(decimal totalLength)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [TotalLength]=@TotalLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", totalLength);
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByIsTestAssemble(bool isTestAssemble)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [IsTestAssemble]=@IsTestAssemble";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsTestAssemble = new SqlParameter("IsTestAssemble", isTestAssemble);
            pIsTestAssemble.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsTestAssemble);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByBattchCode(string battchCode)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [BattchCode]=@BattchCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", battchCode);
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByBattchIndex(int battchIndex)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [BattchIndex]=@BattchIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchIndex = new SqlParameter("BattchIndex", battchIndex);
            pBattchIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pBattchIndex);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsBySequence(int sequence)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCabinetStatus(string cabinetStatus)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CabinetStatus]=@CabinetStatus";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetStatus = new SqlParameter("CabinetStatus", cabinetStatus);
            pCabinetStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCabinetStatus);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByRemark(string remark)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCreated(DateTime created)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByModified(DateTime modified)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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
        public List<Order2Cabinet> LoadOrder2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [CabinetID]
				, [OrderID]
				, [CabinetGroup]
				, [CabinetCode]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [Price]
				, [CostPrice]
				, [DealerPrice]
				, [TotalAreal]
				, [TotalLength]
				, [FileUploadFlag]
				, [IsTestAssemble]
				, [BattchCode]
				, [BattchIndex]
				, [Sequence]
				, [CabinetStatus]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Order2Cabinet] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Order2Cabinet> ret = new List<Order2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Cabinet iret = new Order2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetCode = dr["CabinetCode"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["CostPrice"]))
                        iret.CostPrice = (decimal)dr["CostPrice"];
                    if (!Convert.IsDBNull(dr["DealerPrice"]))
                        iret.DealerPrice = (decimal)dr["DealerPrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["IsTestAssemble"]))
                        iret.IsTestAssemble = (bool)dr["IsTestAssemble"];
                    iret.BattchCode = dr["BattchCode"].ToString();
                    if (!Convert.IsDBNull(dr["BattchIndex"]))
                        iret.BattchIndex = (int)dr["BattchIndex"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    iret.CabinetStatus = dr["CabinetStatus"].ToString();
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

        #region BE_Order2Cabinet SearchObject()
        public SearchResult SearchPrintCabinetData(string BarcodeNo)
        {

            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT    [CabinetName]
                                              ,[Size]
                                              ,[MaterialStyle]
                                              ,[Color]
                                              ,[GroupNumber]
                                              ,[ProductNumber]
	                                          ,[BE_Order].[OrderNo]
	                                          ,[BE_Order].[OutOrderNo]
	                                          ,[CustomerName]
	                                          ,[PartnerName]
	                                          ,[BarcodeNo]
                                              ,[BE_Order].[OrderID]
                                              ,[PartnerOutCode]
                                              ,[ItemName]
                                              ,[ItemGroup]
                                              ,[ItemType]
                                              ,[MaterialType]
                                              ,[PackageSizeType]
                                              ,[PackageCategory],CabinetCode
                                          FROM [dbo].[BE_Order2Cabinet] as [BE_Order2Cabinet]
                                          LEFT JOIN [dbo].[BE_OrderDetail] AS [BE_OrderDetail] ON [BE_Order2Cabinet].[CabinetID]=[BE_OrderDetail].[CabinetID]
                                          LEFT JOIN [dbo].[BE_Order] AS [BE_Order] ON [BE_Order2Cabinet].OrderID=[BE_Order].OrderID
                                          LEFT JOIN [dbo].[BE_Partner] AS [BE_Partner] ON [BE_Partner].[PartnerID]=[BE_Order].[PartnerID]
                                          WHERE 1=1 ");

            if (!string.IsNullOrEmpty(BarcodeNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderDetail].[BarcodeNo", "mbBarcodeNo", BarcodeNo);
            }

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, " [OrderNo]", 0, 5);
        }

        public SearchResult SearchOrder2Cabinet(SearchOrder2CabinetArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
                                          [BE_Order].[OrderID]
                                          ,[BE_Order].[CustomerID]
                                          ,[BE_Order].[PartnerID]
                                          ,[BE_Order].[OrderNo]
                                          ,[BE_Order].[OutOrderNo]
                                          ,[BE_Order].[PurchaseNo]
                                          ,[BE_Order].[OrderType]
                                          ,[BE_Order].[CabinetType]
                                          ,[BE_Order].[CustomerName]
                                          ,[BE_Order].[Address]
                                          ,[BE_Order].[LinkMan]
                                          ,[BE_Order].[Mobile]
                                          ,[BE_Order].[BookingDate]
                                          ,[BE_Order].[ShipDate]
                                          ,[BE_Order].[Status]
                                          ,[BE_Order].[BattchNum]
                                          ,[BE_Order].[ManufactureDate]
                                          ,[BE_Order].[StepNo]
                                          ,[BE_Order].[IsStandard]
                                          ,[BE_Order].[IsOutsourcing]
                                          ,[BE_Order].[Created]
                                          ,[BE_Order].[CreatedBy]
                                          ,[BE_Order].[Modified]
                                          ,[BE_Order].[ModifiedBy]										
										  ,[BE_Partner].[PartnerName]
										  ,[BE_Customer].[Province]
										  ,[BE_Customer].[City]
										  ,[BE_Order2Cabinet].[CabinetID]
										  ,[BE_Order2Cabinet].[CabinetGroup]
										  ,[BE_Order2Cabinet].[CabinetName]
										  ,[BE_Order2Cabinet].[Size]
										  ,[BE_Order2Cabinet].[MaterialCategory]
										  ,[BE_Order2Cabinet].[MaterialStyle]
										  ,[BE_Order2Cabinet].[Color]
										  ,[BE_Order2Cabinet].[Qty]
										  ,[BE_Order2Cabinet].[Price]
										  ,[BE_Order2Cabinet].[CostPrice]
										  ,[BE_Order2Cabinet].[DealerPrice]
										  ,[BE_Order2Cabinet].[TotalAreal]
										  ,[BE_Order2Cabinet].[TotalLength]
										  ,[BE_Order2Cabinet].[FileUploadFlag]
										  ,[BE_Order2Cabinet].[IsTestAssemble]	
										  ,[BE_Order2Cabinet].[BattchCode]
										  ,[BE_Order2Cabinet].[BattchIndex]		
										  ,[BE_Order2Cabinet].[Sequence]
										  ,[BE_Order2Cabinet].[Unit]
										  ,[BE_Order2Cabinet].[Remark]
										  ,[BE_Order2Cabinet].[CabinetStatus]				  									  
                                      FROM 
		                                   [BE_Order]   
										   LEFT JOIN [BE_Order2Cabinet] on  [BE_Order].[OrderID] = [BE_Order2Cabinet].[OrderID]                                     
										   LEFT JOIN [BE_Partner] on [BE_Partner].[PartnerID] = [BE_Order].[PartnerID]
										   LEFT JOIN [BE_Customer] on [BE_Customer].[CustomerID] = [BE_Order].[CustomerID]
	                                  WHERE 1=1");

            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderID", "mbIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderType", "mbOrderTypes", args.OrderTypes);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[Status", "mbStatus", args.Status);

            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order2Cabinet].[CabinetID", "mbCabinetID", args.CabinetID.Value);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[CustomerID", "mbCustomerID", args.CustomerID.Value);
            }
            if (!string.IsNullOrEmpty(args.PurchaseNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[PurchaseNo", "mbPurchaseNo", args.PurchaseNo);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Address", "mbAddress", args.Address);
            }
            if (!string.IsNullOrEmpty(args.BattchNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[BattchNum", "mbBattchNum", args.BattchNo);
            }
            if (!string.IsNullOrEmpty(args.BattchCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchCode", "mbBattchCode", args.BattchCode);
            }
            if (!string.IsNullOrEmpty(args.CabinetType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[CabinetType", "mbCabinetType", args.CabinetType);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.CabinetName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.MaterialStyle))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialStyle", "mbMaterialStyle", args.MaterialStyle);
            }
            if (!string.IsNullOrEmpty(args.CabinetStatus))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetStatus", "mbCabinetStatus", args.CabinetStatus);
            }
            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }
            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }
            this.SetParameters_Between(mbBuilder, cmd, "BookingDate", "mbBookingDate", args.BookingDateFrom, args.BookingDateTo);
            this.SetParameters_Between(mbBuilder, cmd, "ShipDate", "mbBookingDate", args.ShipDateFrom, args.ShipDateTo);

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public int UpdateOrderBattchIndex(string BattchNum)
        {
            StringBuilder mbBuilder = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            mbBuilder.Append(@"Update 
	                                [BE_Order2Cabinet] 
                                set 
	                                [BattchIndex] = [m].[RowIndex]
                                from
                                (
	                                select 
			                                ROW_NUMBER() over(Order by [BE_Order].[OrderID],[Sequence]) as RowIndex
			                                ,[CabinetID]
		                                from 
			                                [BE_Order2Cabinet] 
			                                LEFT JOIN [BE_Order] on [BE_Order2Cabinet].[OrderID] = [BE_Order].[OrderID]
		                                where
			                                1=1
			                                and [BattchNum] = @BattchNum
                                ) m
                                LEFT JOIN [BE_Order2Cabinet] on [m].[CabinetID] = [BE_Order2Cabinet].[CabinetID]
                                LEFT JOIN [BE_Order] on [BE_Order].[OrderID] = [BE_Order2Cabinet].[OrderID]
                                WHERE [BattchNum] = @BattchNum");

            SqlParameter pBattchNum = new SqlParameter("BattchNum", BattchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            cmd.CommandText = mbBuilder.ToString();
            cmd.Connection = this.conn;
            cmd.Transaction = this.trans;
            return cmd.ExecuteNonQuery();
        }

        public int UpdateOrder2CabinetStatusByBattchCode(string BattchCode, string CabinetStatus)
        {
            StringBuilder mbBuilder = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            mbBuilder.Append(@"UPDATE [BE_Order2Cabinet] SET [CabinetStatus] = @CabinetStatus");
            mbBuilder.Append(" WHERE 1=1 and BattchCode=@BattchCode");
            cmd.Parameters.AddWithValue("CabinetStatus", CabinetStatus);
            cmd.Parameters.AddWithValue("BattchCode", BattchCode);
            cmd.CommandText = mbBuilder.ToString();
            cmd.Connection = this.conn;
            cmd.Transaction = this.trans;
            return cmd.ExecuteNonQuery();
        }

        public int GetTotalOrderCabinetQty(Guid OrderID)
        {
            string sql = "select Count(Qty) as TotalQty from BE_Order2Cabinet where OrderID = @OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", OrderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return int.Parse(objret.ToString());
        }
        public int GetTotalOrderBattchQty(string BattchNum)
        {
            string sql = "select Count(Qty) as TotalQty from BE_Order2Cabinet LEFT JOIN BE_Order on BE_Order2Cabinet.OrderID = BE_Order.OrderID where BattchNum = @BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", BattchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return int.Parse(objret.ToString());
        }

        public bool IsExistsCabinetNum(Guid OrderID, string CabinetNum)
        {
            string sql = "SELECT TOP 1 * FROM [BE_Order2Cabinet] WHERE [OrderID]=@OrderID and [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", OrderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetNum = new SqlParameter("CabinetName", CabinetNum);
            pCabinetNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}
