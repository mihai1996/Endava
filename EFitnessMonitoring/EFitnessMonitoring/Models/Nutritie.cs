namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nutritie")]
    public partial class Nutritie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_aliment { get; set; }

        public int Id_categorie { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_aliment { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int UserId { get; set; }

        public virtual DomeniuSanatate DomeniuSanatate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
