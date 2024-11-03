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
    public class DANH_GIAController : Controller
    {
        private DKVEntities db = new DKVEntities();

        // GET: DANH_GIA
        public ActionResult DkvIndex()
        {
            var dANH_GIA = db.DANH_GIA.Include(d => d.HINH_NEN).Include(d => d.KHACH_HANG);
            return View(dANH_GIA.ToList());
        }

        // GET: DANH_GIA/Details/5
        public ActionResult DkvDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA);
        }

        // GET: DANH_GIA/Create
        public ActionResult DkvCreate()
        {
            ViewBag.Ma_hinh_nen = new SelectList(db.HINH_NEN, "Ma_hinh_nen", "Ten_hinh_nen");
            ViewBag.Ma_thanh_vien = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            return View();
        }

        // POST: DANH_GIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvCreate([Bind(Include = "Ma_danh_gia,Ma_thanh_vien,Ma_hinh_nen,So_sao_danh_gia")] DANH_GIA dANH_GIA)
        {
            if (ModelState.IsValid)
            {
                db.DANH_GIA.Add(dANH_GIA);
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }

            ViewBag.Ma_hinh_nen = new SelectList(db.HINH_NEN, "Ma_hinh_nen", "Ten_hinh_nen", dANH_GIA.Ma_hinh_nen);
            ViewBag.Ma_thanh_vien = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dANH_GIA.Ma_thanh_vien);
            return View(dANH_GIA);
        }

        // GET: DANH_GIA/Edit/5
        public ActionResult DkvEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_hinh_nen = new SelectList(db.HINH_NEN, "Ma_hinh_nen", "Ten_hinh_nen", dANH_GIA.Ma_hinh_nen);
            ViewBag.Ma_thanh_vien = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dANH_GIA.Ma_thanh_vien);
            return View(dANH_GIA);
        }

        // POST: DANH_GIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvEdit([Bind(Include = "Ma_danh_gia,Ma_thanh_vien,Ma_hinh_nen,So_sao_danh_gia")] DANH_GIA dANH_GIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_GIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }
            ViewBag.Ma_hinh_nen = new SelectList(db.HINH_NEN, "Ma_hinh_nen", "Ten_hinh_nen", dANH_GIA.Ma_hinh_nen);
            ViewBag.Ma_thanh_vien = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dANH_GIA.Ma_thanh_vien);
            return View(dANH_GIA);
        }

        // GET: DANH_GIA/Delete/5
        public ActionResult DkvDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA);
        }

        // POST: DANH_GIA/Delete/5
        [HttpPost, ActionName("DkvDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DkvDeleteConfirmed(int id)
        {
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            db.DANH_GIA.Remove(dANH_GIA);
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
