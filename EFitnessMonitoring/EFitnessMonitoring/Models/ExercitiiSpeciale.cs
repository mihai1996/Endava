namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExercitiiSpeciale")]
    public partial class ExercitiiSpeciale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_exSpecial { get; set; }

        public int Id_maladie { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_exercitiu { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int UserId { get; set; }

        public virtual Medicina Medicina { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
