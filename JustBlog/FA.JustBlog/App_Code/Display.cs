using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.App_Code
{
    public static class Display
    {
        public static HtmlString DisplayDateTimeValue(this HtmlHelper htmlHelper, DateTime dateTime)
        {
            string result = dateTime.ToLongDateString();
            return new HtmlString(result);

        }
    }
}