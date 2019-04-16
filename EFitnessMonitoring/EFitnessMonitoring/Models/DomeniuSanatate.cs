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
            Nutrities = new HashSet<Nutritie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_categorie { get; set; }

        [Required]
        [StringLength(30)]
        public string Nume_categorie { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicina> Medicinas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nutritie> Nutrities { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
