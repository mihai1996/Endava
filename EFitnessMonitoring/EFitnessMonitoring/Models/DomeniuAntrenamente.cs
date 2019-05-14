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
        public int Id_antrenament { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume_antrenament { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GraficAntrenament> GraficAntrenaments { get; set; }
    }
}
