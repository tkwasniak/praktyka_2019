using Common.Logger;
using FluentValidation.Mvc;
using MovieRental.Web.Autofac;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace MovieRental.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            var logger = new Logger("PortalLog");
            logger.Error(exception, "exception message");

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        routeData.Values.Add("action", "NotFound");
                        break;
                    default:
                        routeData.Values.Add("action", "General");
                        break;
                }
            }
            else
            {
                routeData.Values.Add("action", "General");
            }
            routeData.Values.Add("message", exception.Message);
            Server.ClearError();
            Response.RedirectToRoute(routeData.Values);
        }

    }
}

