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

        #region BE_SolutionDetail InsertObject()
        public int InsertSolutionDetail(SolutionDetail obj)
        {
            string sql = @"INSERT INTO[BE_SolutionDetail]([ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
                , [FilePathUrl]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@ItemID
				, @ItemName
				, @ItemType
				, @MaterialType
				, @BarcodeNo
				, @SolutionID
				, @CabinetID
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
				, @IsSpecialShap
                , @FilePathUrl
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

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pFilePathUrl = new SqlParameter("FilePathUrl", Convert2DBnull(obj.FilePathUrl));
            pFilePathUrl.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFilePathUrl);

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

        #region BE_SolutionDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSolutionDetailByBarcodeNo(SolutionDetail obj)
        {
            string sql = @"UPDATE [BE_SolutionDetail] SET [ItemID]=@ItemID
				, [ItemName]=@ItemName
				, [ItemType]=@ItemType
				, [MaterialType]=@MaterialType
				, [SolutionID]=@SolutionID
				, [CabinetID]=@CabinetID
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
				, [IsSpecialShap]=@IsSpecialShap
                , [FilePathUrl]=@FilePathUrl
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

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pFilePathUrl = new SqlParameter("FilePathUrl", Convert2DBnull(obj.FilePathUrl));
            pFilePathUrl.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFilePathUrl);

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
        public int UpdateSolutionDetailByItemID(SolutionDetail obj)
        {
            string sql = @"UPDATE [BE_SolutionDetail] SET [ItemName]=@ItemName
				, [ItemType]=@ItemType
				, [MaterialType]=@MaterialType
				, [BarcodeNo]=@BarcodeNo
				, [SolutionID]=@SolutionID
				, [CabinetID]=@CabinetID
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
				, [IsSpecialShap]=@IsSpecialShap
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

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
        public int DeleteSolutionDetailByBarcodeNo(string barcodeNo)
        {
            string sql = @"DELETE [BE_SolutionDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_SolutionDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSolutionDetailByBarcodeNo(SolutionDetail obj)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
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
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.MaterialType = dr["MaterialType"].ToString();
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        obj.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public int LoadSolutionDetailByItemID(SolutionDetail obj)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
                , [FilePathUrl]
 				FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
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
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.MaterialType = dr["MaterialType"].ToString();
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        obj.IsSpecialShap = (bool)dr["IsSpecialShap"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    obj.ModifiedBy = dr["ModifiedBy"].ToString();
                    obj.FilePathUrl = dr["FilePathUrl"].ToString();

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

        #region BE_SolutionDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSolutionDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByItemType(string itemType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByMaterialType(string materialType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByTextureDirection(string textureDirection)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByHoleDesc(string holeDesc)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByMadeLength(decimal madeLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEndWidth(decimal endWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEndLength(decimal endLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByFrontLabel(string frontLabel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByBackLabel(string backLabel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByRemarks(string remarks)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEdge1(string edge1)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEdge2(string edge2)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEdge3(string edge3)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEdge4(string edge4)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSolutionDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_SolutionDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByItemType(string itemType)
        {
            string sql = "SELECT TOP 1 [ItemType] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByMaterialType(string materialType)
        {
            string sql = "SELECT TOP 1 [MaterialType] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT TOP 1 [BarcodeNo] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByTextureDirection(string textureDirection)
        {
            string sql = "SELECT TOP 1 [TextureDirection] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByHoleDesc(string holeDesc)
        {
            string sql = "SELECT TOP 1 [HoleDesc] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT TOP 1 [MadeWidth] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT TOP 1 [MadeHeight] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByMadeLength(decimal madeLength)
        {
            string sql = "SELECT TOP 1 [MadeLength] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEndWidth(decimal endWidth)
        {
            string sql = "SELECT TOP 1 [EndWidth] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEndLength(decimal endLength)
        {
            string sql = "SELECT TOP 1 [EndLength] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByFrontLabel(string frontLabel)
        {
            string sql = "SELECT TOP 1 [FrontLabel] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByBackLabel(string backLabel)
        {
            string sql = "SELECT TOP 1 [BackLabel] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByRemarks(string remarks)
        {
            string sql = "SELECT TOP 1 [Remarks] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEdge1(string edge1)
        {
            string sql = "SELECT TOP 1 [Edge1] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEdge2(string edge2)
        {
            string sql = "SELECT TOP 1 [Edge2] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEdge3(string edge3)
        {
            string sql = "SELECT TOP 1 [Edge3] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEdge4(string edge4)
        {
            string sql = "SELECT TOP 1 [Edge4] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "SELECT TOP 1 [EdgeDesc] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "SELECT TOP 1 [IsSpecialShap] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_SolutionDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSolutionDetails()
        {
            string sql = "DELETE FROM [BE_SolutionDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByItemType(string itemType)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByMaterialType(string materialType)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByTextureDirection(string textureDirection)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByHoleDesc(string holeDesc)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByMadeLength(decimal madeLength)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEndWidth(decimal endWidth)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEndLength(decimal endLength)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByFrontLabel(string frontLabel)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByBackLabel(string backLabel)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByRemarks(string remarks)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEdge1(string edge1)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEdge2(string edge2)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEdge3(string edge3)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEdge4(string edge4)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_SolutionDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<SolutionDetail> LoadSolutionDetails()
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByItemName(string itemName)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByItemType(string itemType)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByMaterialType(string materialType)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByTextureDirection(string textureDirection)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByHoleDesc(string holeDesc)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [HoleDesc]=@HoleDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHoleDesc = new SqlParameter("HoleDesc", holeDesc);
            pHoleDesc.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHoleDesc);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByMadeLength(decimal madeLength)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEndWidth(decimal endWidth)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEndLength(decimal endLength)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByQty(decimal qty)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByFrontLabel(string frontLabel)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByBackLabel(string backLabel)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByRemarks(string remarks)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEdge1(string edge1)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Edge1]=@Edge1";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge1 = new SqlParameter("Edge1", edge1);
            pEdge1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge1);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEdge2(string edge2)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Edge2]=@Edge2";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge2 = new SqlParameter("Edge2", edge2);
            pEdge2.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge2);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEdge3(string edge3)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Edge3]=@Edge3";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge3 = new SqlParameter("Edge3", edge3);
            pEdge3.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge3);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEdge4(string edge4)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Edge4]=@Edge4";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdge4 = new SqlParameter("Edge4", edge4);
            pEdge4.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdge4);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByModified(DateTime modified)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<SolutionDetail> LoadSolutionDetailsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ItemID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [BarcodeNo]
				, [SolutionID]
				, [CabinetID]
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
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SolutionDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<SolutionDetail> ret = new List<SolutionDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionDetail iret = new SolutionDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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

        #region BE_SolutionDetail SearchObject()
        public SearchResult SearchSolutionDetail(SearchSolutionDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[SolutionID],[BarcodeNo]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_SolutionDetail].[ItemID]
                                        ,[BE_SolutionDetail].[ItemName]
                                        ,[BE_SolutionDetail].[MaterialType]
                                        ,[BE_SolutionDetail].[ItemType]
                                        ,[BE_SolutionDetail].[BarcodeNo]
                                        ,[BE_SolutionDetail].[SolutionID]
                                        ,[SolutionCode]
                                        ,[SolutionName]
                                        ,[BE_SolutionDetail].[CabinetID]
                                        ,[CabinetName]
                                        ,[Size]									
                                        ,[MaterialStyle]
                                        ,[MaterialCategory]      
										,[MaterialName]                               
                                        ,[BE_SolutionDetail].[TextureDirection]
                                        ,[BE_SolutionDetail].[HoleDesc]
                                        ,[BE_SolutionDetail].[MadeWidth]
                                        ,[BE_SolutionDetail].[MadeHeight]
                                        ,[BE_SolutionDetail].[MadeLength]
                                        ,[BE_SolutionDetail].[EndWidth]
                                        ,[BE_SolutionDetail].[EndLength]
                                        ,[BE_SolutionDetail].[Qty]
                                        ,[BE_SolutionDetail].[FrontLabel]
                                        ,[BE_SolutionDetail].[BackLabel]
                                        ,[BE_SolutionDetail].[Remarks]
                                        ,[BE_SolutionDetail].[Edge1]
                                        ,[BE_SolutionDetail].[Edge2]
                                        ,[BE_SolutionDetail].[Edge3]
                                        ,[BE_SolutionDetail].[Edge4]
                                        ,[BE_SolutionDetail].[EdgeDesc]
                                        ,[BE_SolutionDetail].[IsSpecialShap]
                                        ,[BE_SolutionDetail].[Created]
                                        ,[BE_SolutionDetail].[CreatedBy]
                                        ,[BE_SolutionDetail].[Modified]
                                        ,[BE_SolutionDetail].[ModifiedBy]
										,[BE_Material].[QuotedPrice]
                                        ,[BE_SolutionDetail].[FilePathUrl]
                                    FROM 
		                                [BE_SolutionDetail] with(nolock)
		                                LEFT JOIN [BE_Solution]  with(nolock) on [BE_Solution].[SolutionID] = [BE_SolutionDetail].[SolutionID]
		                                LEFT JOIN [BE_Solution2Cabinet] with(nolock) on [BE_Solution2Cabinet].[CabinetID] = [BE_SolutionDetail].[CabinetID]
										LEFT JOIN [BE_Material]  with(nolock) on [BE_Material].[MaterialCode] = [BE_SolutionDetail].[MaterialType]
									WHERE 1=1");

            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution].[SolutionID", "mbSolutionID", args.SolutionID.Value);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_SolutionDetail].[CabinetID", "mbCabinetID", args.CabinetID.Value);
            }
            if (!string.IsNullOrEmpty(args.SolutionCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionCode", "mbSolutionCode", args.SolutionCode);
            }
            if (!string.IsNullOrEmpty(args.SolutionName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionName", "mbSolutionName", args.SolutionName);
            }
            if (args.ItemID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "ItemID", "mbItemID", args.ItemID.Value);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductDetail].[IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap.Value);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public SearchResult SearchSolutionQuoteDetail(Guid SolutonID)
        {
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"select
                                     CabinetName
									,ItemName	
									,MaterialName
									,QuotedPrice
	                                ,Sum(BE_SolutionDetail.Qty) as TotalQty
	                                ,Sum(MadeLength * MadeWidth * BE_SolutionDetail.Qty /1000000) as TotalAreal
									,Amount = Sum(MadeLength * MadeWidth * BE_SolutionDetail.Qty /1000000) * QuotedPrice
                                from 
	                                BE_SolutionDetail  with(nolock) 
									LEFT JOIN BE_Solution2Cabinet with(nolock) on BE_Solution2Cabinet.CabinetID = BE_SolutionDetail.CabinetID
									LEFT JOIN [BE_Material]  with(nolock) on [BE_Material].[MaterialCode] = [BE_SolutionDetail].[MaterialType]
                                where 
	                                BE_SolutionDetail.SolutionID=@SolutionID
                                group by
	                                CabinetName,ItemName,MaterialName,QuotedPrice");
            mbBuilder.AppendFormat(") mb");
            cmd.Parameters.AddWithValue("SolutionID", SolutonID);
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, "ItemName", null, null);
        }
        #endregion
    }
}
