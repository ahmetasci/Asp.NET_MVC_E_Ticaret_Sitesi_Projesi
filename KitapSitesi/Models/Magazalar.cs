namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Magazalar")]
    public partial class Magazalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Magazalar()
        {
            Calisanlars = new HashSet<Calisanlar>();
        }

        [Key]
        public int MagazaID { get; set; }

        [StringLength(50)]
        public string MagazaAdi { get; set; }

        public int? IlceID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calisanlar> Calisanlars { get; set; }

        public virtual Ilceler Ilceler { get; set; }
    }
}
