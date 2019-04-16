namespace EFitnessMonitoring.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubiecteForum")]
    public partial class SubiecteForum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubiecteForum()
        {
            Users = new HashSet<ApplicationUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_subiect { get; set; }

        [Required]
        [StringLength(50)]
        public string Subiect { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Comntariu { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
