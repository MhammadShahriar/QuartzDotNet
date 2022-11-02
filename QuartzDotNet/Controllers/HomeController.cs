using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuartzDotNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task ExecuteWorkAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    Database1Entities db = new Database1Entities();

                    QuartzTableData obj = new QuartzTableData()
                    {
                        Name = "Using For Loop Date : " + DateTime.Now.ToLongDateString(),
                        DateTime = DateTime.Now
                    };

                    db.QuartzTableDatas.Add(obj);

                    db.SaveChanges();

                    //System.Diagnostics.Debug.WriteLine("Welcome Shahriar : Time : " + DateTime.Now.ToLongTimeString());
                }
                catch (Exception)
                {
                }
            });
        }
    }
}