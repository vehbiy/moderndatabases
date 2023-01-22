using Garcia.Application;
using CreditApplication.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CreditApplication.UI
{
    public static class HtmlHelperExtensions
    {
        public static IEnumerable<SelectListItem> GetProjectItems(this HtmlHelper html, bool isEnum = false)
        {
            return new List<SelectListItem>();
        }
    }
}
