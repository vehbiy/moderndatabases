using Garcia.Application.Filter;
using System.Web;
using System.Web.Mvc;

namespace CreditApplication.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ClickFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
