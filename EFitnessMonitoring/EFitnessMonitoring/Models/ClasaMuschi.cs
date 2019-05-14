using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EFitnessMonitoring.Models
{
    [Table("ClasaMuschi")]
    public class ClasaMuschi
    {
        public ClasaMuschi()
        {
            DomeniuSports = new HashSet<DomeniuSport>();
        }

        [Key]
        public int Id_muschi { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume_Muschi { get; set; }

        [ForeignKey("Id_muschi")]
        public virtual ICollection<DomeniuSport> DomeniuSports { get; set; }

    }
}