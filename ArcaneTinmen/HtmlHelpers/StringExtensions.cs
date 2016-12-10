using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcaneTinmen.HtmlHelpers
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : String.Format("{0}...", value.Substring(0, maxLength));
        }
    }
}