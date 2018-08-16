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
        #region BE_CutTemplate InsertObject()
        public int InsertCutTemplate(CutTemplate obj)
        {
            string sql = @"INSERT INTO[BE_CutTemplate]([TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@TemplateID
				, @TemplateCode
				, @TemplateName
				, @Saw
				, @TrimZ
				, @PackageHeight
				, @MaxTurns
				, @MinWidthBand
				, @MaxLengthBand
				, @DirectCut
				, @SortBy
				, @SortInBand
				, @Sequence
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", Convert2DBnull(obj.TemplateID));
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", Convert2DBnull(obj.TemplateCode));
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", Convert2DBnull(obj.TemplateName));
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            SqlParameter pSaw = new SqlParameter("Saw", Convert2DBnull(obj.Saw));
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", Convert2DBnull(obj.TrimZ));
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", Convert2DBnull(obj.PackageHeight));
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", Convert2DBnull(obj.MaxTurns));
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", Convert2DBnull(obj.MinWidthBand));
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", Convert2DBnull(obj.MaxLengthBand));
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", Convert2DBnull(obj.DirectCut));
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            SqlParameter pSortBy = new SqlParameter("SortBy", Convert2DBnull(obj.SortBy));
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", Convert2DBnull(obj.SortInBand));
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

        #region BE_CutTemplate UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCutTemplateByTemplateCode(CutTemplate obj)
        {
            string sql = @"UPDATE [BE_CutTemplate] SET [TemplateID]=@TemplateID
				, [TemplateName]=@TemplateName
				, [Saw]=@Saw
				, [TrimZ]=@TrimZ
				, [PackageHeight]=@PackageHeight
				, [MaxTurns]=@MaxTurns
				, [MinWidthBand]=@MinWidthBand
				, [MaxLengthBand]=@MaxLengthBand
				, [DirectCut]=@DirectCut
				, [SortBy]=@SortBy
				, [SortInBand]=@SortInBand
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", Convert2DBnull(obj.TemplateID));
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", Convert2DBnull(obj.TemplateName));
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            SqlParameter pSaw = new SqlParameter("Saw", Convert2DBnull(obj.Saw));
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", Convert2DBnull(obj.TrimZ));
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", Convert2DBnull(obj.PackageHeight));
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", Convert2DBnull(obj.MaxTurns));
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", Convert2DBnull(obj.MinWidthBand));
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", Convert2DBnull(obj.MaxLengthBand));
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", Convert2DBnull(obj.DirectCut));
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            SqlParameter pSortBy = new SqlParameter("SortBy", Convert2DBnull(obj.SortBy));
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", Convert2DBnull(obj.SortInBand));
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", Convert2DBnull(obj.TemplateCode));
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateCutTemplateByTemplateName(CutTemplate obj)
        {
            string sql = @"UPDATE [BE_CutTemplate] SET [TemplateID]=@TemplateID
				, [TemplateCode]=@TemplateCode
				, [Saw]=@Saw
				, [TrimZ]=@TrimZ
				, [PackageHeight]=@PackageHeight
				, [MaxTurns]=@MaxTurns
				, [MinWidthBand]=@MinWidthBand
				, [MaxLengthBand]=@MaxLengthBand
				, [DirectCut]=@DirectCut
				, [SortBy]=@SortBy
				, [SortInBand]=@SortInBand
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", Convert2DBnull(obj.TemplateID));
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", Convert2DBnull(obj.TemplateCode));
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            SqlParameter pSaw = new SqlParameter("Saw", Convert2DBnull(obj.Saw));
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", Convert2DBnull(obj.TrimZ));
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", Convert2DBnull(obj.PackageHeight));
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", Convert2DBnull(obj.MaxTurns));
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", Convert2DBnull(obj.MinWidthBand));
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", Convert2DBnull(obj.MaxLengthBand));
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", Convert2DBnull(obj.DirectCut));
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            SqlParameter pSortBy = new SqlParameter("SortBy", Convert2DBnull(obj.SortBy));
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", Convert2DBnull(obj.SortInBand));
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pTemplateName = new SqlParameter("TemplateName", Convert2DBnull(obj.TemplateName));
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateCutTemplateByTemplateID(CutTemplate obj)
        {
            string sql = @"UPDATE [BE_CutTemplate] SET [TemplateCode]=@TemplateCode
				, [TemplateName]=@TemplateName
				, [Saw]=@Saw
				, [TrimZ]=@TrimZ
				, [PackageHeight]=@PackageHeight
				, [MaxTurns]=@MaxTurns
				, [MinWidthBand]=@MinWidthBand
				, [MaxLengthBand]=@MaxLengthBand
				, [DirectCut]=@DirectCut
				, [SortBy]=@SortBy
				, [SortInBand]=@SortInBand
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", Convert2DBnull(obj.TemplateCode));
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", Convert2DBnull(obj.TemplateName));
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            SqlParameter pSaw = new SqlParameter("Saw", Convert2DBnull(obj.Saw));
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", Convert2DBnull(obj.TrimZ));
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", Convert2DBnull(obj.PackageHeight));
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", Convert2DBnull(obj.MaxTurns));
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", Convert2DBnull(obj.MinWidthBand));
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", Convert2DBnull(obj.MaxLengthBand));
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", Convert2DBnull(obj.DirectCut));
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            SqlParameter pSortBy = new SqlParameter("SortBy", Convert2DBnull(obj.SortBy));
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", Convert2DBnull(obj.SortInBand));
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pTemplateID = new SqlParameter("TemplateID", Convert2DBnull(obj.TemplateID));
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplateByTemplateCode(string templateCode)
        {
            string sql = @"DELETE [BE_CutTemplate] WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", templateCode);
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplateByTemplateName(string templateName)
        {
            string sql = @"DELETE [BE_CutTemplate] WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", templateName);
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplateByTemplateID(Guid templateID)
        {
            string sql = @"DELETE [BE_CutTemplate] WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", templateID);
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCutTemplateByTemplateCode(CutTemplate obj)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", Convert2DBnull(obj.TemplateCode));
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        obj.TemplateID = (Guid)dr["TemplateID"];
                    obj.TemplateCode = dr["TemplateCode"].ToString();
                    obj.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        obj.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        obj.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        obj.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        obj.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        obj.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        obj.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        obj.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        obj.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        obj.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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
        public int LoadCutTemplateByTemplateName(CutTemplate obj)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", Convert2DBnull(obj.TemplateName));
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        obj.TemplateID = (Guid)dr["TemplateID"];
                    obj.TemplateCode = dr["TemplateCode"].ToString();
                    obj.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        obj.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        obj.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        obj.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        obj.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        obj.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        obj.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        obj.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        obj.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        obj.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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
        public int LoadCutTemplateByTemplateID(CutTemplate obj)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", Convert2DBnull(obj.TemplateID));
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        obj.TemplateID = (Guid)dr["TemplateID"];
                    obj.TemplateCode = dr["TemplateCode"].ToString();
                    obj.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        obj.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        obj.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        obj.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        obj.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        obj.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        obj.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        obj.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        obj.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        obj.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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

        #region BE_CutTemplate CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCutTemplates()
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByTemplateID(Guid templateID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", templateID);
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByTemplateCode(string templateCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", templateCode);
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByTemplateName(string templateName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", templateName);
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesBySaw(decimal saw)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Saw]=@Saw";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSaw = new SqlParameter("Saw", saw);
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByTrimZ(decimal trimZ)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TrimZ]=@TrimZ";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", trimZ);
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByPackageHeight(decimal packageHeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByMaxTurns(decimal maxTurns)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [MaxTurns]=@MaxTurns";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", maxTurns);
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByMinWidthBand(decimal minWidthBand)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [MinWidthBand]=@MinWidthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", minWidthBand);
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByMaxLengthBand(decimal maxLengthBand)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [MaxLengthBand]=@MaxLengthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", maxLengthBand);
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByDirectCut(int directCut)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [DirectCut]=@DirectCut";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", directCut);
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesBySortBy(int sortBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [SortBy]=@SortBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortBy = new SqlParameter("SortBy", sortBy);
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesBySortInBand(int sortInBand)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [SortInBand]=@SortInBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", sortInBand);
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCutTemplatesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCutTemplates()
        {
            string sql = "SELECT TOP 1 * FROM [BE_CutTemplate]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByTemplateID(Guid templateID)
        {
            string sql = "SELECT TOP 1 [TemplateID] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", templateID);
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByTemplateCode(string templateCode)
        {
            string sql = "SELECT TOP 1 [TemplateCode] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", templateCode);
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByTemplateName(string templateName)
        {
            string sql = "SELECT TOP 1 [TemplateName] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", templateName);
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesBySaw(decimal saw)
        {
            string sql = "SELECT TOP 1 [Saw] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Saw]=@Saw";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSaw = new SqlParameter("Saw", saw);
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByTrimZ(decimal trimZ)
        {
            string sql = "SELECT TOP 1 [TrimZ] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [TrimZ]=@TrimZ";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", trimZ);
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByPackageHeight(decimal packageHeight)
        {
            string sql = "SELECT TOP 1 [PackageHeight] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByMaxTurns(decimal maxTurns)
        {
            string sql = "SELECT TOP 1 [MaxTurns] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [MaxTurns]=@MaxTurns";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", maxTurns);
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByMinWidthBand(decimal minWidthBand)
        {
            string sql = "SELECT TOP 1 [MinWidthBand] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [MinWidthBand]=@MinWidthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", minWidthBand);
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByMaxLengthBand(decimal maxLengthBand)
        {
            string sql = "SELECT TOP 1 [MaxLengthBand] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [MaxLengthBand]=@MaxLengthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", maxLengthBand);
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByDirectCut(int directCut)
        {
            string sql = "SELECT TOP 1 [DirectCut] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [DirectCut]=@DirectCut";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", directCut);
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesBySortBy(int sortBy)
        {
            string sql = "SELECT TOP 1 [SortBy] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [SortBy]=@SortBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortBy = new SqlParameter("SortBy", sortBy);
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesBySortInBand(int sortInBand)
        {
            string sql = "SELECT TOP 1 [SortInBand] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [SortInBand]=@SortInBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", sortInBand);
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCutTemplatesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_CutTemplate] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCutTemplates()
        {
            string sql = "DELETE FROM [BE_CutTemplate]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByTemplateID(Guid templateID)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", templateID);
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByTemplateCode(string templateCode)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", templateCode);
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByTemplateName(string templateName)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", templateName);
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesBySaw(decimal saw)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [Saw]=@Saw";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSaw = new SqlParameter("Saw", saw);
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByTrimZ(decimal trimZ)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [TrimZ]=@TrimZ";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", trimZ);
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByPackageHeight(decimal packageHeight)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByMaxTurns(decimal maxTurns)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [MaxTurns]=@MaxTurns";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", maxTurns);
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByMinWidthBand(decimal minWidthBand)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [MinWidthBand]=@MinWidthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", minWidthBand);
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByMaxLengthBand(decimal maxLengthBand)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [MaxLengthBand]=@MaxLengthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", maxLengthBand);
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByDirectCut(int directCut)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [DirectCut]=@DirectCut";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", directCut);
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesBySortBy(int sortBy)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [SortBy]=@SortBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortBy = new SqlParameter("SortBy", sortBy);
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesBySortInBand(int sortInBand)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [SortInBand]=@SortInBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", sortInBand);
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCutTemplatesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_CutTemplate] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<CutTemplate> LoadCutTemplates()
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByTemplateID(Guid templateID)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [TemplateID]=@TemplateID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateID = new SqlParameter("TemplateID", templateID);
            pTemplateID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTemplateID);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByTemplateCode(string templateCode)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [TemplateCode]=@TemplateCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateCode = new SqlParameter("TemplateCode", templateCode);
            pTemplateCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateCode);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByTemplateName(string templateName)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [TemplateName]=@TemplateName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTemplateName = new SqlParameter("TemplateName", templateName);
            pTemplateName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTemplateName);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesBySaw(decimal saw)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [Saw]=@Saw";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSaw = new SqlParameter("Saw", saw);
            pSaw.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSaw);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByTrimZ(decimal trimZ)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [TrimZ]=@TrimZ";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTrimZ = new SqlParameter("TrimZ", trimZ);
            pTrimZ.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTrimZ);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByPackageHeight(decimal packageHeight)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByMaxTurns(decimal maxTurns)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [MaxTurns]=@MaxTurns";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxTurns = new SqlParameter("MaxTurns", maxTurns);
            pMaxTurns.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxTurns);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByMinWidthBand(decimal minWidthBand)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [MinWidthBand]=@MinWidthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinWidthBand = new SqlParameter("MinWidthBand", minWidthBand);
            pMinWidthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMinWidthBand);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByMaxLengthBand(decimal maxLengthBand)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [MaxLengthBand]=@MaxLengthBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxLengthBand = new SqlParameter("MaxLengthBand", maxLengthBand);
            pMaxLengthBand.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxLengthBand);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByDirectCut(int directCut)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [DirectCut]=@DirectCut";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDirectCut = new SqlParameter("DirectCut", directCut);
            pDirectCut.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDirectCut);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesBySortBy(int sortBy)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [SortBy]=@SortBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortBy = new SqlParameter("SortBy", sortBy);
            pSortBy.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortBy);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesBySortInBand(int sortInBand)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [SortInBand]=@SortInBand";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSortInBand = new SqlParameter("SortInBand", sortInBand);
            pSortInBand.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortInBand);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesBySequence(int sequence)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByCreated(DateTime created)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByModified(DateTime modified)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<CutTemplate> LoadCutTemplatesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [TemplateID]
				, [TemplateCode]
				, [TemplateName]
				, [Saw]
				, [TrimZ]
				, [PackageHeight]
				, [MaxTurns]
				, [MinWidthBand]
				, [MaxLengthBand]
				, [DirectCut]
				, [SortBy]
				, [SortInBand]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CutTemplate] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<CutTemplate> ret = new List<CutTemplate>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CutTemplate iret = new CutTemplate();
                    if (!Convert.IsDBNull(dr["TemplateID"]))
                        iret.TemplateID = (Guid)dr["TemplateID"];
                    iret.TemplateCode = dr["TemplateCode"].ToString();
                    iret.TemplateName = dr["TemplateName"].ToString();
                    if (!Convert.IsDBNull(dr["Saw"]))
                        iret.Saw = (decimal)dr["Saw"];
                    if (!Convert.IsDBNull(dr["TrimZ"]))
                        iret.TrimZ = (decimal)dr["TrimZ"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["MaxTurns"]))
                        iret.MaxTurns = (decimal)dr["MaxTurns"];
                    if (!Convert.IsDBNull(dr["MinWidthBand"]))
                        iret.MinWidthBand = (decimal)dr["MinWidthBand"];
                    if (!Convert.IsDBNull(dr["MaxLengthBand"]))
                        iret.MaxLengthBand = (decimal)dr["MaxLengthBand"];
                    if (!Convert.IsDBNull(dr["DirectCut"]))
                        iret.DirectCut = (int)dr["DirectCut"];
                    if (!Convert.IsDBNull(dr["SortBy"]))
                        iret.SortBy = (int)dr["SortBy"];
                    if (!Convert.IsDBNull(dr["SortInBand"]))
                        iret.SortInBand = (int)dr["SortInBand"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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

        #region BE_CutTemplate SearchObject()
        public SearchResult SearchCutTemplate(SearchCutTemplateArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Sequence] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [TemplateID]
                                      ,[TemplateCode]
                                      ,[TemplateName]
                                      ,[Saw]
                                      ,[TrimZ]
                                      ,[PackageHeight]
                                      ,[MaxTurns]
                                      ,[MinWidthBand]
                                      ,[MaxLengthBand]
                                      ,[DirectCut]
                                      ,[SortBy]
                                      ,[SortInBand]
                                      ,[Sequence]
                                      ,[Created]
                                      ,[CreatedBy]
                                      ,[Modified]
                                      ,[ModifiedBy]
                                  FROM [BE_CutTemplate]
                                   WHERE 1=1");

            if (args.TemplateID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "TemplateID", "mbTemplateID", args.TemplateID);
            }

            if (!string.IsNullOrEmpty(args.TemplateCode))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "TemplateCode", "mbTemplateCode", args.TemplateCode);
            }
            if (!string.IsNullOrEmpty(args.TemplateName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "TemplateName", "mbTemplateName", args.TemplateName);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
