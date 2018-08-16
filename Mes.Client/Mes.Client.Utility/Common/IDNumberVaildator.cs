
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Utility
{
    public class IDNumberValidator
    {
        static int[] city = new int[] { 11, 12, 13, 14, 15, 21, 22, 23, 31, 32, 33, 34, 35, 36, 37, 41, 42, 43, 44, 45, 46, 50, 51, 52, 53, 54, 61, 62, 63, 64, 65, 71, 81, 82, 91 };
        readonly static string MESSAGE = "证件号码没有填写或格式不正确 !";

        public static string validate(string IDType, string IDNumber)
        {
            if (String.IsNullOrEmpty(IDNumber))
            {
                return MESSAGE;
            }
            switch (IDType)
            {
                case "身份证":
                    return chs_validator(IDNumber);
                case "港澳台通行证":
                    return "";
                case "护照":
                    return "";
                case "其它":
                    return "";
                default:
                    return "证件类型错误";
            }
        }

        private static string chs_validator(string IDNumber)
        {
            if (IDNumber.Length != 18)
            {
                return MESSAGE;
            }
            try
            {
                //校验格式
                if (System.Text.RegularExpressions.Regex.IsMatch(IDNumber, @"(^\d{17}(?:\d|x)$)|(^\d{15}$)") == false)
                {
                    return MESSAGE;
                }
                //
                int IDCity = int.Parse(IDNumber.Substring(0, 2));
                if (Array.IndexOf(city, IDCity) < 0)
                {
                    return MESSAGE;
                }
                double iSum = 0;
                IDNumber = IDNumber.ToLower();
                IDNumber = IDNumber.Replace("x", "a");
                for (int i = 17; i >= 0; i--)
                {
                    iSum += (System.Math.Pow(2, i) % 11) * int.Parse(IDNumber[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);
                }
                if (iSum % 11 != 1)
                {
                    return MESSAGE;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                return MESSAGE;
            }
            return "";
        }

    }
}