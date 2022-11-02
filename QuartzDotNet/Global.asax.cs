using QuartzDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QuartzDotNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //MyScheduler shdObj = new MyScheduler();

            //shdObj.StartAsync().GetAwaiter().GetResult();

            //Task.Run(async() =>
            //{
            //  MyScheduler shdObj = new MyScheduler();
            //  await shdObj.StartAsync();
            //});         
        }
    }
}
