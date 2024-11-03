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
    public class QUAN_TRIController : Controller
    {
        private DKVEntities db = new DKVEntities();

        // GET: QUAN_TRI
        public ActionResult DkvIndex()
        {
            return View(db.QUAN_TRI.ToList());
        }

        // GET: QUAN_TRI/Details/5
        public ActionResult DkvDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Create
        public ActionResult DkvCreate()
        {
            return View();
        }

        // POST: QUAN_TRI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvCreate([Bind(Include = "Tai_khoan,Mat_khau,Trang_thai")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI.Add(qUAN_TRI);
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }

            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Edit/5
        public ActionResult DkvEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DkvEdit([Bind(Include = "Tai_khoan,Mat_khau,Trang_thai")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DkvIndex");
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Delete/5
        public ActionResult DkvDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/Delete/5
        [HttpPost, ActionName("DkvDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DkvDeleteConfirmed(string id)
        {
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            db.QUAN_TRI.Remove(qUAN_TRI);
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
