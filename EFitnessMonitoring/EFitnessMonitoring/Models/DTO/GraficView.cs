using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFitnessMonitoring.Models.DTO
{
    public class GraficView
    {
        public string Titlu { get; set; }
        [AllowHtml]
        public string Descriere { get; set; }
        public string Image { get; set; }
        public int Id_antrenament { get; set; }
    }
}