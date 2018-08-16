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
        #region ComponentMaterial InsertObject()
        public int InsertComponentMaterial(ComponentMaterial obj)
        {
            string sql = @"Insert Into [ComponentMaterial](
                              [ID]
                             ,[ComponentID]
                             ,[MaterialCode]
                             ,[MaterialName]
                             ,[Specification]
                             ,[Unit]
                             ,[Quantity]
                             ,[PlateName]
                             ,[Material]
                             ,[Color]
                             ,[Length]
                             ,[Width]
                             ,[Height]
                             ,[CutLength]
                             ,[CutWidth]
                             ,[CutHeight]
                             ,[CutArea]
                             ,[EdgeFront]
                             ,[EdgeBack]
                             ,[EdgeLeft]
                             ,[EdgeRight]
                             ,[Veins]
                             ,[Routing]
                             ,[IsOptimization]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
            )Values (
                              @ID
                             ,@ComponentID
                             ,@MaterialCode
                             ,@MaterialName
                             ,@Specification
                             ,@Unit
                             ,@Quantity
                             ,@PlateName
                             ,@Material
                             ,@Color
                             ,@Length
                             ,@Width
                             ,@Height
                             ,@CutLength
                             ,@CutWidth
                             ,@CutHeight
                             ,@CutArea
                             ,@EdgeFront
                             ,@EdgeBack
                             ,@EdgeLeft
                             ,@EdgeRight
                             ,@Veins
                             ,@Routing
                             ,@IsOptimization
                             ,@Status
                             ,@Created
                             ,@CreatedBy
                             ,@Modified
                             ,@ModifiedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", Convert2DBnull(obj.MaterialCode));
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", Convert2DBnull(obj.MaterialName));
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            SqlParameter pSpecification = new SqlParameter("Specification", Convert2DBnull(obj.Specification));
            pSpecification.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSpecification);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pQuantity = new SqlParameter("Quantity", Convert2DBnull(obj.Quantity));
            pQuantity.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuantity);

            SqlParameter pPlateName = new SqlParameter("PlateName", Convert2DBnull(obj.PlateName));
            pPlateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateName);

            SqlParameter pMaterial = new SqlParameter("Material", Convert2DBnull(obj.Material));
            pMaterial.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterial);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pLength = new SqlParameter("Length", Convert2DBnull(obj.Length));
            pLength.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLength);

            SqlParameter pWidth = new SqlParameter("Width", Convert2DBnull(obj.Width));
            pWidth.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWidth);

            SqlParameter pHeight = new SqlParameter("Height", Convert2DBnull(obj.Height));
            pHeight.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHeight);

            SqlParameter pCutLength = new SqlParameter("CutLength", Convert2DBnull(obj.CutLength));
            pCutLength.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutLength);

            SqlParameter pCutWidth = new SqlParameter("CutWidth", Convert2DBnull(obj.CutWidth));
            pCutWidth.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutWidth);

            SqlParameter pCutHeight = new SqlParameter("CutHeight", Convert2DBnull(obj.CutHeight));
            pCutHeight.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutHeight);

            SqlParameter pCutArea = new SqlParameter("CutArea", Convert2DBnull(obj.CutArea));
            pCutArea.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutArea);

            SqlParameter pEdgeFront = new SqlParameter("EdgeFront", Convert2DBnull(obj.EdgeFront));
            pEdgeFront.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeFront);

            SqlParameter pEdgeBack = new SqlParameter("EdgeBack", Convert2DBnull(obj.EdgeBack));
            pEdgeBack.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeBack);

            SqlParameter pEdgeLeft = new SqlParameter("EdgeLeft", Convert2DBnull(obj.EdgeLeft));
            pEdgeLeft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeLeft);

            SqlParameter pEdgeRight = new SqlParameter("EdgeRight", Convert2DBnull(obj.EdgeRight));
            pEdgeRight.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeRight);

            SqlParameter pVeins = new SqlParameter("Veins", Convert2DBnull(obj.Veins));
            pVeins.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVeins);

            SqlParameter pRouting = new SqlParameter("Routing", Convert2DBnull(obj.Routing));
            pRouting.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRouting);

            SqlParameter pIsOptimization = new SqlParameter("IsOptimization", Convert2DBnull(obj.IsOptimization));
            pIsOptimization.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimization);

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

        #region ComponentMaterial UpdateObject()、DeleteObject()
        public int UpdateComponentMaterialByID(ComponentMaterial obj)
        {
            string sql = @"Update [ComponentMaterial] Set
                              [ComponentID]=@ComponentID
                             ,[MaterialCode]=@MaterialCode
                             ,[MaterialName]=@MaterialName
                             ,[Specification]=@Specification
                             ,[Unit]=@Unit
                             ,[Quantity]=@Quantity
                             ,[PlateName]=@PlateName
                             ,[Material]=@Material
                             ,[Color]=@Color
                             ,[Length]=@Length
                             ,[Width]=@Width
                             ,[Height]=@Height
                             ,[CutLength]=@CutLength
                             ,[CutWidth]=@CutWidth
                             ,[CutHeight]=@CutHeight
                             ,[CutArea]=@CutArea
                             ,[EdgeFront]=@EdgeFront
                             ,[EdgeBack]=@EdgeBack
                             ,[EdgeLeft]=@EdgeLeft
                             ,[EdgeRight]=@EdgeRight
                             ,[Veins]=@Veins
                             ,[Routing]=@Routing
                             ,[IsOptimization]=@IsOptimization
                             ,[Status]=@Status
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                             ,[Modified]=@Modified
                             ,[ModifiedBy]=@ModifiedBy
                          Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", Convert2DBnull(obj.MaterialCode));
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", Convert2DBnull(obj.MaterialName));
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            SqlParameter pSpecification = new SqlParameter("Specification", Convert2DBnull(obj.Specification));
            pSpecification.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSpecification);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pQuantity = new SqlParameter("Quantity", Convert2DBnull(obj.Quantity));
            pQuantity.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuantity);

            SqlParameter pPlateName = new SqlParameter("PlateName", Convert2DBnull(obj.PlateName));
            pPlateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateName);

            SqlParameter pMaterial = new SqlParameter("Material", Convert2DBnull(obj.Material));
            pMaterial.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterial);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pLength = new SqlParameter("Length", Convert2DBnull(obj.Length));
            pLength.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLength);

            SqlParameter pWidth = new SqlParameter("Width", Convert2DBnull(obj.Width));
            pWidth.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWidth);

            SqlParameter pHeight = new SqlParameter("Height", Convert2DBnull(obj.Height));
            pHeight.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHeight);

            SqlParameter pCutLength = new SqlParameter("CutLength", Convert2DBnull(obj.CutLength));
            pCutLength.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutLength);

            SqlParameter pCutWidth = new SqlParameter("CutWidth", Convert2DBnull(obj.CutWidth));
            pCutWidth.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutWidth);

            SqlParameter pCutHeight = new SqlParameter("CutHeight", Convert2DBnull(obj.CutHeight));
            pCutHeight.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutHeight);

            SqlParameter pCutArea = new SqlParameter("CutArea", Convert2DBnull(obj.CutArea));
            pCutArea.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCutArea);

            SqlParameter pEdgeFront = new SqlParameter("EdgeFront", Convert2DBnull(obj.EdgeFront));
            pEdgeFront.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeFront);

            SqlParameter pEdgeBack = new SqlParameter("EdgeBack", Convert2DBnull(obj.EdgeBack));
            pEdgeBack.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeBack);

            SqlParameter pEdgeLeft = new SqlParameter("EdgeLeft", Convert2DBnull(obj.EdgeLeft));
            pEdgeLeft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeLeft);

            SqlParameter pEdgeRight = new SqlParameter("EdgeRight", Convert2DBnull(obj.EdgeRight));
            pEdgeRight.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEdgeRight);

            SqlParameter pVeins = new SqlParameter("Veins", Convert2DBnull(obj.Veins));
            pVeins.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVeins);

            SqlParameter pRouting = new SqlParameter("Routing", Convert2DBnull(obj.Routing));
            pRouting.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRouting);

            SqlParameter pIsOptimization = new SqlParameter("IsOptimization", Convert2DBnull(obj.IsOptimization));
            pIsOptimization.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimization);

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

        public int DeleteComponentMaterialByID(Int32 ID)
        {
            string sql = @"Delete [ComponentMaterial]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ComponentMaterial LoadObject()
        public List<ComponentMaterial> LoadComponentMaterials()
        {
            string sql = @"Select 
                              [ID]
                             ,[ComponentID]
                             ,[MaterialCode]
                             ,[MaterialName]
                             ,[Specification]
                             ,[Unit]
                             ,[Quantity]
                             ,[PlateName]
                             ,[Material]
                             ,[Color]
                             ,[Length]
                             ,[Width]
                             ,[Height]
                             ,[CutLength]
                             ,[CutWidth]
                             ,[CutHeight]
                             ,[CutArea]
                             ,[EdgeFront]
                             ,[EdgeBack]
                             ,[EdgeLeft]
                             ,[EdgeRight]
                             ,[Veins]
                             ,[Routing]
                             ,[IsOptimization]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ComponentMaterial] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ComponentMaterial> ret = new List<ComponentMaterial>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ComponentMaterial iret = new ComponentMaterial();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["MaterialCode"]))
                        iret.MaterialCode = (string)dr["MaterialCode"];
                    if (!Convert.IsDBNull(dr["MaterialName"]))
                        iret.MaterialName = (string)dr["MaterialName"];
                    if (!Convert.IsDBNull(dr["Specification"]))
                        iret.Specification = (string)dr["Specification"];
                    if (!Convert.IsDBNull(dr["Unit"]))
                        iret.Unit = (string)dr["Unit"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        iret.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["PlateName"]))
                        iret.PlateName = (string)dr["PlateName"];
                    if (!Convert.IsDBNull(dr["Material"]))
                        iret.Material = (string)dr["Material"];
                    if (!Convert.IsDBNull(dr["Color"]))
                        iret.Color = (string)dr["Color"];
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (string)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (string)dr["Width"];
                    if (!Convert.IsDBNull(dr["Height"]))
                        iret.Height = (string)dr["Height"];
                    if (!Convert.IsDBNull(dr["CutLength"]))
                        iret.CutLength = (string)dr["CutLength"];
                    if (!Convert.IsDBNull(dr["CutWidth"]))
                        iret.CutWidth = (string)dr["CutWidth"];
                    if (!Convert.IsDBNull(dr["CutHeight"]))
                        iret.CutHeight = (string)dr["CutHeight"];
                    if (!Convert.IsDBNull(dr["CutArea"]))
                        iret.CutArea = (string)dr["CutArea"];
                    if (!Convert.IsDBNull(dr["EdgeFront"]))
                        iret.EdgeFront = (string)dr["EdgeFront"];
                    if (!Convert.IsDBNull(dr["EdgeBack"]))
                        iret.EdgeBack = (string)dr["EdgeBack"];
                    if (!Convert.IsDBNull(dr["EdgeLeft"]))
                        iret.EdgeLeft = (string)dr["EdgeLeft"];
                    if (!Convert.IsDBNull(dr["EdgeRight"]))
                        iret.EdgeRight = (string)dr["EdgeRight"];
                    if (!Convert.IsDBNull(dr["Veins"]))
                        iret.Veins = (string)dr["Veins"];
                    if (!Convert.IsDBNull(dr["Routing"]))
                        iret.Routing = (string)dr["Routing"];
                    if (!Convert.IsDBNull(dr["IsOptimization"]))
                        iret.IsOptimization = (bool)dr["IsOptimization"];
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
         
        public List<ComponentMaterial> LoadComponentMaterialByID(ComponentMaterial obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[ComponentID]
                             ,[MaterialCode]
                             ,[MaterialName]
                             ,[Specification]
                             ,[Unit]
                             ,[Quantity]
                             ,[PlateName]
                             ,[Material]
                             ,[Color]
                             ,[Length]
                             ,[Width]
                             ,[Height]
                             ,[CutLength]
                             ,[CutWidth]
                             ,[CutHeight]
                             ,[CutArea]
                             ,[EdgeFront]
                             ,[EdgeBack]
                             ,[EdgeLeft]
                             ,[EdgeRight]
                             ,[Veins]
                             ,[Routing]
                             ,[IsOptimization]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ComponentMaterial] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            List<ComponentMaterial> ret = new List<ComponentMaterial>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ComponentMaterial iret = new ComponentMaterial();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (int)dr["ID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["MaterialCode"]))
                        iret.MaterialCode = (string)dr["MaterialCode"];
                    if (!Convert.IsDBNull(dr["MaterialName"]))
                        iret.MaterialName = (string)dr["MaterialName"];
                    if (!Convert.IsDBNull(dr["Specification"]))
                        iret.Specification = (string)dr["Specification"];
                    if (!Convert.IsDBNull(dr["Unit"]))
                        iret.Unit = (string)dr["Unit"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        iret.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["PlateName"]))
                        iret.PlateName = (string)dr["PlateName"];
                    if (!Convert.IsDBNull(dr["Material"]))
                        iret.Material = (string)dr["Material"];
                    if (!Convert.IsDBNull(dr["Color"]))
                        iret.Color = (string)dr["Color"];
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (string)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (string)dr["Width"];
                    if (!Convert.IsDBNull(dr["Height"]))
                        iret.Height = (string)dr["Height"];
                    if (!Convert.IsDBNull(dr["CutLength"]))
                        iret.CutLength = (string)dr["CutLength"];
                    if (!Convert.IsDBNull(dr["CutWidth"]))
                        iret.CutWidth = (string)dr["CutWidth"];
                    if (!Convert.IsDBNull(dr["CutHeight"]))
                        iret.CutHeight = (string)dr["CutHeight"];
                    if (!Convert.IsDBNull(dr["CutArea"]))
                        iret.CutArea = (string)dr["CutArea"];
                    if (!Convert.IsDBNull(dr["EdgeFront"]))
                        iret.EdgeFront = (string)dr["EdgeFront"];
                    if (!Convert.IsDBNull(dr["EdgeBack"]))
                        iret.EdgeBack = (string)dr["EdgeBack"];
                    if (!Convert.IsDBNull(dr["EdgeLeft"]))
                        iret.EdgeLeft = (string)dr["EdgeLeft"];
                    if (!Convert.IsDBNull(dr["EdgeRight"]))
                        iret.EdgeRight = (string)dr["EdgeRight"];
                    if (!Convert.IsDBNull(dr["Veins"]))
                        iret.Veins = (string)dr["Veins"];
                    if (!Convert.IsDBNull(dr["Routing"]))
                        iret.Routing = (string)dr["Routing"];
                    if (!Convert.IsDBNull(dr["IsOptimization"]))
                        iret.IsOptimization = (bool)dr["IsOptimization"];
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

        public int LoadComponentMaterial(ComponentMaterial obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[ComponentID]
                             ,[MaterialCode]
                             ,[MaterialName]
                             ,[Specification]
                             ,[Unit]
                             ,[Quantity]
                             ,[PlateName]
                             ,[Material]
                             ,[Color]
                             ,[Length]
                             ,[Width]
                             ,[Height]
                             ,[CutLength]
                             ,[CutWidth]
                             ,[CutHeight]
                             ,[CutArea]
                             ,[EdgeFront]
                             ,[EdgeBack]
                             ,[EdgeLeft]
                             ,[EdgeRight]
                             ,[Veins]
                             ,[Routing]
                             ,[IsOptimization]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ComponentMaterial] With(NoLock) Where ID=@ID";

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
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        obj.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["MaterialCode"]))
                        obj.MaterialCode = (string)dr["MaterialCode"];
                    if (!Convert.IsDBNull(dr["MaterialName"]))
                        obj.MaterialName = (string)dr["MaterialName"];
                    if (!Convert.IsDBNull(dr["Specification"]))
                        obj.Specification = (string)dr["Specification"];
                    if (!Convert.IsDBNull(dr["Unit"]))
                        obj.Unit = (string)dr["Unit"];
                    if (!Convert.IsDBNull(dr["Quantity"]))
                        obj.Quantity = (decimal)dr["Quantity"];
                    if (!Convert.IsDBNull(dr["PlateName"]))
                        obj.PlateName = (string)dr["PlateName"];
                    if (!Convert.IsDBNull(dr["Material"]))
                        obj.Material = (string)dr["Material"];
                    if (!Convert.IsDBNull(dr["Color"]))
                        obj.Color = (string)dr["Color"];
                    if (!Convert.IsDBNull(dr["Length"]))
                        obj.Length = (string)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        obj.Width = (string)dr["Width"];
                    if (!Convert.IsDBNull(dr["Height"]))
                        obj.Height = (string)dr["Height"];
                    if (!Convert.IsDBNull(dr["CutLength"]))
                        obj.CutLength = (string)dr["CutLength"];
                    if (!Convert.IsDBNull(dr["CutWidth"]))
                        obj.CutWidth = (string)dr["CutWidth"];
                    if (!Convert.IsDBNull(dr["CutHeight"]))
                        obj.CutHeight = (string)dr["CutHeight"];
                    if (!Convert.IsDBNull(dr["CutArea"]))
                        obj.CutArea = (string)dr["CutArea"];
                    if (!Convert.IsDBNull(dr["EdgeFront"]))
                        obj.EdgeFront = (string)dr["EdgeFront"];
                    if (!Convert.IsDBNull(dr["EdgeBack"]))
                        obj.EdgeBack = (string)dr["EdgeBack"];
                    if (!Convert.IsDBNull(dr["EdgeLeft"]))
                        obj.EdgeLeft = (string)dr["EdgeLeft"];
                    if (!Convert.IsDBNull(dr["EdgeRight"]))
                        obj.EdgeRight = (string)dr["EdgeRight"];
                    if (!Convert.IsDBNull(dr["Veins"]))
                        obj.Veins = (string)dr["Veins"];
                    if (!Convert.IsDBNull(dr["Routing"]))
                        obj.Routing = (string)dr["Routing"];
                    if (!Convert.IsDBNull(dr["IsOptimization"]))
                        obj.IsOptimization = (bool)dr["IsOptimization"];
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

        #region ComponentMaterial CountObjects()、ExistsObjects()
        public int CountComponentMaterial()
        {
            string sql = @"Select Count(*) From [ComponentMaterial] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountComponentMaterialID(Int32 ID)
        {
            string sql = @"Select Count(*) From [ComponentMaterial]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsComponentMaterial()
        {
            string sql = @"Select Top 1 * From [ComponentMaterial] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsComponentMaterialID(Int32 ID)
        {
            string sql = @"Select Top 1 * From [ComponentMaterial]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region ComponentMaterial SearchObject()
        public SearchResult SearchComponentMaterial(SearchComponentMaterialArgs args)
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
                             ,[ComponentID]
                             ,[MaterialCode]
                             ,[MaterialName]
                             ,[Specification]
                             ,[Unit]
                             ,[Quantity]
                             ,[PlateName]
                             ,[Material]
                             ,[Color]
                             ,[Length]
                             ,[Width]
                             ,[Height]
                             ,[CutLength]
                             ,[CutWidth]
                             ,[CutHeight]
                             ,[CutArea]
                             ,[EdgeFront]
                             ,[EdgeBack]
                             ,[EdgeLeft]
                             ,[EdgeRight]
                             ,[Veins]
                             ,[Routing]
                             ,[IsOptimization]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [ComponentMaterial] With(NoLock) Where 1=1 ");

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

        public SearchResult SearchComponentMaterialByComponentID(SearchComponentMaterialArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT    [ID]
                                              ,[ComponentMaterial].[ComponentID]
                                              ,[MaterialCode]
                                              ,[MaterialName]
                                              ,[Specification]
                                              ,[Unit]
                                              ,[ComponentMaterial].[Quantity]
                                              ,[PlateName]
                                              ,[Material]
                                              ,[Color]
                                              ,[Length]
                                              ,[Width]
                                              ,[Height]
                                              ,[CutLength]
                                              ,[CutWidth]
                                              ,[CutHeight]
                                              ,[CutArea]
                                              ,[EdgeFront]
                                              ,[EdgeBack]
                                              ,[EdgeLeft]
                                              ,[EdgeRight]
                                              ,[Veins]
                                              ,[Routing]
                                              ,[IsOptimization]
                                              ,[ComponentMaterial].[Status]
                                              ,[ComponentMaterial].[Created]
                                              ,[ComponentMaterial].[CreatedBy]
                                              ,[ComponentMaterial].[Modified]
                                              ,[ComponentMaterial].[ModifiedBy]
	                                          ,[ComponentTypeName]
                                          FROM [dbo].[ComponentMaterial]
                                          LEFT JOIN  [dbo].[ProductComponent]
                                          ON [ComponentMaterial].[ComponentID]=[ProductComponent].[ComponentID]
                                        Where 1=1 ");

            this.SetParameters_Equals(mbBuilder, cmd, "ComponentMaterial].[ComponentID", "mbComponentID", args.ComponentID);
            
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}