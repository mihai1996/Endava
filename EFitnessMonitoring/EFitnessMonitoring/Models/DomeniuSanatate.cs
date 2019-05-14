namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DomeniuSanatate")]
    public partial class DomeniuSanatate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DomeniuSanatate()
        {
            Medicinas = new HashSet<Medicina>();
           
        }

        [Key]
        public int Id_categorie { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume_categorie { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicina> Medicinas { get; set; }

        
    }
}
