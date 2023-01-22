using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Optimization;
using Newtonsoft.Json;
using Garcia.Application;
using CreditApplication.BL;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace CreditApplication.UI
{
    public class UIStateManager : StateManager<UIStateManager>
    {
    }
}
