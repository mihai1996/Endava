namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GraficAntrenament")]
    public partial class GraficAntrenament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_grafic { get; set; }

        public int Id_antrenament { get; set; }

        [Required]
        [StringLength(50)]
        public string Titlu { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int UserId { get; set; }

        public virtual DomeniuAntrenamente DomeniuAntrenamente { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
