using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuartzDotNet.Models
{
    public class MyScheduler
    {

        int Hour = Convert.ToInt32(ConfigurationManager.AppSettings["Hour"]);

        int Minute = Convert.ToInt32(ConfigurationManager.AppSettings["Minute"]);

        public async Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();

                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }

                var job = JobBuilder.Create<MyJob>()
                    .WithIdentity("Job1", "group1")
                    .Build();

                var trigger = TriggerBuilder.Create()
                    .WithIdentity("Trigger1", "group1")
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(Hour, Minute))
                    //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 48))    // 24 hours format...16 means 4pm
                    //.WithCronSchedule(ScheduleCronExpression)
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception)
            {

            }
        }
    }
}