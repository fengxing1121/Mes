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
        #region BE_QuoteItem InsertObject()
        public int InsertQuoteItem(QuoteItem obj)
        {
            string sql = @"INSERT INTO[BE_QuoteItem]([ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				) VALUES(@ItemID
				, @CategoryCode
				, @SubCagegoryCode
				, @ItemCode
				, @ItemName
				, @Style
				, @Model
				, @Unit
				, @Price
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", Convert2DBnull(obj.SubCagegoryCode));
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            SqlParameter pItemCode = new SqlParameter("ItemCode", Convert2DBnull(obj.ItemCode));
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pModel = new SqlParameter("Model", Convert2DBnull(obj.Model));
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_QuoteItem UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateQuoteItemByItemCode(QuoteItem obj)
        {
            string sql = @"UPDATE [BE_QuoteItem] SET [ItemID]=@ItemID
				, [CategoryCode]=@CategoryCode
				, [SubCagegoryCode]=@SubCagegoryCode
				, [ItemName]=@ItemName
				, [Style]=@Style
				, [Model]=@Model
				, [Unit]=@Unit
				, [Price]=@Price
 				WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", Convert2DBnull(obj.SubCagegoryCode));
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pModel = new SqlParameter("Model", Convert2DBnull(obj.Model));
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pItemCode = new SqlParameter("ItemCode", Convert2DBnull(obj.ItemCode));
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateQuoteItemByItemID(QuoteItem obj)
        {
            string sql = @"UPDATE [BE_QuoteItem] SET [CategoryCode]=@CategoryCode
				, [SubCagegoryCode]=@SubCagegoryCode
				, [ItemCode]=@ItemCode
				, [ItemName]=@ItemName
				, [Style]=@Style
				, [Model]=@Model
				, [Unit]=@Unit
				, [Price]=@Price
 				WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", Convert2DBnull(obj.CategoryCode));
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", Convert2DBnull(obj.SubCagegoryCode));
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            SqlParameter pItemCode = new SqlParameter("ItemCode", Convert2DBnull(obj.ItemCode));
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pModel = new SqlParameter("Model", Convert2DBnull(obj.Model));
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemByItemCode(string itemCode)
        {
            string sql = @"DELETE [BE_QuoteItem] WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_QuoteItem] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadQuoteItemByItemCode(QuoteItem obj)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
 				FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", Convert2DBnull(obj.ItemCode));
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    obj.CategoryCode = dr["CategoryCode"].ToString();
                    obj.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    obj.ItemCode = dr["ItemCode"].ToString();
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Model = dr["Model"].ToString();
                    obj.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadQuoteItemByItemID(QuoteItem obj)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
 				FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
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
                    obj.CategoryCode = dr["CategoryCode"].ToString();
                    obj.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    obj.ItemCode = dr["ItemCode"].ToString();
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Model = dr["Model"].ToString();
                    obj.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
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

        #region BE_QuoteItem CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountQuoteItems()
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByCategoryCode(string categoryCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsBySubCagegoryCode(string subCagegoryCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [SubCagegoryCode]=@SubCagegoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", subCagegoryCode);
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByItemCode(string itemCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByModel(string model)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteItemsByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsQuoteItems()
        {
            string sql = "SELECT TOP 1 * FROM [BE_QuoteItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByCategoryCode(string categoryCode)
        {
            string sql = "SELECT TOP 1 [CategoryCode] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsBySubCagegoryCode(string subCagegoryCode)
        {
            string sql = "SELECT TOP 1 [SubCagegoryCode] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [SubCagegoryCode]=@SubCagegoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", subCagegoryCode);
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByItemCode(string itemCode)
        {
            string sql = "SELECT TOP 1 [ItemCode] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByModel(string model)
        {
            string sql = "SELECT TOP 1 [Model] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteItemsByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_QuoteItem] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteQuoteItems()
        {
            string sql = "DELETE FROM [BE_QuoteItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByCategoryCode(string categoryCode)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsBySubCagegoryCode(string subCagegoryCode)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [SubCagegoryCode]=@SubCagegoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", subCagegoryCode);
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByItemCode(string itemCode)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByStyle(string style)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByModel(string model)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteItemsByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_QuoteItem] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public List<QuoteItem> LoadQuoteItems()
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByCategoryCode(string categoryCode)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [CategoryCode]=@CategoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryCode = new SqlParameter("CategoryCode", categoryCode);
            pCategoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategoryCode);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsBySubCagegoryCode(string subCagegoryCode)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [SubCagegoryCode]=@SubCagegoryCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCagegoryCode = new SqlParameter("SubCagegoryCode", subCagegoryCode);
            pSubCagegoryCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCagegoryCode);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByItemCode(string itemCode)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByItemName(string itemName)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByStyle(string style)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByModel(string model)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByUnit(string unit)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteItem> LoadQuoteItemsByPrice(decimal price)
        {
            string sql = @"SELECT [ItemID]
				, [CategoryCode]
				, [SubCagegoryCode]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Model]
				, [Unit]
				, [Price]
				 FROM [BE_QuoteItem] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<QuoteItem> ret = new List<QuoteItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteItem iret = new QuoteItem();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.CategoryCode = dr["CategoryCode"].ToString();
                    iret.SubCagegoryCode = dr["SubCagegoryCode"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
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
    }
}
