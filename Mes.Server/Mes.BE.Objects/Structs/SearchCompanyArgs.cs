using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchCompanyArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

       
        public string CompanyCode;
        public string CompanyName;
        public string Province;
        public string City;
        public string Address;
        public string Email;
        public string Mobile;
        public string LinkMan;       
        public string ReferralCode;
        public DateTime? CreatedFrom;
        public DateTime? CreatedTo;
        /// <summary>
        /// 刘耀方
        /// </summary>
        public int sort;

    }
}
