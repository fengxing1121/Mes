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
       
        #region BE_QuoteDetail InsertObject()
        public int InsertQuoteDetail(QuoteDetail obj)
        {
            string sql = @"INSERT INTO[BE_QuoteDetail]([DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				) VALUES(@DetailID
				, @QuoteID
				, @ItemCategory
				, @ItemGroup
				, @ItemName
				, @ItemStyle
				, @Qty
				, @Price
				, @ItemRemark
				, @PriceRate
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", Convert2DBnull(obj.ItemCategory));
            pItemCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCategory);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", Convert2DBnull(obj.ItemGroup));
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemStyle = new SqlParameter("ItemStyle", Convert2DBnull(obj.ItemStyle));
            pItemStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemStyle);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pItemRemark = new SqlParameter("ItemRemark", Convert2DBnull(obj.ItemRemark));
            pItemRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemRemark);

            SqlParameter pPriceRate = new SqlParameter("PriceRate", Convert2DBnull(obj.PriceRate));
            pPriceRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPriceRate);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_QuoteDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateQuoteDetailByDetailID(QuoteDetail obj)
        {
            string sql = @"UPDATE [BE_QuoteDetail] SET [QuoteID]=@QuoteID
				, [ItemCategory]=@ItemCategory
				, [ItemGroup]=@ItemGroup
				, [ItemName]=@ItemName
				, [ItemStyle]=@ItemStyle
				, [Qty]=@Qty
				, [Price]=@Price
				, [ItemRemark]=@ItemRemark
				, [PriceRate]=@PriceRate
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", Convert2DBnull(obj.ItemCategory));
            pItemCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCategory);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", Convert2DBnull(obj.ItemGroup));
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemStyle = new SqlParameter("ItemStyle", Convert2DBnull(obj.ItemStyle));
            pItemStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemStyle);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pItemRemark = new SqlParameter("ItemRemark", Convert2DBnull(obj.ItemRemark));
            pItemRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemRemark);

            SqlParameter pPriceRate = new SqlParameter("PriceRate", Convert2DBnull(obj.PriceRate));
            pPriceRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPriceRate);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_QuoteDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadQuoteDetailByDetailID(QuoteDetail obj)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
 				FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
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
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        obj.QuoteID = (Guid)dr["QuoteID"];
                    obj.ItemCategory = dr["ItemCategory"].ToString();
                    obj.ItemGroup = dr["ItemGroup"].ToString();
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    obj.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        obj.PriceRate = (decimal)dr["PriceRate"];
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

        #region BE_QuoteDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountQuoteDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByQuoteID(Guid quoteID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByItemCategory(string itemCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByItemGroup(string itemGroup)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByItemStyle(string itemStyle)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemStyle]=@ItemStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemStyle = new SqlParameter("ItemStyle", itemStyle);
            pItemStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByItemRemark(string itemRemark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemRemark]=@ItemRemark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemRemark = new SqlParameter("ItemRemark", itemRemark);
            pItemRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteDetailsByPriceRate(decimal priceRate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [PriceRate]=@PriceRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPriceRate = new SqlParameter("PriceRate", priceRate);
            pPriceRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPriceRate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsQuoteDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_QuoteDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByQuoteID(Guid quoteID)
        {
            string sql = "SELECT TOP 1 [QuoteID] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByItemCategory(string itemCategory)
        {
            string sql = "SELECT TOP 1 [ItemCategory] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByItemGroup(string itemGroup)
        {
            string sql = "SELECT TOP 1 [ItemGroup] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByItemStyle(string itemStyle)
        {
            string sql = "SELECT TOP 1 [ItemStyle] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemStyle]=@ItemStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemStyle = new SqlParameter("ItemStyle", itemStyle);
            pItemStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByItemRemark(string itemRemark)
        {
            string sql = "SELECT TOP 1 [ItemRemark] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [ItemRemark]=@ItemRemark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemRemark = new SqlParameter("ItemRemark", itemRemark);
            pItemRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteDetailsByPriceRate(decimal priceRate)
        {
            string sql = "SELECT TOP 1 [PriceRate] FROM [BE_QuoteDetail] WITH(NOLOCK) WHERE [PriceRate]=@PriceRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPriceRate = new SqlParameter("PriceRate", priceRate);
            pPriceRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPriceRate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteQuoteDetails()
        {
            string sql = "DELETE FROM [BE_QuoteDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByQuoteID(Guid quoteID)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByItemCategory(string itemCategory)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByItemGroup(string itemGroup)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByItemStyle(string itemStyle)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [ItemStyle]=@ItemStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemStyle = new SqlParameter("ItemStyle", itemStyle);
            pItemStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByItemRemark(string itemRemark)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [ItemRemark]=@ItemRemark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemRemark = new SqlParameter("ItemRemark", itemRemark);
            pItemRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteDetailsByPriceRate(decimal priceRate)
        {
            string sql = "DELETE FROM [BE_QuoteDetail] WHERE [PriceRate]=@PriceRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPriceRate = new SqlParameter("PriceRate", priceRate);
            pPriceRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPriceRate);

            return cmd.ExecuteNonQuery();
        }
        public List<QuoteDetail> LoadQuoteDetails()
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByDetailID(Guid detailID)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByQuoteID(Guid quoteID)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByItemCategory(string itemCategory)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [ItemCategory]=@ItemCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCategory = new SqlParameter("ItemCategory", itemCategory);
            pItemCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCategory);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByItemGroup(string itemGroup)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [ItemGroup]=@ItemGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemGroup = new SqlParameter("ItemGroup", itemGroup);
            pItemGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemGroup);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByItemName(string itemName)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByItemStyle(string itemStyle)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [ItemStyle]=@ItemStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemStyle = new SqlParameter("ItemStyle", itemStyle);
            pItemStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemStyle);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByQty(decimal qty)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByPrice(decimal price)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByItemRemark(string itemRemark)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [ItemRemark]=@ItemRemark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemRemark = new SqlParameter("ItemRemark", itemRemark);
            pItemRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemRemark);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<QuoteDetail> LoadQuoteDetailsByPriceRate(decimal priceRate)
        {
            string sql = @"SELECT [DetailID]
				, [QuoteID]
				, [ItemCategory]
				, [ItemGroup]
				, [ItemName]
				, [ItemStyle]
				, [Qty]
				, [Price]
				, [ItemRemark]
				, [PriceRate]
				 FROM [BE_QuoteDetail] WHERE [PriceRate]=@PriceRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPriceRate = new SqlParameter("PriceRate", priceRate);
            pPriceRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPriceRate);

            List<QuoteDetail> ret = new List<QuoteDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteDetail iret = new QuoteDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.ItemCategory = dr["ItemCategory"].ToString();
                    iret.ItemGroup = dr["ItemGroup"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemStyle = dr["ItemStyle"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    iret.ItemRemark = dr["ItemRemark"].ToString();
                    if (!Convert.IsDBNull(dr["PriceRate"]))
                        iret.PriceRate = (decimal)dr["PriceRate"];
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

        #region BE_QuoteDetail SearchObject()
        public SearchResult SearchQuoteDetail(SearchQuoteDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[QuoteNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_QuoteMain].[QuoteID]
                                          ,[QuoteNo]
                                          ,[BE_QuoteMain].[SolutionID]
                                          ,[BE_QuoteMain].[CustomerID]
                                          ,[ExpiryDate]
                                          ,[DiscountPercent]
                                          ,[TotalAmount]
                                          ,[DiscountAmount]
                                          ,[BE_QuoteMain].[Remark]
                                          ,[BE_QuoteMain].[Status]
                                          ,[BE_QuoteMain].[Created]
                                          ,[BE_QuoteMain].[CreatedBy]
                                          ,[BE_QuoteMain].[Modified]
                                          ,[BE_QuoteMain].[ModifiedBy]
	                                      ,[CustomerName]
	                                      ,[BE_Customer].[LinkMan]
	                                      ,[BE_Customer].[Address]
	                                      ,[BE_Customer].[Tel]
	                                      ,[BE_Customer].[Mobile]
	                                      ,[BE_Solution].[SolutionCode]
	                                      ,[BE_Solution].[SolutionName]
										  ,[BE_QuoteDetail].[DetailID]
										  ,[BE_QuoteDetail].[ItemCategory]
										  ,[BE_QuoteDetail].[ItemGroup]
										  ,[BE_QuoteDetail].[ItemName]
										  ,[BE_QuoteDetail].[ItemRemark]
										  ,[BE_QuoteDetail].[ItemStyle]
										  ,[BE_QuoteDetail].[Price]
										  ,[BE_QuoteDetail].[PriceRate]
										  ,[BE_QuoteDetail].[Qty]										 
                                      FROM 
	                                      [BE_QuoteMain] with(nolock)
	                                      LEFT JOIN [BE_Customer] with(nolock) on [BE_QuoteMain].[CustomerID] = [BE_Customer].[CustomerID]
	                                      LEFT JOIN [BE_Solution] with(nolock) on [BE_Solution].[SolutionID] = [BE_QuoteMain].[SolutionID] 
										  LEFT JOIN [BE_QuoteDetail] with(nolock) on [BE_QuoteMain].[QuoteID] = [BE_QuoteDetail].[QuoteID]
                                   WHERE 1=1");

            if (args.QuoteID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[QuoteID", "mbQuoteID", args.QuoteID);
            }
            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[SolutionID", "mbSolutionID", args.SolutionID);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[CustomerID", "mbCustomerID", args.CustomerID);
            }
            if (!string.IsNullOrEmpty(args.QuoteNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "QuoteNo", "mbQuoteNo", args.QuoteNo);
            }
            if (!string.IsNullOrEmpty(args.SolutionCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionCode", "mbSolutionCode", args.SolutionCode);
            }
            if (!string.IsNullOrEmpty(args.SolutionName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionName", "mbSolutionName", args.SolutionName);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.ItemGroup))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemGroup", "mbItemGroup", args.ItemGroup);
            }
            if (!string.IsNullOrEmpty(args.ItemCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemCategory", "mbItemCategory", args.ItemCategory);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
