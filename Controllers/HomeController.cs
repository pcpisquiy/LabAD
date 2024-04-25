using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAD_Katas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Settings = Properties.Settings.Default;
            string CadenaConexion = FuncionesAuxiliares.Instance.DesEncripta(Settings.CadenaConexion, "DMP_2024");
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
    }
}