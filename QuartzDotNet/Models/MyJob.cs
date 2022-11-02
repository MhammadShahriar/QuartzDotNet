using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace QuartzDotNet.Models
{
    public class MyJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    Database1Entities db = new Database1Entities();

                    QuartzTableData obj = new QuartzTableData()
                    {
                        Name = "Date : " + DateTime.Now.ToLongDateString(),
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