using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metricks.Models
{
    public class MetricRequestViewModel
    {
        [Display(Name = "Reagents")]
        public List<Reagent> Reagents { get; set; }

        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Display(Name = "Product mass")]
        public double ProductMass { get; set; }

        public MetricRequestViewModel()
        {
            Reagents = new List<Reagent>();
            Reagents.Add(new Reagent());
        }
    }
}