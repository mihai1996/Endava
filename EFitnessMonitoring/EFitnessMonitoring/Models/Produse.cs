namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produse")]
    public partial class Produse
    {
        [Key]
        public int Id_produs { get; set; }

        public int Id_category { get; set; }

        [Required]
        [StringLength(120)]
        public string Nume_produs { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Linq { get; set; }

        public int UserId { get; set; }

        public virtual ProduseCategory ProduseCategory { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
