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
        #region ProductBOM InsertObject()
        public int InsertProductBOM(ProductBOM obj)
        {
            string sql = @"Insert Into [ProductBOM](
                             [BOMID]
                             ,[ProductCode]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                             @BOMID
                             ,@ProductCode
                             ,@Status
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBOMID = new SqlParameter("BOMID", Convert2DBnull(obj.BOMID));
            pBOMID.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBOMID);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ProductBOM UpdateObject()、DeleteObject()
        public int UpdateProductBOMByID(ProductBOM obj)
        {
            string sql = @"Update [ProductBOM] Set
                              [BOMID]=@BOMID
                             ,[ProductCode]=@ProductCode
                             ,[Status]=@Status
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            SqlParameter pBOMID = new SqlParameter("BOMID", Convert2DBnull(obj.BOMID));
            pBOMID.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBOMID);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductBOMByID(Int32 ID)
        {
            string sql = @"Delete [ProductBOM]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ProductBOM LoadObject()
        public List<ProductBOM> LoadProductBOMs()
        {
            string sql = @"Select 
                              [ID]
                             ,[BOMID]
                             ,[ProductCode]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ProductBOM] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductBOM> ret = new List<ProductBOM>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductBOM iret = new ProductBOM();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["BOMID"]))
                        iret.BOMID = (string)dr["BOMID"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public List<ProductBOM> LoadProductBOMByID(ProductBOM obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[BOMID]
                             ,[ProductCode]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ProductBOM] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            List<ProductBOM> ret = new List<ProductBOM>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductBOM iret = new ProductBOM();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["BOMID"]))
                        iret.BOMID = (string)dr["BOMID"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        iret.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public int LoadProductBOM(ProductBOM obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[BOMID]
                             ,[ProductCode]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ProductBOM] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ID"]))
                        obj.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["BOMID"]))
                        obj.BOMID = (string)dr["BOMID"];
                    if (!Convert.IsDBNull(dr["ProductCode"]))
                        obj.ProductCode = (string)dr["ProductCode"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (bool)dr["Status"];
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

        #region ProductBOM CountObjects()、ExistsObjects()
        public int CountProductBOM()
        {
            string sql = @"Select Count(*) From [ProductBOM] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductBOMID(Int32 ID)
        {
            string sql = @"Select Count(*) From [ProductBOM]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductBOM()
        {
            string sql = @"Select Top 1 * From [ProductBOM] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductBOMID(Int32 ID)
        {
            string sql = @"Select Top 1 * From [ProductBOM]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region ProductBOM SearchObject()
        public SearchResult SearchProductBOM(SearchProductBOMArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              pb.[ID]
                             ,pb.[BOMID]
                             ,pb.[ProductCode]
                             ,op.[ProductName]
                             ,pb.[Status]
                             ,pb.[Created]
                             ,pb.[CreatedBy]
                       From [ProductBOM] pb INNER JOIN BE_OrderProduct op ON op.ProductCode=pb.ProductCode Where 1=1 ");

            //this.SetParameters_In(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);

            //if (args.ProduceOrderID.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);
            //}
            if (!string.IsNullOrEmpty(args.BOMID))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ProductBOM].[BOMID", "mbBOMID ", args.BOMID);
            }
            if (!string.IsNullOrEmpty(args.ProductCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ProductBOM].[ProductCode", "mbProductCode ", args.ProductCode);
            }
            if (!string.IsNullOrEmpty(args.ProductName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderProduct].[ProductName", "mbProductName ", args.ProductName);
            }
            this.SetParameters_Between(mbBuilder, cmd, "Created", "mbCreated", args.CreatedFrom, args.CreatedTo);
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

