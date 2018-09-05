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
        #region ProductComponent InsertObject()
        public int InsertProductComponent(ProductComponent obj)
        {
            string sql = @"Insert Into [ProductComponent](
                              [ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
            )Values (
                              @ComponentCode
                             ,@ProductCode
                             ,@ComponentTypeID
                             ,@ComponentTypeName
                             ,@Quantity
                             ,@Amount
                             ,@Status
                             ,@Created
                             ,@CreatedBy
                             ,@Modified
                             ,@ModifiedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentCode = new SqlParameter("ComponentCode", Convert2DBnull(obj.ComponentCode));
            pComponentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentCode);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            SqlParameter pComponentTypeName = new SqlParameter("ComponentTypeName", Convert2DBnull(obj.ComponentTypeName));
            pComponentTypeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentTypeName);

            SqlParameter pQuantity = new SqlParameter("Quantity", Convert2DBnull(obj.Quantity));
            pQuantity.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuantity);

            SqlParameter pAmount = new SqlParameter("Amount", Convert2DBnull(obj.Amount));
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

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

        #region ProductComponent UpdateObject()、DeleteObject()
        public int UpdateProductComponentByComponentID(ProductComponent obj)
        {
            string sql = @"Update [ProductComponent] Set
                              [ComponentCode]=@ComponentCode
                             ,[ProductCode]=@ProductCode
                             ,[ComponentTypeID]=@ComponentTypeID
                             ,[ComponentTypeName]=@ComponentTypeName
                             ,[Quantity]=@Quantity
                             ,[Amount]=@Amount
                             ,[Status]=@Status
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                             ,[Modified]=@Modified
                             ,[ModifiedBy]=@ModifiedBy
                          Where ComponentID=@ComponentID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            SqlParameter pComponentCode = new SqlParameter("ComponentCode", Convert2DBnull(obj.ComponentCode));
            pComponentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentCode);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            SqlParameter pComponentTypeName = new SqlParameter("ComponentTypeName", Convert2DBnull(obj.ComponentTypeName));
            pComponentTypeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentTypeName);

            SqlParameter pQuantity = new SqlParameter("Quantity", Convert2DBnull(obj.Quantity));
            pQuantity.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuantity);

            SqlParameter pAmount = new SqlParameter("Amount", Convert2DBnull(obj.Amount));
            pAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pAmount);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

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

        public int DeleteProductComponentByComponentID(Int32 ComponentID)
        {
            string sql = @"Delete [ProductComponent]  Where ComponentID=@ComponentID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ProductComponent LoadObject()
        public List<ProductComponent> LoadProductComponents()
        {
            string sql = @"Select 
                              [ComponentID]
                             ,[ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ProductComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductComponent> ret = new List<ProductComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductComponent iret = new ProductComponent();
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentCode"]))
                        iret.ComponentCode = (string)dr["ComponentCode"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        iret.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        iret.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public List<ProductComponent> LoadProductComponentByComponentID(ProductComponent obj)
        {
            string sql = @"Select 
                              [ComponentID]
                             ,[ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ProductComponent] With(NoLock) Where ComponentID=@ComponentID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            List<ProductComponent> ret = new List<ProductComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductComponent iret = new ProductComponent();
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentCode"]))
                        iret.ComponentCode = (string)dr["ComponentCode"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        iret.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        iret.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public List<ProductComponent> LoadProductComponentByOrderID(Guid OrderID)
        {
            string sql = @"Select 
                              [ProductComponent].[ComponentID]
                             ,[ProductComponent].[ComponentCode]
                             ,[ProductComponent].[ProductCode]
                             ,[ProductComponent].[ComponentTypeID]
                             ,[ProductComponent].[ComponentTypeName]
                             ,[ProductComponent].[Quantity]
                             ,[ProductComponent].[Amount]
                             ,[ProductComponent].[Status]
                             ,[ProductComponent].[Created]
                             ,[ProductComponent].[CreatedBy]
                             ,[ProductComponent].[Modified]
                             ,[ProductComponent].[ModifiedBy]
                       From [ProductComponent] With(NoLock)
					   LEFT JOIN [ComponentType] ON [ProductComponent].ComponentTypeID=[ComponentType].ComponentTypeID
	                   LEFT JOIN [dbo].[BE_OrderProduct] ON [BE_OrderProduct].[ProductCode]=[ProductComponent].[ProductCode]
	                   WHERE [ComponentType].ParentID=0 AND [BE_OrderProduct].OrderID=@OrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", OrderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<ProductComponent> ret = new List<ProductComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductComponent iret = new ProductComponent();
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentCode"]))
                        iret.ComponentCode = (string)dr["ComponentCode"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        iret.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        iret.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public List<ProductComponent> LoadProductComponentByProductCode(string productCode)
        {
            string sql = @"Select 
                              [ComponentID]
                             ,[ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ProductComponent] With(NoLock) Where ProductCode=@ProductCode";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pproductCode = new SqlParameter("ProductCode", Convert2DBnull(productCode));
            pproductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pproductCode);

            List<ProductComponent> ret = new List<ProductComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductComponent iret = new ProductComponent();
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentCode"]))
                        iret.ComponentCode = (string)dr["ComponentCode"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        iret.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        iret.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        iret.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public int LoadProductComponent(ProductComponent obj)
        {
            string sql = @"Select 
                              [ComponentID]
                             ,[ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ProductComponent] With(NoLock) Where ComponentID=@ComponentID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        obj.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentCode"]))
                        obj.ComponentCode = (string)dr["ComponentCode"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        obj.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        obj.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        obj.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        obj.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        obj.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (bool)dr["Status"];
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

        public int LoadProductComponentByComponentTypeID(ProductComponent obj)
        {
            string sql = @"Select 
                              [ComponentID]
                             ,[ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ProductComponent] With(NoLock) Where ComponentTypeID=@ComponentTypeID and ProductCode=@ProductCode";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        obj.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentCode"]))
                        obj.ComponentCode = (string)dr["ComponentCode"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        obj.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        obj.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        obj.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        obj.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["Amount"]))
                        obj.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (bool)dr["Status"];
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

        #region ProductComponent CountObjects()、ExistsObjects()
        public int CountProductComponent()
        {
            string sql = @"Select Count(*) From [ProductComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductComponentComponentID(Int32 ComponentID)
        {
            string sql = @"Select Count(*) From [ProductComponent]  Where ComponentID=@ComponentID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductComponent()
        {
            string sql = @"Select Top 1 * From [ProductComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductComponentComponentID(Int32 ComponentID)
        {
            string sql = @"Select Top 1 * From [ProductComponent]  Where ComponentID=@ComponentID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region ProductComponent SearchObject()
        public SearchResult SearchProductComponent(SearchProductComponentArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ComponentID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              [ComponentID]
                             ,[ComponentCode]
                             ,[ProductCode]
                             ,[ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[Quantity]
                             ,[Amount]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ProductComponent] With(NoLock) Where 1=1 ");

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