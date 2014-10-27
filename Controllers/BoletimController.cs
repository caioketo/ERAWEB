using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERAWeb.Controllers
{
    public class BoletimController : Controller
    {
        // GET: Boletim
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Boletim()
        {
            return View();
        }
    }
}