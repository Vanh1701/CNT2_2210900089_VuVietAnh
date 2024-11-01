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
    public class CHITIETDONHANGController : Controller
    {
        private Web_ban_banhVEntities db = new Web_ban_banhVEntities();

        // GET: CHITIETDONHANG
        public async Task<ActionResult> Index()
        {
            var cHI_TIET_DON_HANG = db.CHI_TIET_DON_HANG.Include(c => c.DON_HANG).Include(c => c.SAN_PHAM);
            return View(await cHI_TIET_DON_HANG.ToListAsync());
        }

        // GET: CHITIETDONHANG/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = await db.CHI_TIET_DON_HANG.FindAsync(id);
            if (cHI_TIET_DON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_DON_HANG);
        }

        // GET: CHITIETDONHANG/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH");
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Tenp");
            return View();
        }

        // POST: CHITIETDONHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaDH,MaSP,SoLuong")] CHI_TIET_DON_HANG cHI_TIET_DON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.CHI_TIET_DON_HANG.Add(cHI_TIET_DON_HANG);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH", cHI_TIET_DON_HANG.MaDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Tenp", cHI_TIET_DON_HANG.MaSP);
            return View(cHI_TIET_DON_HANG);
        }

        // GET: CHITIETDONHANG/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = await db.CHI_TIET_DON_HANG.FindAsync(id);
            if (cHI_TIET_DON_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH", cHI_TIET_DON_HANG.MaDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Tenp", cHI_TIET_DON_HANG.MaSP);
            return View(cHI_TIET_DON_HANG);
        }

        // POST: CHITIETDONHANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaDH,MaSP,SoLuong")] CHI_TIET_DON_HANG cHI_TIET_DON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHI_TIET_DON_HANG).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DON_HANG, "MaDH", "MaDH", cHI_TIET_DON_HANG.MaDH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Tenp", cHI_TIET_DON_HANG.MaSP);
            return View(cHI_TIET_DON_HANG);
        }

        // GET: CHITIETDONHANG/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = await db.CHI_TIET_DON_HANG.FindAsync(id);
            if (cHI_TIET_DON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_DON_HANG);
        }

        // POST: CHITIETDONHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CHI_TIET_DON_HANG cHI_TIET_DON_HANG = await db.CHI_TIET_DON_HANG.FindAsync(id);
            db.CHI_TIET_DON_HANG.Remove(cHI_TIET_DON_HANG);
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
