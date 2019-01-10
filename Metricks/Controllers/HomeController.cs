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
        private ICalculations _calculations;

        public HomeController()
        {
            _calculations = new Calculations();
        }

        public HomeController(ICalculations calculations)
        {
            _calculations = calculations;
        }

        public ActionResult Index()
        {
            var initialData = new MetricRequestViewModel();

            return View(initialData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Here you can find references to papers describing each metric used on this website.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculate(MetricRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var resultProcessMassIntensity = _calculations.ProcessMassIntensity(model.Reagents.Select(x => x.Mass).ToArray(), model.ProductMass);
            ViewBag.ResultProcessMassIntensity = $"{resultProcessMassIntensity}";

            var resultEFactor = _calculations.EFactor(model.Reagents.Select(x => x.Mass).ToArray(), model.ProductMass);
            ViewBag.ResultEFactor = $"{resultEFactor}";

            var resultReactionMassEfficiency = _calculations.ReactionMassEfficiency(model.Reagents.Where(x => x.IsReactant == true).Select(y => y.Mass).ToArray(), model.ProductMass);
            ViewBag.ResultReactionMassEfficiency = $"{resultReactionMassEfficiency} %";

            var resultEffectiveMassYield = _calculations.EffectiveMassYield(model.Reagents.Where(x => x.IsBenign == false).Select(y => y.Mass).ToArray(), model.ProductMass);
            ViewBag.ResultEffectiveMassYield = $"{resultEffectiveMassYield} %";

            return View("Index", model);
        }

        public ActionResult AddReagent(MetricRequestViewModel model)
        {
            model.Reagents.Add(new Reagent());
            return View("Index", model);
        }
    }
}