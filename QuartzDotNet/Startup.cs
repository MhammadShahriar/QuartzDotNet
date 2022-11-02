using Microsoft.Owin;
using Owin;
using QuartzDotNet.Controllers;
using QuartzDotNet.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(QuartzDotNet.Startup))]
namespace QuartzDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Task.Run(async () =>
            {
                MyScheduler shdObj = new MyScheduler();

                await shdObj.StartAsync();
            });


            //    Task.Delay(1000).GetAwaiter().GetResult();


            Task.Run(async () =>
            {
                for (;;)
                {
                    string time = DateTime.Now.ToLongTimeString();

                    await Task.Delay(1000);

                    Debug.WriteLine("Your Time is : " + time);

                    if (String.Equals(time, "2:45:26 AM"))
                    {
                        Debug.WriteLine("I love you..." + time);

                        HomeController home = new HomeController();

                        //home.ExecuteWorkAsync().GetAwaiter().GetResult();

                        await home.ExecuteWorkAsync();
                    }

                    if (String.Equals(time, "2:50:28 AM"))
                    {
                        Debug.WriteLine("I love you 2222..." + time);

                        HomeController home = new HomeController();

                        //home.ExecuteWorkAsync().GetAwaiter().GetResult();

                        await home.ExecuteWorkAsync();
                    }
                }
            });
        }
    }
}
