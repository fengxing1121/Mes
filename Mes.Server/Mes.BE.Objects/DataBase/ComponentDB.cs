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

        #region BE_Component SearchObject()
        public SearchResult SearchComponent(SearchComponentArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[RoleName] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [ComponentID]
                                          ,[ComponentNum]
                                          ,[ComponentName]
                                          ,[ProductCategory]
                                          ,[ComponetCategory]
                                          ,[Color]
                                          ,[Style]
                                          ,[Model]
                                          ,[Width]
                                          ,[Height]
                                          ,[Length]
                                          ,[DesignBy]
                                          ,[ImageUrl]
                                          ,[DesignSource]
                                          ,[CreatedBy]
                                          ,[Created]
                                          ,[ModifiedBy]
                                          ,[Modified]
                                      FROM 
                                          [BE_Component] with(nolock)
	                                  WHERE 1=1");
            this.SetParameters_In(mbBuilder, cmd, "ComponentID", "mbComponentIDs", args.ComponentIDs);

            if (!string.IsNullOrEmpty(args.ComponentName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ComponentName", "mbComponentName", args.ComponentName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.Style))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Style", "mbStyle", args.Style);
            }
            if (!string.IsNullOrEmpty(args.Model))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Model", "mbModel", args.Model);
            }
            if (!string.IsNullOrEmpty(args.DesignBy))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DesignBy", "mbDesignBy", args.DesignBy);
            }
            if (!string.IsNullOrEmpty(args.ProductCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ProductCategory", "mbProductCategory", args.ProductCategory);
            }
            if (!string.IsNullOrEmpty(args.ComponentCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ComponentCategory", "mbComponentCategory", args.ComponentCategory);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion

    }
}
