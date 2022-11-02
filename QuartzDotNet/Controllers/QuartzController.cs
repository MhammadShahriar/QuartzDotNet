using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuartzDotNet;

namespace QuartzDotNet.Controllers
{
    public class QuartzController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Quartz
        public async Task<ActionResult> Index()
        {
            return View(await db.QuartzTableDatas.ToListAsync());
        }

        // GET: Quartz/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuartzTableData quartzTableData = await db.QuartzTableDatas.FindAsync(id);
            if (quartzTableData == null)
            {
                return HttpNotFound();
            }
            return View(quartzTableData);
        }

        // GET: Quartz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quartz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateTime")] QuartzTableData quartzTableData)
        {
            if (ModelState.IsValid)
            {
                db.QuartzTableDatas.Add(quartzTableData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(quartzTableData);
        }

        // GET: Quartz/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuartzTableData quartzTableData = await db.QuartzTableDatas.FindAsync(id);
            if (quartzTableData == null)
            {
                return HttpNotFound();
            }
            return View(quartzTableData);
        }

        // POST: Quartz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateTime")] QuartzTableData quartzTableData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quartzTableData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(quartzTableData);
        }

        // GET: Quartz/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuartzTableData quartzTableData = await db.QuartzTableDatas.FindAsync(id);
            if (quartzTableData == null)
            {
                return HttpNotFound();
            }
            return View(quartzTableData);
        }

        // POST: Quartz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuartzTableData quartzTableData = await db.QuartzTableDatas.FindAsync(id);
            db.QuartzTableDatas.Remove(quartzTableData);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
