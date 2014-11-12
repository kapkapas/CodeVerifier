using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeVerifier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Деяка інформація, яка допоможе вам у користуванні системою";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Маєте пропозиції, зв'яжіться з нами";

            return View();
        }
    }
}