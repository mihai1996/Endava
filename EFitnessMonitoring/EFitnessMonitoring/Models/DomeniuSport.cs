namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("DomeniuSport")]
    public partial class DomeniuSport
    {
        

        [Key]
        public int Id_exercitiu { get; set; }
        
        public int Id_muschi { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume_exercitiu { get; set; }

        
        [AllowHtml]
        public string Descriere { get; set; }

        [Required]
        public string Image { get; set; }

        public int UserId { get; set; }

        
        public virtual ClasaMuschi ClasaMuschi { get; set; }

        public virtual ApplicationUser User { get; set; }

        
    }
}
