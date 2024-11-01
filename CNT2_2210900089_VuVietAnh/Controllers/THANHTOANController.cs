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
    public class THANHTOANController : Controller
    {
        private Web_ban_banhVEntities db = new Web_ban_banhVEntities();

        // GET: THANHTOAN
        public async Task<ActionResult> Index()
        {
            var tHANH_TOAN = db.THANH_TOAN.Include(t => t.DON_HANG);
            return View(await tHANH_TOAN.ToListAsync());
        }

        // GET: THANHTOAN/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANH_TOAN tHANH_TOAN = await db.THANH_TOAN.FindAsync(id);
            if (tHANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANH_TOAN);
        }

        // GET: THANHTOAN/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH");
            return View();
        }

        // POST: THANHTOAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaTT,PhuongThuc,TrangThai,MaDH")] THANH_TOAN tHANH_TOAN)
        {
            if (ModelState.IsValid)
            {
                db.THANH_TOAN.Add(tHANH_TOAN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH", tHANH_TOAN.MaDH);
            return View(tHANH_TOAN);
        }

        // GET: THANHTOAN/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANH_TOAN tHANH_TOAN = await db.THANH_TOAN.FindAsync(id);
            if (tHANH_TOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH", tHANH_TOAN.MaDH);
            return View(tHANH_TOAN);
        }

        // POST: THANHTOAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaTT,PhuongThuc,TrangThai,MaDH")] THANH_TOAN tHANH_TOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANH_TOAN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH", tHANH_TOAN.MaDH);
            return View(tHANH_TOAN);
        }

        // GET: THANHTOAN/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANH_TOAN tHANH_TOAN = await db.THANH_TOAN.FindAsync(id);
            if (tHANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANH_TOAN);
        }

        // POST: THANHTOAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            THANH_TOAN tHANH_TOAN = await db.THANH_TOAN.FindAsync(id);
            db.THANH_TOAN.Remove(tHANH_TOAN);
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
