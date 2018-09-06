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
        #region ComponentMaterialExtension InsertObject()
        public int InsertComponentMaterialExtension(ComponentMaterialExtension obj)
        {
            string sql = @"Insert Into [ComponentMaterialExtension](
                             [ComponentMaterialID]
                             ,[Barcode]
                             ,[OutputName]
                             ,[MprA]
                             ,[MprB]
                             ,[MachineFile]
                             ,[Remark]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                             @ComponentMaterialID
                             ,@Barcode
                             ,@OutputName
                             ,@MprA
                             ,@MprB
                             ,@MachineFile
                             ,@Remark
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentMaterialID = new SqlParameter("ComponentMaterialID", Convert2DBnull(obj.ComponentMaterialID));
            pComponentMaterialID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentMaterialID);

            SqlParameter pBarcode = new SqlParameter("Barcode", Convert2DBnull(obj.Barcode));
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            SqlParameter pOutputName = new SqlParameter("OutputName", Convert2DBnull(obj.OutputName));
            pOutputName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOutputName);

            SqlParameter pMprA = new SqlParameter("MprA", Convert2DBnull(obj.MprA));
            pMprA.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMprA);

            SqlParameter pMprB = new SqlParameter("MprB", Convert2DBnull(obj.MprB));
            pMprB.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMprB);

            SqlParameter pMachineFile = new SqlParameter("MachineFile", Convert2DBnull(obj.MachineFile));
            pMachineFile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMachineFile);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.Text;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        #endregion

        #region ComponentMaterialExtension UpdateObject()、DeleteObject()
        public int UpdateComponentMaterialExtensionByID(ComponentMaterialExtension obj)
        {
            string sql = @"Update [ComponentMaterialExtension] Set
                              [ComponentMaterialID]=@ComponentMaterialID
                             ,[Barcode]=@Barcode
                             ,[OutputName]=@OutputName
                             ,[MprA]=@MprA
                             ,[MprB]=@MprB
                             ,[MachineFile]=@MachineFile
                             ,[Remark]=@Remark
                          Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            SqlParameter pComponentMaterialID = new SqlParameter("ComponentMaterialID", Convert2DBnull(obj.ComponentMaterialID));
            pComponentMaterialID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentMaterialID);

            SqlParameter pBarcode = new SqlParameter("Barcode", Convert2DBnull(obj.Barcode));
            pBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcode);

            SqlParameter pOutputName = new SqlParameter("OutputName", Convert2DBnull(obj.OutputName));
            pOutputName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOutputName);

            SqlParameter pMprA = new SqlParameter("MprA", Convert2DBnull(obj.MprA));
            pMprA.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMprA);

            SqlParameter pMprB = new SqlParameter("MprB", Convert2DBnull(obj.MprB));
            pMprB.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMprB);

            SqlParameter pMachineFile = new SqlParameter("MachineFile", Convert2DBnull(obj.MachineFile));
            pMachineFile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMachineFile);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.Text;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteComponentMaterialExtensionByID(Int32 ID)
        {
            string sql = @"Delete [ComponentMaterialExtension]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ComponentMaterialExtension LoadObject()
        public List<ComponentMaterialExtension> LoadComponentMaterialExtensions()
        {
            string sql = @"Select 
                              [ID]
                             ,[ComponentMaterialID]
                             ,[Barcode]
                             ,[OutputName]
                             ,[MprA]
                             ,[MprB]
                             ,[MachineFile]
                             ,[Remark]
                       From [ComponentMaterialExtension] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ComponentMaterialExtension> ret = new List<ComponentMaterialExtension>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ComponentMaterialExtension iret = new ComponentMaterialExtension();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["ComponentMaterialID"]))
                        iret.ComponentMaterialID = (int)dr["ComponentMaterialID"];
                    if (!Convert.IsDBNull(dr["Barcode"]))
                        iret.Barcode = (string)dr["Barcode"];
                    if (!Convert.IsDBNull(dr["OutputName"]))
                        iret.OutputName = (string)dr["OutputName"];
                    if (!Convert.IsDBNull(dr["MprA"]))
                        iret.MprA = (string)dr["MprA"];
                    if (!Convert.IsDBNull(dr["MprB"]))
                        iret.MprB = (string)dr["MprB"];
                    if (!Convert.IsDBNull(dr["MachineFile"]))
                        iret.MachineFile = (string)dr["MachineFile"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ComponentMaterialExtension> LoadComponentMaterialExtensionByID(ComponentMaterialExtension obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[ComponentMaterialID]
                             ,[Barcode]
                             ,[OutputName]
                             ,[MprA]
                             ,[MprB]
                             ,[MachineFile]
                             ,[Remark]
                       From [ComponentMaterialExtension] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            List<ComponentMaterialExtension> ret = new List<ComponentMaterialExtension>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ComponentMaterialExtension iret = new ComponentMaterialExtension();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["ComponentMaterialID"]))
                        iret.ComponentMaterialID = (int)dr["ComponentMaterialID"];
                    if (!Convert.IsDBNull(dr["Barcode"]))
                        iret.Barcode = (string)dr["Barcode"];
                    if (!Convert.IsDBNull(dr["OutputName"]))
                        iret.OutputName = (string)dr["OutputName"];
                    if (!Convert.IsDBNull(dr["MprA"]))
                        iret.MprA = (string)dr["MprA"];
                    if (!Convert.IsDBNull(dr["MprB"]))
                        iret.MprB = (string)dr["MprB"];
                    if (!Convert.IsDBNull(dr["MachineFile"]))
                        iret.MachineFile = (string)dr["MachineFile"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadComponentMaterialExtension(ComponentMaterialExtension obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[ComponentMaterialID]
                             ,[Barcode]
                             ,[OutputName]
                             ,[MprA]
                             ,[MprB]
                             ,[MachineFile]
                             ,[Remark]
                       From [ComponentMaterialExtension] With(NoLock) Where ID=@ID";

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
                    if (!Convert.IsDBNull(dr["ComponentMaterialID"]))
                        obj.ComponentMaterialID = (int)dr["ComponentMaterialID"];
                    if (!Convert.IsDBNull(dr["Barcode"]))
                        obj.Barcode = (string)dr["Barcode"];
                    if (!Convert.IsDBNull(dr["OutputName"]))
                        obj.OutputName = (string)dr["OutputName"];
                    if (!Convert.IsDBNull(dr["MprA"]))
                        obj.MprA = (string)dr["MprA"];
                    if (!Convert.IsDBNull(dr["MprB"]))
                        obj.MprB = (string)dr["MprB"];
                    if (!Convert.IsDBNull(dr["MachineFile"]))
                        obj.MachineFile = (string)dr["MachineFile"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        obj.Remark = (string)dr["Remark"];
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

        #region ComponentMaterialExtension CountObjects()、ExistsObjects()
        public int CountComponentMaterialExtension()
        {
            string sql = @"Select Count(*) From [ComponentMaterialExtension] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountComponentMaterialExtensionID(Int32 ID)
        {
            string sql = @"Select Count(*) From [ComponentMaterialExtension]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsComponentMaterialExtension()
        {
            string sql = @"Select Top 1 * From [ComponentMaterialExtension] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsComponentMaterialExtensionID(Int32 ID)
        {
            string sql = @"Select Top 1 * From [ComponentMaterialExtension]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region ComponentMaterialExtension SearchObject()
        public SearchResult SearchComponentMaterialExtension(SearchComponentMaterialExtensionArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              [ID]
                             ,[ComponentMaterialID]
                             ,[Barcode]
                             ,[OutputName]
                             ,[MprA]
                             ,[MprB]
                             ,[MachineFile]
                             ,[Remark]
                       From [ComponentMaterialExtension] With(NoLock) Where 1=1 ");

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