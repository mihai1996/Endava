namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DomeniuAntrenamente")]
    public partial class DomeniuAntrenamente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DomeniuAntrenamente()
        {
            GraficAntrenaments = new HashSet<GraficAntrenament>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_antrenament { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_antrenament { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GraficAntrenament> GraficAntrenaments { get; set; }
    }
}
