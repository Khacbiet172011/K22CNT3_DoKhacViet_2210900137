using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_DoKhacViet_2210900137.Models;

namespace K22CNT3_DoKhacViet_2210900137.Controllers
{
    public class HINH_NENController : Controller
    {
        private DKVEntities db = new DKVEntities();

        // GET: HINH_NEN
        public ActionResult DkvIndex()
        {
            var hINH_NEN = db.HINH_NEN.Include(h => h.QUAN_TRI);
            return View(hINH_NEN.ToList());
        }

        // GET: HINH_NEN/Details/5
        public ActionResult DkvDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINH_NEN hINH_NEN = db.HINH_NEN.Find(id);
            if (hINH_NEN == null)
            {
                return HttpNotFound();
            }
            return View(hINH_NEN);
        }

        // GET: HINH_NEN/Create
        public ActionResult DkvCreate()
        {
            ViewBag.Ma_nguoi_tai_len = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau");
            return View();
        }

        // POST: HINH_NEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvCreate([Bind(Include = "Ma_hinh_nen,Ten_hinh_nen,Do_phan_giai_hinh_nen,Kich_thuoc_file,Ma_nguoi_tai_len")] HINH_NEN hINH_NEN)
        {
            if (ModelState.IsValid)
            {
                db.HINH_NEN.Add(hINH_NEN);
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }

            ViewBag.Ma_nguoi_tai_len = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau", hINH_NEN.Ma_nguoi_tai_len);
            return View(hINH_NEN);
        }

        // GET: HINH_NEN/Edit/5
        public ActionResult DkvEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINH_NEN hINH_NEN = db.HINH_NEN.Find(id);
            if (hINH_NEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_nguoi_tai_len = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau", hINH_NEN.Ma_nguoi_tai_len);
            return View(hINH_NEN);
        }

        // POST: HINH_NEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvEdit([Bind(Include = "Ma_hinh_nen,Ten_hinh_nen,Do_phan_giai_hinh_nen,Kich_thuoc_file,Ma_nguoi_tai_len")] HINH_NEN hINH_NEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hINH_NEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }
            ViewBag.Ma_nguoi_tai_len = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau", hINH_NEN.Ma_nguoi_tai_len);
            return View(hINH_NEN);
        }

        // GET: HINH_NEN/Delete/5
        public ActionResult DkvDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINH_NEN hINH_NEN = db.HINH_NEN.Find(id);
            if (hINH_NEN == null)
            {
                return HttpNotFound();
            }
            return View(hINH_NEN);
        }

        // POST: HINH_NEN/Delete/5
        [HttpPost, ActionName("DkvDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DkvDeleteConfirmed(int id)
        {
            HINH_NEN hINH_NEN = db.HINH_NEN.Find(id);
            db.HINH_NEN.Remove(hINH_NEN);
            db.SaveChanges();
            return RedirectToAction("DkvIndex");
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
