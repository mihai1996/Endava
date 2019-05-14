using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFitnessMonitoring.Models
{
    [Table("ProduseCategory")]
    public class ProduseCategory
    {
        public ProduseCategory()
        {
            Produses = new HashSet<Produse>();
        }

        [Key]
        public int Id_category { get; set; }

        [StringLength(50)]
        public string NumeCategorie { get; set; }

        [ForeignKey("Id_category")]
        public virtual ICollection<Produse> Produses { get; set; }
    }
}