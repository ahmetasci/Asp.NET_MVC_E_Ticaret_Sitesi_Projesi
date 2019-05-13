namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilceler")]
    public partial class Ilceler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilceler()
        {
            Magazalars = new HashSet<Magazalar>();
        }

        [Key]
        public int IlceID { get; set; }

        [StringLength(50)]
        public string IlceAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Magazalar> Magazalars { get; set; }
    }
}
