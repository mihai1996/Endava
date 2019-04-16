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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_produs { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_produs { get; set; }

        [Required]
        [StringLength(50)]
        public string Descriere { get; set; }

        [Required]
        public string Linq { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
