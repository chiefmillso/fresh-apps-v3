using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Fresh.Core.Web.App_Start;
using Fresh.Web.App_Start;

namespace Fresh.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Assemblies.Add(Assembly.GetExecutingAssembly());

            AutofacConfig.Configure(bootstrapper);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}