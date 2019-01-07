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
            var initialData = new MetricRequestViewModel();

            return View(initialData);
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
            var result = calculations.ProcessMassIntensity(model.Reagents.Select(x => x.Mass).ToArray(), model.ProductMass);
            ViewBag.Result = $"{result}";
            return View("Index", model);
        }

        public ActionResult AddReagent(MetricRequestViewModel model)
        {
            model.Reagents.Add(new Reagent());
            return View("Index", model);
        }

        public ActionResult DeleteReagent(MetricRequestViewModel model)
        {
            model.Reagents.RemoveAt(model.Reagents.Count);
            return View("Index", model);
        }
    }
}