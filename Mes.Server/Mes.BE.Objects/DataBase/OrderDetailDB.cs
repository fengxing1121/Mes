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

        #region BE_OrderDetail InsertObject()
        public int InsertOrderDetail(OrderDetail obj)
        {
            string sql = @"INSERT INTO[BE_OrderDetail]([ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@ItemID
				, @ItemName
				, @ItemGroup
				, @ItemType
				, @MaterialType
				, @PackageSizeType
				, @PackageCategory
				, @BarcodeNo
				, @OrderID
				, @CabinetID
				, @ItemIndex
				, @TextureDirection
				, @HoleDesc
				, @MadeWidth
				, @MadeHeight
				, @MadeLength
				, @EndWidth
				, @EndLength
				, @Qty
				, @FrontLabel
				, @BackLabel
				, @Remarks
				, @Edge1
				, @Edge2
				, @Edge3
				, @Edge4
				, @EdgeDesc
				, @MadeBattchNum
				, @HasHole
				, @HoleFaceQty
				, @Hole1Qty
				, @Hole2Qty
				, @Hole3Qty
				, @Hole4Qty
				, @Hole5Qty
				, @Hole6Qty
				, @HasSlot
				, @HasFrontSlot
				, @HasBackSlot
				, @ItemCategory
				, @IsSpecialShap
				, @DamageQty
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", Convert2DBnull(obj.ItemGroup));
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", Convert2DBnull(obj.PackageSizeType));
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", Convert2DBnull(obj.PackageCategory));
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", Convert2DBnull(obj.ItemIndex));
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", Convert2DBnull(obj.TextureDirection));
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", Convert2DBnull(obj.HoleDesc));
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", Convert2DBnull(obj.EndWidth));
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            SqlParameter pEndLength = new SqlParameter("EndLength", Convert2DBnull(obj.EndLength));
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", Convert2DBnull(obj.FrontLabel));
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", Convert2DBnull(obj.BackLabel));
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            SqlParameter pEdge1 = new SqlParameter("Edge1", Convert2DBnull(obj.Edge1));
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            SqlParameter pEdge2 = new SqlParameter("Edge2", Convert2DBnull(obj.Edge2));
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            SqlParameter pEdge3 = new SqlParameter("Edge3", Convert2DBnull(obj.Edge3));
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            SqlParameter pEdge4 = new SqlParameter("Edge4", Convert2DBnull(obj.Edge4));
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", Convert2DBnull(obj.EdgeDesc));
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", Convert2DBnull(obj.MadeBattchNum));
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            SqlParameter pHasHole = new SqlParameter("HasHole", Convert2DBnull(obj.HasHole));
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", Convert2DBnull(obj.HoleFaceQty));
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", Convert2DBnull(obj.Hole1Qty));
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", Convert2DBnull(obj.Hole2Qty));
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", Convert2DBnull(obj.Hole3Qty));
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", Convert2DBnull(obj.Hole4Qty));
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", Convert2DBnull(obj.Hole5Qty));
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", Convert2DBnull(obj.Hole6Qty));
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", Convert2DBnull(obj.HasSlot));
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", Convert2DBnull(obj.HasFrontSlot));
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", Convert2DBnull(obj.HasBackSlot));
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", Convert2DBnull(obj.ItemCategory));
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", Convert2DBnull(obj.DamageQty));
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrderDetailByBarcodeNo(OrderDetail obj)
        {
            string sql = @"UPDATE [BE_OrderDetail] SET [ItemID]=@ItemID
				, [ItemName]=@ItemName
				, [ItemGroup]=@ItemGroup
				, [ItemType]=@ItemType
				, [MaterialType]=@MaterialType
				, [PackageSizeType]=@PackageSizeType
				, [PackageCategory]=@PackageCategory
				, [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
				, [ItemIndex]=@ItemIndex
				, [TextureDirection]=@TextureDirection
				, [HoleDesc]=@HoleDesc
				, [MadeWidth]=@MadeWidth
				, [MadeHeight]=@MadeHeight
				, [MadeLength]=@MadeLength
				, [EndWidth]=@EndWidth
				, [EndLength]=@EndLength
				, [Qty]=@Qty
				, [FrontLabel]=@FrontLabel
				, [BackLabel]=@BackLabel
				, [Remarks]=@Remarks
				, [Edge1]=@Edge1
				, [Edge2]=@Edge2
				, [Edge3]=@Edge3
				, [Edge4]=@Edge4
				, [EdgeDesc]=@EdgeDesc
				, [MadeBattchNum]=@MadeBattchNum
				, [HasHole]=@HasHole
				, [HoleFaceQty]=@HoleFaceQty
				, [Hole1Qty]=@Hole1Qty
				, [Hole2Qty]=@Hole2Qty
				, [Hole3Qty]=@Hole3Qty
				, [Hole4Qty]=@Hole4Qty
				, [Hole5Qty]=@Hole5Qty
				, [Hole6Qty]=@Hole6Qty
				, [HasSlot]=@HasSlot
				, [HasFrontSlot]=@HasFrontSlot
				, [HasBackSlot]=@HasBackSlot
				, [ItemCategory]=@ItemCategory
				, [IsSpecialShap]=@IsSpecialShap
				, [DamageQty]=@DamageQty
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", Convert2DBnull(obj.ItemGroup));
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", Convert2DBnull(obj.PackageSizeType));
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", Convert2DBnull(obj.PackageCategory));
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", Convert2DBnull(obj.ItemIndex));
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", Convert2DBnull(obj.TextureDirection));
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", Convert2DBnull(obj.HoleDesc));
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", Convert2DBnull(obj.EndWidth));
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            SqlParameter pEndLength = new SqlParameter("EndLength", Convert2DBnull(obj.EndLength));
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", Convert2DBnull(obj.FrontLabel));
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", Convert2DBnull(obj.BackLabel));
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            SqlParameter pEdge1 = new SqlParameter("Edge1", Convert2DBnull(obj.Edge1));
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            SqlParameter pEdge2 = new SqlParameter("Edge2", Convert2DBnull(obj.Edge2));
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            SqlParameter pEdge3 = new SqlParameter("Edge3", Convert2DBnull(obj.Edge3));
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            SqlParameter pEdge4 = new SqlParameter("Edge4", Convert2DBnull(obj.Edge4));
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", Convert2DBnull(obj.EdgeDesc));
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", Convert2DBnull(obj.MadeBattchNum));
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            SqlParameter pHasHole = new SqlParameter("HasHole", Convert2DBnull(obj.HasHole));
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", Convert2DBnull(obj.HoleFaceQty));
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", Convert2DBnull(obj.Hole1Qty));
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", Convert2DBnull(obj.Hole2Qty));
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", Convert2DBnull(obj.Hole3Qty));
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", Convert2DBnull(obj.Hole4Qty));
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", Convert2DBnull(obj.Hole5Qty));
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", Convert2DBnull(obj.Hole6Qty));
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", Convert2DBnull(obj.HasSlot));
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", Convert2DBnull(obj.HasFrontSlot));
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", Convert2DBnull(obj.HasBackSlot));
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", Convert2DBnull(obj.ItemCategory));
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", Convert2DBnull(obj.DamageQty));
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderDetailByItemID(OrderDetail obj)
        {
            string sql = @"UPDATE [BE_OrderDetail] SET [ItemName]=@ItemName
				, [ItemGroup]=@ItemGroup
				, [ItemType]=@ItemType
				, [MaterialType]=@MaterialType
				, [PackageSizeType]=@PackageSizeType
				, [PackageCategory]=@PackageCategory
				, [BarcodeNo]=@BarcodeNo
				, [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
				, [ItemIndex]=@ItemIndex
				, [TextureDirection]=@TextureDirection
				, [HoleDesc]=@HoleDesc
				, [MadeWidth]=@MadeWidth
				, [MadeHeight]=@MadeHeight
				, [MadeLength]=@MadeLength
				, [EndWidth]=@EndWidth
				, [EndLength]=@EndLength
				, [Qty]=@Qty
				, [FrontLabel]=@FrontLabel
				, [BackLabel]=@BackLabel
				, [Remarks]=@Remarks
				, [Edge1]=@Edge1
				, [Edge2]=@Edge2
				, [Edge3]=@Edge3
				, [Edge4]=@Edge4
				, [EdgeDesc]=@EdgeDesc
				, [MadeBattchNum]=@MadeBattchNum
				, [HasHole]=@HasHole
				, [HoleFaceQty]=@HoleFaceQty
				, [Hole1Qty]=@Hole1Qty
				, [Hole2Qty]=@Hole2Qty
				, [Hole3Qty]=@Hole3Qty
				, [Hole4Qty]=@Hole4Qty
				, [Hole5Qty]=@Hole5Qty
				, [Hole6Qty]=@Hole6Qty
				, [HasSlot]=@HasSlot
				, [HasFrontSlot]=@HasFrontSlot
				, [HasBackSlot]=@HasBackSlot
				, [ItemCategory]=@ItemCategory
				, [IsSpecialShap]=@IsSpecialShap
				, [DamageQty]=@DamageQty
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", Convert2DBnull(obj.ItemGroup));
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", Convert2DBnull(obj.PackageSizeType));
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", Convert2DBnull(obj.PackageCategory));
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", Convert2DBnull(obj.ItemIndex));
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", Convert2DBnull(obj.TextureDirection));
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", Convert2DBnull(obj.HoleDesc));
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", Convert2DBnull(obj.EndWidth));
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            SqlParameter pEndLength = new SqlParameter("EndLength", Convert2DBnull(obj.EndLength));
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", Convert2DBnull(obj.FrontLabel));
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", Convert2DBnull(obj.BackLabel));
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            SqlParameter pEdge1 = new SqlParameter("Edge1", Convert2DBnull(obj.Edge1));
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            SqlParameter pEdge2 = new SqlParameter("Edge2", Convert2DBnull(obj.Edge2));
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            SqlParameter pEdge3 = new SqlParameter("Edge3", Convert2DBnull(obj.Edge3));
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            SqlParameter pEdge4 = new SqlParameter("Edge4", Convert2DBnull(obj.Edge4));
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", Convert2DBnull(obj.EdgeDesc));
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", Convert2DBnull(obj.MadeBattchNum));
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            SqlParameter pHasHole = new SqlParameter("HasHole", Convert2DBnull(obj.HasHole));
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", Convert2DBnull(obj.HoleFaceQty));
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", Convert2DBnull(obj.Hole1Qty));
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", Convert2DBnull(obj.Hole2Qty));
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", Convert2DBnull(obj.Hole3Qty));
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", Convert2DBnull(obj.Hole4Qty));
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", Convert2DBnull(obj.Hole5Qty));
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", Convert2DBnull(obj.Hole6Qty));
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", Convert2DBnull(obj.HasSlot));
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", Convert2DBnull(obj.HasFrontSlot));
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", Convert2DBnull(obj.HasBackSlot));
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", Convert2DBnull(obj.ItemCategory));
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", Convert2DBnull(obj.DamageQty));
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderDetailByBatchNum(string BatchNum, string DetailStatus)
        {
            string sql = @"Update [BE_OrderDetail] set DetailStatus=@DetailStatus WHERE [BatchNum]=@BatchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBatchNumo = new SqlParameter("BatchNum", BatchNum);
            pBatchNumo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBatchNumo);

            SqlParameter pDetailStatus = new SqlParameter("DetailStatus", DetailStatus);
            pDetailStatus.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDetailStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailByBarcodeNo(string barcodeNo)
        {
            string sql = @"DELETE [BE_OrderDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_OrderDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrderDetailByBarcodeNo(OrderDetail obj)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.ItemGroup = dr["ItemGroup"].ToString();
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.MaterialType = dr["MaterialType"].ToString();
                    obj.PackageSizeType = dr["PackageSizeType"].ToString();
                    obj.PackageCategory = dr["PackageCategory"].ToString();
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        obj.ItemIndex = (int)dr["ItemIndex"];
                    obj.TextureDirection = dr["TextureDirection"].ToString();
                    obj.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        obj.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        obj.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        obj.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        obj.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        obj.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    obj.FrontLabel = dr["FrontLabel"].ToString();
                    obj.BackLabel = dr["BackLabel"].ToString();
                    obj.Remarks = dr["Remarks"].ToString();
                    obj.Edge1 = dr["Edge1"].ToString();
                    obj.Edge2 = dr["Edge2"].ToString();
                    obj.Edge3 = dr["Edge3"].ToString();
                    obj.Edge4 = dr["Edge4"].ToString();
                    obj.EdgeDesc = dr["EdgeDesc"].ToString();
                    obj.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        obj.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        obj.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        obj.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        obj.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        obj.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        obj.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        obj.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        obj.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        obj.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        obj.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        obj.HasBackSlot = (bool)dr["HasBackSlot"];
                    obj.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        obj.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        obj.DamageQty = (int)dr["DamageQty"];
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
        public int LoadOrderDetailByItemID(OrderDetail obj)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.ItemGroup = dr["ItemGroup"].ToString();
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.MaterialType = dr["MaterialType"].ToString();
                    obj.PackageSizeType = dr["PackageSizeType"].ToString();
                    obj.PackageCategory = dr["PackageCategory"].ToString();
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        obj.ItemIndex = (int)dr["ItemIndex"];
                    obj.TextureDirection = dr["TextureDirection"].ToString();
                    obj.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        obj.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        obj.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        obj.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        obj.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        obj.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    obj.FrontLabel = dr["FrontLabel"].ToString();
                    obj.BackLabel = dr["BackLabel"].ToString();
                    obj.Remarks = dr["Remarks"].ToString();
                    obj.Edge1 = dr["Edge1"].ToString();
                    obj.Edge2 = dr["Edge2"].ToString();
                    obj.Edge3 = dr["Edge3"].ToString();
                    obj.Edge4 = dr["Edge4"].ToString();
                    obj.EdgeDesc = dr["EdgeDesc"].ToString();
                    obj.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        obj.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        obj.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        obj.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        obj.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        obj.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        obj.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        obj.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        obj.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        obj.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        obj.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        obj.HasBackSlot = (bool)dr["HasBackSlot"];
                    obj.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        obj.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        obj.DamageQty = (int)dr["DamageQty"];
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

        #region BE_OrderDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrderDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByItemGroup(string itemGroup)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByItemType(string itemType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByMaterialType(string materialType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByPackageCategory(string packageCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByItemIndex(int itemIndex)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemIndex]=@ItemIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", itemIndex);
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByTextureDirection(string textureDirection)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHoleDesc(string holeDesc)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByMadeLength(decimal madeLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEndWidth(decimal endWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEndLength(decimal endLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByFrontLabel(string frontLabel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByBackLabel(string backLabel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByRemarks(string remarks)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEdge1(string edge1)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEdge2(string edge2)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEdge3(string edge3)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEdge4(string edge4)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByMadeBattchNum(string madeBattchNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeBattchNum]=@MadeBattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", madeBattchNum);
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHasHole(bool hasHole)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasHole]=@HasHole";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasHole = new SqlParameter("HasHole", hasHole);
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHoleFaceQty(int holeFaceQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HoleFaceQty]=@HoleFaceQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", holeFaceQty);
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHole1Qty(int hole1Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole1Qty]=@Hole1Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", hole1Qty);
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHole2Qty(int hole2Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole2Qty]=@Hole2Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", hole2Qty);
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHole3Qty(int hole3Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole3Qty]=@Hole3Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", hole3Qty);
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHole4Qty(int hole4Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole4Qty]=@Hole4Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", hole4Qty);
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHole5Qty(int hole5Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole5Qty]=@Hole5Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", hole5Qty);
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHole6Qty(int hole6Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole6Qty]=@Hole6Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", hole6Qty);
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHasSlot(bool hasSlot)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasSlot]=@HasSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", hasSlot);
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHasFrontSlot(bool hasFrontSlot)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasFrontSlot]=@HasFrontSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", hasFrontSlot);
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByHasBackSlot(bool hasBackSlot)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasBackSlot]=@HasBackSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", hasBackSlot);
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByItemCategory(string itemCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByDamageQty(int damageQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [DamageQty]=@DamageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", damageQty);
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrderDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_OrderDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByItemGroup(string itemGroup)
        {
            string sql = "SELECT TOP 1 [ItemGroup] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByItemType(string itemType)
        {
            string sql = "SELECT TOP 1 [ItemType] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByMaterialType(string materialType)
        {
            string sql = "SELECT TOP 1 [MaterialType] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = "SELECT TOP 1 [PackageSizeType] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByPackageCategory(string packageCategory)
        {
            string sql = "SELECT TOP 1 [PackageCategory] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT TOP 1 [BarcodeNo] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByItemIndex(int itemIndex)
        {
            string sql = "SELECT TOP 1 [ItemIndex] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemIndex]=@ItemIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", itemIndex);
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByTextureDirection(string textureDirection)
        {
            string sql = "SELECT TOP 1 [TextureDirection] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHoleDesc(string holeDesc)
        {
            string sql = "SELECT TOP 1 [HoleDesc] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT TOP 1 [MadeWidth] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT TOP 1 [MadeHeight] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByMadeLength(decimal madeLength)
        {
            string sql = "SELECT TOP 1 [MadeLength] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEndWidth(decimal endWidth)
        {
            string sql = "SELECT TOP 1 [EndWidth] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEndLength(decimal endLength)
        {
            string sql = "SELECT TOP 1 [EndLength] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByFrontLabel(string frontLabel)
        {
            string sql = "SELECT TOP 1 [FrontLabel] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByBackLabel(string backLabel)
        {
            string sql = "SELECT TOP 1 [BackLabel] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByRemarks(string remarks)
        {
            string sql = "SELECT TOP 1 [Remarks] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEdge1(string edge1)
        {
            string sql = "SELECT TOP 1 [Edge1] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEdge2(string edge2)
        {
            string sql = "SELECT TOP 1 [Edge2] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEdge3(string edge3)
        {
            string sql = "SELECT TOP 1 [Edge3] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEdge4(string edge4)
        {
            string sql = "SELECT TOP 1 [Edge4] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "SELECT TOP 1 [EdgeDesc] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByMadeBattchNum(string madeBattchNum)
        {
            string sql = "SELECT TOP 1 [MadeBattchNum] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [MadeBattchNum]=@MadeBattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", madeBattchNum);
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHasHole(bool hasHole)
        {
            string sql = "SELECT TOP 1 [HasHole] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasHole]=@HasHole";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasHole = new SqlParameter("HasHole", hasHole);
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHoleFaceQty(int holeFaceQty)
        {
            string sql = "SELECT TOP 1 [HoleFaceQty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HoleFaceQty]=@HoleFaceQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", holeFaceQty);
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHole1Qty(int hole1Qty)
        {
            string sql = "SELECT TOP 1 [Hole1Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole1Qty]=@Hole1Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", hole1Qty);
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHole2Qty(int hole2Qty)
        {
            string sql = "SELECT TOP 1 [Hole2Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole2Qty]=@Hole2Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", hole2Qty);
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHole3Qty(int hole3Qty)
        {
            string sql = "SELECT TOP 1 [Hole3Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole3Qty]=@Hole3Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", hole3Qty);
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHole4Qty(int hole4Qty)
        {
            string sql = "SELECT TOP 1 [Hole4Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole4Qty]=@Hole4Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", hole4Qty);
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHole5Qty(int hole5Qty)
        {
            string sql = "SELECT TOP 1 [Hole5Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole5Qty]=@Hole5Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", hole5Qty);
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHole6Qty(int hole6Qty)
        {
            string sql = "SELECT TOP 1 [Hole6Qty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Hole6Qty]=@Hole6Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", hole6Qty);
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHasSlot(bool hasSlot)
        {
            string sql = "SELECT TOP 1 [HasSlot] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasSlot]=@HasSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", hasSlot);
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHasFrontSlot(bool hasFrontSlot)
        {
            string sql = "SELECT TOP 1 [HasFrontSlot] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasFrontSlot]=@HasFrontSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", hasFrontSlot);
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByHasBackSlot(bool hasBackSlot)
        {
            string sql = "SELECT TOP 1 [HasBackSlot] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [HasBackSlot]=@HasBackSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", hasBackSlot);
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByItemCategory(string itemCategory)
        {
            string sql = "SELECT TOP 1 [ItemCategory] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "SELECT TOP 1 [IsSpecialShap] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByDamageQty(int damageQty)
        {
            string sql = "SELECT TOP 1 [DamageQty] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [DamageQty]=@DamageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", damageQty);
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_OrderDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrderDetails()
        {
            string sql = "DELETE FROM [BE_OrderDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByItemGroup(string itemGroup)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByItemType(string itemType)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByMaterialType(string materialType)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByPackageCategory(string packageCategory)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByItemIndex(int itemIndex)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ItemIndex]=@ItemIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", itemIndex);
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByTextureDirection(string textureDirection)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHoleDesc(string holeDesc)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByMadeLength(decimal madeLength)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEndWidth(decimal endWidth)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEndLength(decimal endLength)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByFrontLabel(string frontLabel)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByBackLabel(string backLabel)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByRemarks(string remarks)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEdge1(string edge1)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEdge2(string edge2)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEdge3(string edge3)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEdge4(string edge4)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByMadeBattchNum(string madeBattchNum)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [MadeBattchNum]=@MadeBattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", madeBattchNum);
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHasHole(bool hasHole)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [HasHole]=@HasHole";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasHole = new SqlParameter("HasHole", hasHole);
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHoleFaceQty(int holeFaceQty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [HoleFaceQty]=@HoleFaceQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", holeFaceQty);
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHole1Qty(int hole1Qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Hole1Qty]=@Hole1Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", hole1Qty);
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHole2Qty(int hole2Qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Hole2Qty]=@Hole2Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", hole2Qty);
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHole3Qty(int hole3Qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Hole3Qty]=@Hole3Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", hole3Qty);
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHole4Qty(int hole4Qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Hole4Qty]=@Hole4Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", hole4Qty);
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHole5Qty(int hole5Qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Hole5Qty]=@Hole5Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", hole5Qty);
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHole6Qty(int hole6Qty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Hole6Qty]=@Hole6Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", hole6Qty);
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHasSlot(bool hasSlot)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [HasSlot]=@HasSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", hasSlot);
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHasFrontSlot(bool hasFrontSlot)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [HasFrontSlot]=@HasFrontSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", hasFrontSlot);
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByHasBackSlot(bool hasBackSlot)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [HasBackSlot]=@HasBackSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", hasBackSlot);
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByItemCategory(string itemCategory)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByDamageQty(int damageQty)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [DamageQty]=@DamageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", damageQty);
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_OrderDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<OrderDetail> LoadOrderDetails()
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
			     ,[DetailStatus]
                 ,[BatchNum]
				 FROM [BE_OrderDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    iret.DetailStatus = dr["DetailStatus"].ToString();
                    iret.BatchNum = dr["BatchNum"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderDetail> LoadOrderDetailsByItemName(string itemName)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByItemGroup(string itemGroup)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByItemType(string itemType)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByMaterialType(string materialType)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByPackageCategory(string packageCategory)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByItemIndex(int itemIndex)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [ItemIndex]=@ItemIndex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemIndex = new SqlParameter("ItemIndex", itemIndex);
            pItemIndex.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemIndex);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByTextureDirection(string textureDirection)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHoleDesc(string holeDesc)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByMadeLength(decimal madeLength)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEndWidth(decimal endWidth)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEndLength(decimal endLength)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByQty(decimal qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByFrontLabel(string frontLabel)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByBackLabel(string backLabel)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByRemarks(string remarks)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEdge1(string edge1)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEdge2(string edge2)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEdge3(string edge3)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEdge4(string edge4)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeDesc);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByMadeBattchNum(string madeBattchNum)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [MadeBattchNum]=@MadeBattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeBattchNum = new SqlParameter("MadeBattchNum", madeBattchNum);
            pMadeBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMadeBattchNum);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHasHole(bool hasHole)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [HasHole]=@HasHole";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasHole = new SqlParameter("HasHole", hasHole);
            pHasHole.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasHole);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHoleFaceQty(int holeFaceQty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [HoleFaceQty]=@HoleFaceQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleFaceQty = new SqlParameter("HoleFaceQty", holeFaceQty);
            pHoleFaceQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHoleFaceQty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHole1Qty(int hole1Qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Hole1Qty]=@Hole1Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole1Qty = new SqlParameter("Hole1Qty", hole1Qty);
            pHole1Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole1Qty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHole2Qty(int hole2Qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Hole2Qty]=@Hole2Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole2Qty = new SqlParameter("Hole2Qty", hole2Qty);
            pHole2Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole2Qty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHole3Qty(int hole3Qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Hole3Qty]=@Hole3Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole3Qty = new SqlParameter("Hole3Qty", hole3Qty);
            pHole3Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole3Qty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHole4Qty(int hole4Qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Hole4Qty]=@Hole4Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole4Qty = new SqlParameter("Hole4Qty", hole4Qty);
            pHole4Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole4Qty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHole5Qty(int hole5Qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Hole5Qty]=@Hole5Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole5Qty = new SqlParameter("Hole5Qty", hole5Qty);
            pHole5Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole5Qty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHole6Qty(int hole6Qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Hole6Qty]=@Hole6Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHole6Qty = new SqlParameter("Hole6Qty", hole6Qty);
            pHole6Qty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pHole6Qty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHasSlot(bool hasSlot)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [HasSlot]=@HasSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasSlot = new SqlParameter("HasSlot", hasSlot);
            pHasSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasSlot);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHasFrontSlot(bool hasFrontSlot)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [HasFrontSlot]=@HasFrontSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasFrontSlot = new SqlParameter("HasFrontSlot", hasFrontSlot);
            pHasFrontSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasFrontSlot);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByHasBackSlot(bool hasBackSlot)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [HasBackSlot]=@HasBackSlot";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHasBackSlot = new SqlParameter("HasBackSlot", hasBackSlot);
            pHasBackSlot.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pHasBackSlot);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByItemCategory(string itemCategory)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pItemCategory);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByDamageQty(int damageQty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [DamageQty]=@DamageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDamageQty = new SqlParameter("DamageQty", damageQty);
            pDamageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDamageQty);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByModified(DateTime modified)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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
        public List<OrderDetail> LoadOrderDetailsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemGroup]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
				, [ItemIndex]
				, [TextureDirection]
				, [HoleDesc]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [Edge1]
				, [Edge2]
				, [Edge3]
				, [Edge4]
				, [EdgeDesc]
				, [MadeBattchNum]
				, [HasHole]
				, [HoleFaceQty]
				, [Hole1Qty]
				, [Hole2Qty]
				, [Hole3Qty]
				, [Hole4Qty]
				, [Hole5Qty]
				, [Hole6Qty]
				, [HasSlot]
				, [HasFrontSlot]
				, [HasBackSlot]
				, [ItemCategory]
				, [IsSpecialShap]
				, [DamageQty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_OrderDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["ItemIndex"]))
                        iret.ItemIndex = (int)dr["ItemIndex"];
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    iret.HoleDesc = dr["HoleDesc"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.Edge1 = dr["Edge1"].ToString();
                    iret.Edge2 = dr["Edge2"].ToString();
                    iret.Edge3 = dr["Edge3"].ToString();
                    iret.Edge4 = dr["Edge4"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    iret.MadeBattchNum = dr["MadeBattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["HasHole"]))
                        iret.HasHole = (bool)dr["HasHole"];
                    if (!Convert.IsDBNull(dr["HoleFaceQty"]))
                        iret.HoleFaceQty = (int)dr["HoleFaceQty"];
                    if (!Convert.IsDBNull(dr["Hole1Qty"]))
                        iret.Hole1Qty = (int)dr["Hole1Qty"];
                    if (!Convert.IsDBNull(dr["Hole2Qty"]))
                        iret.Hole2Qty = (int)dr["Hole2Qty"];
                    if (!Convert.IsDBNull(dr["Hole3Qty"]))
                        iret.Hole3Qty = (int)dr["Hole3Qty"];
                    if (!Convert.IsDBNull(dr["Hole4Qty"]))
                        iret.Hole4Qty = (int)dr["Hole4Qty"];
                    if (!Convert.IsDBNull(dr["Hole5Qty"]))
                        iret.Hole5Qty = (int)dr["Hole5Qty"];
                    if (!Convert.IsDBNull(dr["Hole6Qty"]))
                        iret.Hole6Qty = (int)dr["Hole6Qty"];
                    if (!Convert.IsDBNull(dr["HasSlot"]))
                        iret.HasSlot = (bool)dr["HasSlot"];
                    if (!Convert.IsDBNull(dr["HasFrontSlot"]))
                        iret.HasFrontSlot = (bool)dr["HasFrontSlot"];
                    if (!Convert.IsDBNull(dr["HasBackSlot"]))
                        iret.HasBackSlot = (bool)dr["HasBackSlot"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["DamageQty"]))
                        iret.DamageQty = (int)dr["DamageQty"];
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

        #region BE_OrderDetail SearchObject()
        public SearchResult SearchOrderDetail(SearchOrderDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BarcodeNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT
                                           [BE_Order].[OrderID]
                                          ,[OrderNo]
                                          ,[OutOrderNo]
                                          ,[OrderType]
                                          ,[CustomerName]
                                          ,[Address]
                                          ,[LinkMan]
                                          ,[Mobile]
                                          ,[BookingDate]
                                          ,[ShipDate]
                                          ,[Status]
                                          ,[BattchNum]
                                          ,[ManufactureDate] 
                                          ,[BE_Order].[IsStandard]
                                          ,[BE_Order].[IsOutsourcing]
	                                      ,[ItemID]  
	                                      ,[ItemName] 
	                                      ,[ItemCategory]                                         
										  ,[BE_OrderDetail].[BarcodeNo]                                                                                  
                                          ,[BE_OrderDetail].[ItemType]
                                          ,[MaterialType]
                                          ,[PackageSizeType]
                                          ,[PackageCategory]
                                          ,[BE_OrderDetail].[TextureDirection]
                                          ,[BE_OrderDetail].[HoleDesc]
                                          ,[BE_OrderDetail].[MadeWidth]
                                          ,[BE_OrderDetail].[MadeHeight]
                                          ,[BE_OrderDetail].[MadeLength]
                                          ,[BE_OrderDetail].[EndWidth]
                                          ,[BE_OrderDetail].[EndLength]
                                          ,[BE_OrderDetail].[Qty]
                                          ,[BE_OrderDetail].[DamageQty]
                                          ,[BE_OrderDetail].[FrontLabel]
                                          ,[BE_OrderDetail].[BackLabel]
                                          ,[BE_OrderDetail].[Remarks]
                                          ,[BE_OrderDetail].[CabinetID]
                                          ,[BE_Order2Cabinet].[BattchCode]
                                          ,[BE_Order2Cabinet].[CabinetGroup]
                                          ,[BE_Order2Cabinet].[CabinetCode]
                                          ,[BE_Order2Cabinet].[CabinetName]
										  ,[BE_Order2Cabinet].[Size]
										  ,[BE_Order2Cabinet].[Color]
										  ,[BE_Order2Cabinet].[CostPrice]
										  ,[BE_Order2Cabinet].[MaterialStyle]
										  ,[BE_Order2Cabinet].[BattchIndex]
										  ,[BE_Order2Cabinet].[MaterialCategory]
										  ,[BE_Order2Cabinet].[Sequence]										  
                                          ,[BE_OrderDetail].[ItemIndex]
                                          ,[BE_OrderDetail].[Edge1]
                                          ,[BE_OrderDetail].[Edge2]
                                          ,[BE_OrderDetail].[Edge3]
                                          ,[BE_OrderDetail].[Edge4]
                                          ,[BE_OrderDetail].[EdgeDesc]
                                          ,[BE_OrderDetail].[Created]
                                          ,[BE_OrderDetail].[MadeBattchNum]                                          
                                          ,[BE_OrderDetail].[CreatedBy]
                                          ,[BE_OrderDetail].[Modified]
                                          ,[BE_OrderDetail].[ModifiedBy]
                                          ,[BE_OrderDetail].[IsSpecialShap]
                                      FROM 
	                                      [BE_Order] with(nolock) 
										  LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_Order].[OrderID] = [BE_OrderDetail].[OrderID] 
										  LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_OrderDetail].[CabinetID] = [BE_Order2Cabinet].[CabinetID]										 
	                                  WHERE 1=1");

            this.SetParameters_In(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetNums);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderID", "mbOrderIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_OrderDetail].[CabinetID", "mbCabinetID", args.CabinetIDs);
            this.SetParameters_Contains(mbBuilder, cmd, "ItemName", args.ItemNames);
            this.SetParameters_NotContains(mbBuilder, cmd, "ItemName", args.RemoveItems);
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.Barcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[BarcodeNo", "mbBarcode", args.Barcode);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.MaterialType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialType", "mbMaterialType", args.MaterialType);
            }
            if (!string.IsNullOrEmpty(args.PackageSizeType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageSizeType", "mbPackageSizeType", args.PackageSizeType);
            }
            if (!string.IsNullOrEmpty(args.PackageCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageCategory", "mbPackageCategory", args.PackageCategory);
            }
            if (!string.IsNullOrEmpty(args.BattchNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchNum", "mbBattchNum", args.BattchNum);
            }
            if (!string.IsNullOrEmpty(args.BattchCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchCode", "mbBattchCode", args.BattchCode);
            }
            if (!string.IsNullOrEmpty(args.OrderStatus))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Status", "mbOrderStatus", args.OrderStatus);
            }
            if (!string.IsNullOrEmpty(args.CabinetStatus))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetStatus", "mbCabinetStatus", args.CabinetStatus);
            }
            if (!string.IsNullOrEmpty(args.ItemCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemCategory", "mbItemCategory", args.ItemCategory);
            }
            if (!string.IsNullOrEmpty(args.CabinetCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetCode", "mbCabinetCode", args.CabinetCode);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap);
            }
            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }
            if (args.MadeMinSize.HasValue)
            {
                mbBuilder.AppendFormat(" and (MadeLength>={0} or MadeWidth>={0})", args.MadeMinSize.Value);
            }
            if (args.MadeMaxSize.HasValue)
            {
                mbBuilder.AppendFormat(" and MadeLength<{0} and MadeWidth<{0}", args.MadeMaxSize.Value);
            }
            this.SetParameters_Between(mbBuilder, cmd, "MadeLength", "mbMadeLength", args.MadeLengthFrom, args.MadeLengthTo);
            this.SetParameters_Between(mbBuilder, cmd, "MadeWidth", "mbMadeWidth", args.MadeWidthFrom, args.MadeWidthTo);
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public List<OrderDetail> LoadOrderDetailsByWorkFlowID(Guid orderID, Guid WorkFlowID, int MadeQty)
        {
            string sql = @"SELECT		             [BE_OrderDetail].[ItemName]
			                                            ,[BE_OrderDetail].[ItemGroup]
                                                        ,[BE_OrderDetail].[ItemID]
			                                            ,[BE_OrderDetail].[ItemType]
			                                            ,[BE_OrderDetail].[MaterialType]
			                                            ,[BE_OrderDetail].[BarcodeNo]

                                FROM [BE_Order2Cabinet] AS [BE_Order2Cabinet] WITH(NOLOCK)
                                LEFT JOIN  [BE_OrderDetail] AS [BE_OrderDetail] WITH(NOLOCK)
                                ON [BE_Order2Cabinet].CabinetID=[BE_OrderDetail].CabinetID
                                LEFT JOIN  [BE_OrderWorkFlow] AS [BE_OrderWorkFlow] WITH(NOLOCK)
                                ON [BE_OrderDetail].ItemID=[BE_OrderWorkFlow].ItemID
				                WHERE [BE_Order2Cabinet].[OrderID]=@OrderID AND MadeQty=@MadeQty AND SourceWorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", MadeQty);
            pOrderID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", WorkFlowID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<OrderDetail> ret = new List<OrderDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderDetail iret = new OrderDetail();
                    if (!Convert.IsDBNull(dr["ItemName"]))
                        iret.ItemName = (string)dr["ItemName"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public SearchResult SearchAPSByTotal(SearchAPSDetailsArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[MaterialType] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT                              
                                          [MaterialType]
                                          ,[BE_OrderDetail].[MadeHeight]
                                          ,Sum([BE_OrderDetail].[MadeLength] * [BE_OrderDetail].[MadeWidth] * [BE_OrderDetail].[Qty]) *0.000001 as TotalAreal
                                          ,Sum([BE_OrderDetail].[Qty]) as [Qty]          
                                          ,CEILING(Sum([BE_OrderDetail].[MadeLength] * [BE_OrderDetail].[MadeWidth] * [BE_OrderDetail].[Qty]) * 0.000001/(1.22*2.44)) as [PlateQty]                               
                                      FROM 
	                                      [BE_Order] with(nolock) 
										  LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_Order].[OrderID] = [BE_OrderDetail].[OrderID] 
										  LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_OrderDetail].[CabinetID] = [BE_Order2Cabinet].[CabinetID]										 
	                                  WHERE 1=1
									  ");

            this.SetParameters_In(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetNums);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderID", "mbOrderIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_OrderDetail].[CabinetID", "mbCabinetID", args.CabinetIDs);
            this.SetParameters_NotContains(mbBuilder, cmd, "ItemName", args.RemoveItems);
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (!string.IsNullOrEmpty(args.Barcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[BarcodeNo", "mbBarcode", args.Barcode);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.MaterialType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialType", "mbMaterialType", args.MaterialType);
            }
            if (!string.IsNullOrEmpty(args.PackageSizeType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageSizeType", "mbPackageSizeType", args.PackageSizeType);
            }
            if (!string.IsNullOrEmpty(args.PackageCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageCategory", "mbPackageCategory", args.PackageCategory);
            }
            if (!string.IsNullOrEmpty(args.BattchNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchNum", "mbBattchNum", args.BattchNum);
            }
            if (!string.IsNullOrEmpty(args.OrderStatus))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Status", "mbOrderStatus", args.OrderStatus);
            }
            if (!string.IsNullOrEmpty(args.ItemCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemCategory", "mbItemCategory", args.ItemCategory);
            }
            if (!string.IsNullOrEmpty(args.CabinetCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetCode", "mbCabinetCode", args.CabinetCode);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap);
            }
            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }
            if (args.MadeMinSize.HasValue)
            {
                mbBuilder.AppendFormat(" and (MadeLength>={0} or MadeWidth>={0})", args.MadeMinSize.Value);
            }
            if (args.MadeMaxSize.HasValue)
            {
                mbBuilder.AppendFormat(" and MadeLength<{0} and MadeWidth<{0}", args.MadeMaxSize.Value);
            }
            this.SetParameters_Between(mbBuilder, cmd, "MadeLength", "mbMadeLength", args.MadeLengthFrom, args.MadeLengthTo);
            this.SetParameters_Between(mbBuilder, cmd, "MadeWidth", "mbMadeWidth", args.MadeWidthFrom, args.MadeWidthTo);

            mbBuilder.AppendFormat(@" GROUP BY
										  [MaterialType]
                                          ,[BE_OrderDetail].[MadeHeight]");
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        public SearchResult SearchAPSByOrderDetails(SearchAPSDetailsArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BarcodeNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT    
                                            OrderNo
                                          ,ItemID
                                          ,ShipDate                                      
	                                      ,[ItemName] 	                                      
                                          ,[MaterialType]                                     
                                          ,[BE_OrderDetail].[MadeWidth]
                                          ,[BE_OrderDetail].[MadeHeight]
                                          ,[BE_OrderDetail].[MadeLength]
                                          ,[BE_OrderDetail].[EndWidth]
                                          ,[BE_OrderDetail].[EndLength]
                                          ,[BE_OrderDetail].[Qty]                                          
                                      FROM 
	                                      [BE_Order] with(nolock) 
										  LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_Order].[OrderID] = [BE_OrderDetail].[OrderID] 
										  LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_OrderDetail].[CabinetID] = [BE_Order2Cabinet].[CabinetID]										 
	                                  WHERE 1=1 and DetailStatus='T' and ItemID is not null 
									  ");
            //WHERE 1=1 and (len(BatchNum)=0 or BatchNum is null) and ItemID is not null 
            this.SetParameters_In(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetNums);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderID", "mbOrderIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_OrderDetail].[CabinetID", "mbCabinetID", args.CabinetIDs);
            this.SetParameters_NotContains(mbBuilder, cmd, "ItemName", args.RemoveItems);
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (!string.IsNullOrEmpty(args.Barcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[BarcodeNo", "mbBarcode", args.Barcode);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.MaterialType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialType", "mbMaterialType", args.MaterialType);
            }
            if (!string.IsNullOrEmpty(args.PackageSizeType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageSizeType", "mbPackageSizeType", args.PackageSizeType);
            }
            if (!string.IsNullOrEmpty(args.PackageCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageCategory", "mbPackageCategory", args.PackageCategory);
            }
            if (!string.IsNullOrEmpty(args.BattchNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchNum", "mbBattchNum", args.BattchNum);
            }
            if (!string.IsNullOrEmpty(args.OrderStatus))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Status", "mbOrderStatus", args.OrderStatus);
            }
            if (!string.IsNullOrEmpty(args.ItemCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemCategory", "mbItemCategory", args.ItemCategory);
            }
            if (!string.IsNullOrEmpty(args.CabinetCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetCode", "mbCabinetCode", args.CabinetCode);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap);
            }
            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }
            if (args.MadeMinSize.HasValue)
            {
                mbBuilder.AppendFormat(" and (MadeLength>={0} or MadeWidth>={0})", args.MadeMinSize.Value);
            }
            if (args.MadeMaxSize.HasValue)
            {
                mbBuilder.AppendFormat(" and MadeLength<{0} and MadeWidth<{0}", args.MadeMaxSize.Value);
            }
            //Liu
            if (!string.IsNullOrEmpty(args.ShipDate))
            {
                mbBuilder.AppendFormat(" and ShipDate<='{0}'", args.ShipDate);
            }
            this.SetParameters_Between(mbBuilder, cmd, "MadeLength", "mbMadeLength", args.MadeLengthFrom, args.MadeLengthTo);
            this.SetParameters_Between(mbBuilder, cmd, "MadeWidth", "mbMadeWidth", args.MadeWidthFrom, args.MadeWidthTo);

            //mbBuilder.AppendFormat(@" GROUP BY
            //[ItemName] 	                                      
            //                              ,[MaterialType]                                     
            //                              ,[BE_OrderDetail].[MadeWidth]
            //                              ,[BE_OrderDetail].[MadeHeight]
            //                              ,[BE_OrderDetail].[MadeLength]
            //                              ,[BE_OrderDetail].[EndWidth]
            //                              ,[BE_OrderDetail].[EndLength]");
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        public SearchResult SearchAPSByRemoveDetails(SearchAPSDetailsArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BarcodeNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT                                          
	                                      [ItemName] 	                                      
                                          ,[MaterialType]                                     
                                          ,[BE_OrderDetail].[MadeWidth]
                                          ,[BE_OrderDetail].[MadeHeight]
                                          ,[BE_OrderDetail].[MadeLength]
                                          ,[BE_OrderDetail].[EndWidth]
                                          ,[BE_OrderDetail].[EndLength]
                                          ,Sum([BE_OrderDetail].[Qty]) as [Qty]                                         
                                      FROM 
	                                      [BE_Order] with(nolock) 
										  LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_Order].[OrderID] = [BE_OrderDetail].[OrderID] 
										  LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_OrderDetail].[CabinetID] = [BE_Order2Cabinet].[CabinetID]										 
	                                  WHERE 1=1
									  ");

            this.SetParameters_In(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetNums);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderID", "mbOrderIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_OrderDetail].[CabinetID", "mbCabinetID", args.CabinetIDs);
            this.SetParameters_Contains(mbBuilder, cmd, "ItemName", args.RemoveItems);
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (!string.IsNullOrEmpty(args.Barcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[BarcodeNo", "mbBarcode", args.Barcode);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.MaterialType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialType", "mbMaterialType", args.MaterialType);
            }
            if (!string.IsNullOrEmpty(args.PackageSizeType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageSizeType", "mbPackageSizeType", args.PackageSizeType);
            }
            if (!string.IsNullOrEmpty(args.PackageCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageCategory", "mbPackageCategory", args.PackageCategory);
            }
            if (!string.IsNullOrEmpty(args.BattchNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BattchNum", "mbBattchNum", args.BattchNum);
            }
            if (!string.IsNullOrEmpty(args.OrderStatus))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Status", "mbOrderStatus", args.OrderStatus);
            }
            if (!string.IsNullOrEmpty(args.ItemCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemCategory", "mbItemCategory", args.ItemCategory);
            }
            if (!string.IsNullOrEmpty(args.CabinetCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetCode", "mbCabinetCode", args.CabinetCode);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap);
            }
            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }

            mbBuilder.AppendFormat(@" GROUP BY
										  [ItemName] 	                                      
                                          ,[MaterialType]                                     
                                          ,[BE_OrderDetail].[MadeWidth]
                                          ,[BE_OrderDetail].[MadeHeight]
                                          ,[BE_OrderDetail].[MadeLength]
                                          ,[BE_OrderDetail].[EndWidth]
                                          ,[BE_OrderDetail].[EndLength]");
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
