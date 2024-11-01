using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNT2_2210900089_VuVietAnh.Models;

namespace CNT2_2210900089_VuVietAnh.Controllers
{
    public class DANHMUCController : Controller
    {
        private Web_ban_banhVEntities db = new Web_ban_banhVEntities();

        // GET: DANHMUC
        public async Task<ActionResult> Index()
        {
            return View(await db.DANH_MUC.ToListAsync());
        }

        // GET: DANHMUC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = await db.DANH_MUC.FindAsync(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // GET: DANHMUC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DANHMUC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaDM,TenDM")] DANH_MUC dANH_MUC)
        {
            if (ModelState.IsValid)
            {
                db.DANH_MUC.Add(dANH_MUC);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dANH_MUC);
        }

        // GET: DANHMUC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = await db.DANH_MUC.FindAsync(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // POST: DANHMUC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaDM,TenDM")] DANH_MUC dANH_MUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_MUC).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dANH_MUC);
        }

        // GET: DANHMUC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = await db.DANH_MUC.FindAsync(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // POST: DANHMUC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DANH_MUC dANH_MUC = await db.DANH_MUC.FindAsync(id);
            db.DANH_MUC.Remove(dANH_MUC);
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
