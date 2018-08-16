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

        #region BE_Company SearchObject()
        public SearchResult SearchCompany(SearchCompanyArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Province] ASC,[City] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT *
                                      FROM 
	                                      [BE_Company] with(nolock)
	                                  WHERE 1=1");

            if (!string.IsNullOrEmpty(args.CompanyCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CompanyCode", "mbCompanyCode", args.CompanyCode);
            }
            if (!string.IsNullOrEmpty(args.CompanyName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CompanyName", "mbCompanyName", args.CompanyName);
            }
            if (!string.IsNullOrEmpty(args.Email))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Email", "mbEmail", args.Email);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Address", "mbAddress", args.Address);
            }
            if (!string.IsNullOrEmpty(args.LinkMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "LinkMan", "mbLinkMan", args.LinkMan);
            }
            if (!string.IsNullOrEmpty(args.ReferralCode))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "ReferralCode", "mbReferralCode", args.ReferralCode);
            }
            this.SetParameters_Between(mbBuilder, cmd, "Created", "mbCreated", args.CreatedFrom, args.CreatedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion

    }
}
