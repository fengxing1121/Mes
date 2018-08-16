using System;
using System.Text.RegularExpressions;

namespace Mes.Client.Utility.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsGuidNull(string value)
        {
            bool flag = true;
            try
            {
                Guid guid = new Guid(value);
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }
            return flag;
        }
    }
}
