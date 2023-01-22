using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Garcia;
using Newtonsoft.Json;
using Garcia.Application;
using System.Web.Optimization;

namespace CreditApplication.UI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            List<Language> languages = EntityManager.Instance.GetItems<Language>();
            DependencyManager.Localizer = new GarciaApplicationLocalizer(languages.Select(x => x.CultureCode).ToList());
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            ModelBinders.Binders.DefaultBinder = new FlagEnumModelBinder();
        }
    }
}