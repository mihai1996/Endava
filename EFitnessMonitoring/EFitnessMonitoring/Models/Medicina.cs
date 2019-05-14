namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Medicina")]
    public partial class Medicina
    {
        
        [Key]
        public int Id_maladie { get; set; }

        public int Id_categorie { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume_maladie { get; set; }

        [Required]
        [AllowHtml]
        public string Descriere { get; set; }

        public string Image { get; set; }

        public int UserId { get; set; }

        public virtual DomeniuSanatate DomeniuSanatate { get; set; }


        public virtual ApplicationUser User { get; set; }
    }
}
