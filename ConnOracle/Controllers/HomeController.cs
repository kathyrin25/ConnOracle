using ConnOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnOracle.Controllers
{
    public class HomeController : Controller
    {
        private OracleDao dao = new OracleDao();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DataThuDao()
        {
            return View(dao.GetInv("TTB1012061"));

        }
    }
}