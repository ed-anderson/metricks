using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metricks.Models
{
    public class MetricRequestViewModel
    {
        [Display(Name = "Reagent name")]
        public string ReagentName { get; set; }

        [Display(Name = "Reagent mass")]
        public double ReagentMass { get; set; }

        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Display(Name = "Product mass")]
        public double ProductMass { get; set; }
    }
}