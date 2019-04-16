namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warkout")]
    public partial class Warkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_exercitiu { get; set; }

        public int id_muschi { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_exercitiu { get; set; }

        public int UserId { get; set; }

        public virtual DomeniuSport DomeniuSport { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
