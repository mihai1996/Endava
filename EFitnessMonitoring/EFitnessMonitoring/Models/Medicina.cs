namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicina")]
    public partial class Medicina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicina()
        {
            ExercitiiSpeciales = new HashSet<ExercitiiSpeciale>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_maladie { get; set; }

        public int Id_categorie { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_maladie { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int UserId { get; set; }

        public virtual DomeniuSanatate DomeniuSanatate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExercitiiSpeciale> ExercitiiSpeciales { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
