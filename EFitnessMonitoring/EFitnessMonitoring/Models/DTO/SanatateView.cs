using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFitnessMonitoring.Models.DTO
{
    public class SanatateView
    {
        public string Nume_maladie { get; set; }

        public string Image { get; set; }
        [AllowHtml]
        public string Descriere { get; set; }

        public int Id_categorie { get; set; }
    }
}