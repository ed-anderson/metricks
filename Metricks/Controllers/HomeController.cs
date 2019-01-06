using MetricCalculations;
using Metricks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metricks.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Calculate(MetricRequestViewModel model)
        {
            var calculations = new Calculations();
            var result = calculations.ProcessMassIntensity(new double[] { model.ReagentMass }, model.ProductMass);
            ViewBag.Result = $"{result}";
            return View("Index");
        }
    }
}