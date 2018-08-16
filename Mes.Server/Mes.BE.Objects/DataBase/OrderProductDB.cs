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
        #region BE_OrderProduct InsertObject()
        public int InsertOrderProduct(OrderProduct obj)
        {
            string sql = @"Insert Into [BE_OrderProduct](
                              [ProductID]
                             ,[OrderID]
                             ,[ProductGroup]
                             ,[ProductCode]
                             ,[ProductName]
                             ,[Size]
                             ,[MaterialStyle]
                             ,[MaterialCategory]
                             ,[Color]
                             ,[Unit]
                             ,[Qty]
                             ,[Price]
                             ,[SalePrice]
                             ,[TotalAreal]
                             ,[TotalLength]
                             ,[BattchCode]
                             ,[ProductStatus]
                             ,[Remark]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
            )Values (
                              @ProductID
                             ,@OrderID
                             ,@ProductGroup
                             ,@ProductCode
                             ,@ProductName
                             ,@Size
                             ,@MaterialStyle
                             ,@MaterialCategory
                             ,@Color
                             ,@Unit
                             ,@Qty
                             ,@Price
                             ,@SalePrice
                             ,@TotalAreal
                             ,@TotalLength
                             ,@BattchCode
                             ,@ProductStatus
                             ,@Remark
                             ,@Created
                             ,@CreatedBy
                             ,@Modified
                             ,@ModifiedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pProductGroup = new SqlParameter("ProductGroup", Convert2DBnull(obj.ProductGroup));
            pProductGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductGroup);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pProductName = new SqlParameter("ProductName", Convert2DBnull(obj.ProductName));
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

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

            SqlParameter pSalePrice = new SqlParameter("SalePrice", Convert2DBnull(obj.SalePrice));
            pSalePrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSalePrice);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", Convert2DBnull(obj.BattchCode));
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            SqlParameter pProductStatus = new SqlParameter("ProductStatus", Convert2DBnull(obj.ProductStatus));
            pProductStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pProductStatus);

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

        #region BE_OrderProduct UpdateObject()、DeleteObject()
        public int UpdateOrderProductByProductID(OrderProduct obj)
        {
            string sql = @"Update [BE_OrderProduct] Set
                              [OrderID]=@OrderID
                             ,[ProductGroup]=@ProductGroup
                             ,[ProductCode]=@ProductCode
                             ,[ProductName]=@ProductName
                             ,[Size]=@Size
                             ,[MaterialStyle]=@MaterialStyle
                             ,[MaterialCategory]=@MaterialCategory
                             ,[Color]=@Color
                             ,[Unit]=@Unit
                             ,[Qty]=@Qty
                             ,[Price]=@Price
                             ,[SalePrice]=@SalePrice
                             ,[TotalAreal]=@TotalAreal
                             ,[TotalLength]=@TotalLength
                             ,[BattchCode]=@BattchCode
                             ,[ProductStatus]=@ProductStatus
                             ,[Remark]=@Remark
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                             ,[Modified]=@Modified
                             ,[ModifiedBy]=@ModifiedBy
                          Where ProductID=@ProductID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pProductGroup = new SqlParameter("ProductGroup", Convert2DBnull(obj.ProductGroup));
            pProductGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductGroup);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pProductName = new SqlParameter("ProductName", Convert2DBnull(obj.ProductName));
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

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

            SqlParameter pSalePrice = new SqlParameter("SalePrice", Convert2DBnull(obj.SalePrice));
            pSalePrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSalePrice);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pTotalLength = new SqlParameter("TotalLength", Convert2DBnull(obj.TotalLength));
            pTotalLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalLength);

            SqlParameter pBattchCode = new SqlParameter("BattchCode", Convert2DBnull(obj.BattchCode));
            pBattchCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchCode);

            SqlParameter pProductStatus = new SqlParameter("ProductStatus", Convert2DBnull(obj.ProductStatus));
            pProductStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pProductStatus);

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

        public int DeleteOrderProductByProductID(Guid ProductID)
        {
            string sql = @"Delete [BE_OrderProduct]  Where ProductID=@ProductID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderProduct LoadObject()
        public List<OrderProduct> LoadOrderProducts()
        {
            string sql = @"Select 
                              [ProductID]
                             ,[OrderID]
                             ,[ProductGroup]
                             ,[ProductCode]
                             ,[ProductName]
                             ,[Size]
                             ,[MaterialStyle]
                             ,[MaterialCategory]
                             ,[Color]
                             ,[Unit]
                             ,[Qty]
                             ,[Price]
                             ,[SalePrice]
                             ,[TotalAreal]
                             ,[TotalLength]
                             ,[BattchCode]
                             ,[ProductStatus]
                             ,[Remark]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [BE_OrderProduct] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderProduct> ret = new List<OrderProduct>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProduct iret = new OrderProduct();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductGroup"]))
                        iret.ProductGroup = (string)dr["ProductGroup"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ProductName"]))
                        iret.ProductName = (string)dr["ProductName"];
                    if (!Convert.IsDBNull(dr["Size"]))
                        iret.Size = (string)dr["Size"];
                    if (!Convert.IsDBNull(dr["MaterialStyle"]))
                        iret.MaterialStyle = (string)dr["MaterialStyle"];
                    if (!Convert.IsDBNull(dr["MaterialCategory"]))
                        iret.MaterialCategory = (string)dr["MaterialCategory"];
                    if (!Convert.IsDBNull(dr["Color"]))
                        iret.Color = (string)dr["Color"];
                    if (!Convert.IsDBNull(dr["Unit"]))
                        iret.Unit = (string)dr["Unit"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["SalePrice"]))
                        iret.SalePrice = (decimal)dr["SalePrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["BattchCode"]))
                        iret.BattchCode = (string)dr["BattchCode"];
                    if (!Convert.IsDBNull(dr["ProductStatus"]))
                        iret.ProductStatus = (string)dr["ProductStatus"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    if (!Convert.IsDBNull(dr["ModifiedBy"]))
                        iret.ModifiedBy = (string)dr["ModifiedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<OrderProduct> LoadOrderProductByOrderID(OrderProduct obj)
        {
            string sql = @"Select 
                              [ProductID]
                             ,[OrderID]
                             ,[ProductGroup]
                             ,[ProductCode]
                             ,[ProductName]
                             ,[Size]
                             ,[MaterialStyle]
                             ,[MaterialCategory]
                             ,[Color]
                             ,[Unit]
                             ,[Qty]
                             ,[Price]
                             ,[SalePrice]
                             ,[TotalAreal]
                             ,[TotalLength]
                             ,[BattchCode]
                             ,[ProductStatus]
                             ,[Remark]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [BE_OrderProduct] With(NoLock) Where OrderID=@OrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderProduct> ret = new List<OrderProduct>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderProduct iret = new OrderProduct();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductGroup"]))
                        iret.ProductGroup = (string)dr["ProductGroup"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ProductName"]))
                        iret.ProductName = (string)dr["ProductName"];
                    if (!Convert.IsDBNull(dr["Size"]))
                        iret.Size = (string)dr["Size"];
                    if (!Convert.IsDBNull(dr["MaterialStyle"]))
                        iret.MaterialStyle = (string)dr["MaterialStyle"];
                    if (!Convert.IsDBNull(dr["MaterialCategory"]))
                        iret.MaterialCategory = (string)dr["MaterialCategory"];
                    if (!Convert.IsDBNull(dr["Color"]))
                        iret.Color = (string)dr["Color"];
                    if (!Convert.IsDBNull(dr["Unit"]))
                        iret.Unit = (string)dr["Unit"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["SalePrice"]))
                        iret.SalePrice = (decimal)dr["SalePrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        iret.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["BattchCode"]))
                        iret.BattchCode = (string)dr["BattchCode"];
                    if (!Convert.IsDBNull(dr["ProductStatus"]))
                        iret.ProductStatus = (string)dr["ProductStatus"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    if (!Convert.IsDBNull(dr["ModifiedBy"]))
                        iret.ModifiedBy = (string)dr["ModifiedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadOrderProduct(OrderProduct obj)
        {
            string sql = @"Select 
                              [ProductID]
                             ,[OrderID]
                             ,[ProductGroup]
                             ,[ProductCode]
                             ,[ProductName]
                             ,[Size]
                             ,[MaterialStyle]
                             ,[MaterialCategory]
                             ,[Color]
                             ,[Unit]
                             ,[Qty]
                             ,[Price]
                             ,[SalePrice]
                             ,[TotalAreal]
                             ,[TotalLength]
                             ,[BattchCode]
                             ,[ProductStatus]
                             ,[Remark]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [BE_OrderProduct] With(NoLock) Where ProductID=@ProductID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductGroup"]))
                        obj.ProductGroup = (string)dr["ProductGroup"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        obj.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ProductName"]))
                        obj.ProductName = (string)dr["ProductName"];
                    if (!Convert.IsDBNull(dr["Size"]))
                        obj.Size = (string)dr["Size"];
                    if (!Convert.IsDBNull(dr["MaterialStyle"]))
                        obj.MaterialStyle = (string)dr["MaterialStyle"];
                    if (!Convert.IsDBNull(dr["MaterialCategory"]))
                        obj.MaterialCategory = (string)dr["MaterialCategory"];
                    if (!Convert.IsDBNull(dr["Color"]))
                        obj.Color = (string)dr["Color"];
                    if (!Convert.IsDBNull(dr["Unit"]))
                        obj.Unit = (string)dr["Unit"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["SalePrice"]))
                        obj.SalePrice = (decimal)dr["SalePrice"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["TotalLength"]))
                        obj.TotalLength = (decimal)dr["TotalLength"];
                    if (!Convert.IsDBNull(dr["BattchCode"]))
                        obj.BattchCode = (string)dr["BattchCode"];
                    if (!Convert.IsDBNull(dr["ProductStatus"]))
                        obj.ProductStatus = (string)dr["ProductStatus"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        obj.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    if (!Convert.IsDBNull(dr["ModifiedBy"]))
                        obj.ModifiedBy = (string)dr["ModifiedBy"];
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

        #region BE_OrderProduct CountObjects()、ExistsObjects()
        public int CountOrderProduct()
        {
            string sql = @"Select Count(*) From [BE_OrderProduct] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountOrderProductProductID(Guid ProductID)
        {
            string sql = @"Select Count(*) From [BE_OrderProduct]  Where ProductID=@ProductID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsOrderProduct()
        {
            string sql = @"Select Top 1 * From [BE_OrderProduct] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsOrderProductProductID(Guid ProductID)
        {
            string sql = @"Select Top 1 * From [BE_OrderProduct]  Where ProductID=@ProductID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region BE_OrderProduct SearchObject()
        public SearchResult SearchOrderProduct(SearchOrderProductArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ProductID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              [ProductID]
                             ,[OrderID]
                             ,[ProductGroup]
                             ,[ProductCode]
                             ,[ProductName]
                             ,[Size]
                             ,[MaterialStyle]
                             ,[MaterialCategory]
                             ,[Color]
                             ,[Unit]
                             ,[Qty]
                             ,[Price]
                             ,[SalePrice]
                             ,[TotalAreal]
                             ,[TotalLength]
                             ,[BattchCode]
                             ,[ProductStatus]
                             ,[Remark]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [BE_OrderProduct] With(NoLock) Where 1=1 ");

            //this.SetParameters_In(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);

            //if (args.ProduceOrderID.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);
            //}
            //if (!string.IsNullOrEmpty(args.OrderNo))
            //{
            //    this.SetParameters_Contains(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);
            //}
            //if (!string.IsNullOrEmpty(args.ProduceOrderID))
            //{
            //    this.SetParameters_Between(mbBuilder, cmd, "ProduceOrderID", "mbProduceOrderID", args.BookingDateFrom, args.BookingDateTo);
            //}

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}

