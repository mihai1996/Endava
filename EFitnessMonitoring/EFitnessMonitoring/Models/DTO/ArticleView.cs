using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFitnessMonitoring.Models.DTO
{
    public class ArticleView
    {
        //public int Id_exercitiu { get; set; }
        public string Nume_exercitiu { get; set; }
        [AllowHtml]
        public string Descriere { get; set; }
        public string Image { get; set; }
        public int Id_muschi { get; set; }
    }
}