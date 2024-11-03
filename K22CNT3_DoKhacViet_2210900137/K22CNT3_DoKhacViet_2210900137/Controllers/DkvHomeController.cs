using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT3_DoKhacViet_2210900137.Controllers
{
    public class DkvHomeController : Controller
    {
        public ActionResult DkvIndex()
        {
            return View();
        }

        public ActionResult DkvAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DkvContact()
        {
            ViewBag.msv = "2210900137";
            ViewBag.fullname = "Do Khac Viet";

            return View();
        }
    }
}