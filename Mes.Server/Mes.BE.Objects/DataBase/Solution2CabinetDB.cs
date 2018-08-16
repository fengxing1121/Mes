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
        #region BE_Solution2Cabinet InsertObject()
        public int InsertSolution2Cabinet(Solution2Cabinet obj)
        {
            string sql = @"INSERT INTO[BE_Solution2Cabinet]([CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@CabinetID
				, @SolutionID
				, @CabinetGroup
				, @CabinetName
				, @Size
				, @MaterialStyle
				, @MaterialCategory
				, @Color
				, @Unit
				, @Qty
				, @FileUploadFlag
				, @Sequence
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

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

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

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", Convert2DBnull(obj.FileUploadFlag));
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

        #region BE_Solution2Cabinet UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSolution2CabinetByCabinetID(Solution2Cabinet obj)
        {
            string sql = @"UPDATE [BE_Solution2Cabinet] SET [SolutionID]=@SolutionID
				, [CabinetGroup]=@CabinetGroup
				, [CabinetName]=@CabinetName
				, [Size]=@Size
				, [MaterialStyle]=@MaterialStyle
				, [MaterialCategory]=@MaterialCategory
				, [Color]=@Color
				, [Unit]=@Unit
				, [Qty]=@Qty
				, [FileUploadFlag]=@FileUploadFlag
				, [Sequence]=@Sequence
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

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

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", Convert2DBnull(obj.FileUploadFlag));
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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
        public int DeleteSolution2CabinetByCabinetID(Guid cabinetID)
        {
            string sql = @"DELETE [BE_Solution2Cabinet] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSolution2CabinetByCabinetID(Solution2Cabinet obj)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
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
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    obj.CabinetGroup = dr["CabinetGroup"].ToString();
                    obj.CabinetName = dr["CabinetName"].ToString();
                    obj.Size = dr["Size"].ToString();
                    obj.MaterialStyle = dr["MaterialStyle"].ToString();
                    obj.MaterialCategory = dr["MaterialCategory"].ToString();
                    obj.Color = dr["Color"].ToString();
                    obj.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        obj.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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

        #region BE_Solution2Cabinet CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSolution2Cabinets()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByCabinetName(string cabinetName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsBySize(string size)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByColor(string color)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSolution2Cabinets()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Solution2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = "SELECT TOP 1 [CabinetGroup] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByCabinetName(string cabinetName)
        {
            string sql = "SELECT TOP 1 [CabinetName] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsBySize(string size)
        {
            string sql = "SELECT TOP 1 [Size] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = "SELECT TOP 1 [MaterialStyle] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = "SELECT TOP 1 [MaterialCategory] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByColor(string color)
        {
            string sql = "SELECT TOP 1 [Color] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = "SELECT TOP 1 [FileUploadFlag] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Solution2Cabinet] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSolution2Cabinets()
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByCabinetName(string cabinetName)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsBySize(string size)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByColor(string color)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Solution2Cabinet] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Solution2Cabinet> LoadSolution2Cabinets()
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByCabinetGroup(string cabinetGroup)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByCabinetName(string cabinetName)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [CabinetName]=@CabinetName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetName = new SqlParameter("CabinetName", cabinetName);
            pCabinetName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetName);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsBySize(string size)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByMaterialStyle(string materialStyle)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByMaterialCategory(string materialCategory)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByColor(string color)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByUnit(string unit)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByQty(decimal qty)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByFileUploadFlag(bool fileUploadFlag)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [FileUploadFlag]=@FileUploadFlag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFileUploadFlag = new SqlParameter("FileUploadFlag", fileUploadFlag);
            pFileUploadFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFileUploadFlag);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsBySequence(int sequence)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByRemark(string remark)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByCreated(DateTime created)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByModified(DateTime modified)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<Solution2Cabinet> LoadSolution2CabinetsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [CabinetID]
				, [SolutionID]
				, [CabinetGroup]
				, [CabinetName]
				, [Size]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Color]
				, [Unit]
				, [Qty]
				, [FileUploadFlag]
				, [Sequence]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution2Cabinet] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Solution2Cabinet> ret = new List<Solution2Cabinet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Cabinet iret = new Solution2Cabinet();
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.CabinetName = dr["CabinetName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["FileUploadFlag"]))
                        iret.FileUploadFlag = (bool)dr["FileUploadFlag"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
    }
}
