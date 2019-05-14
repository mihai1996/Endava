using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFitnessMonitoring.Models.DTO
{
    public class ProduseView
    {
        public string Nume_produs { get; set; }

        public string Image { get; set; }

        public string Linq { get; set; }

        public int Id_category { get; set; }
    }
}