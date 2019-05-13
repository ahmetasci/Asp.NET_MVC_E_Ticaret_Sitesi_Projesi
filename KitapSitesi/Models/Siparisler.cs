namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Siparisler")]
    public partial class Siparisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparisler()
        {
            SiparisDetays = new HashSet<SiparisDetay>();
        }

        [Key]
        public int SiparisID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SiparisTarihi { get; set; }

        public decimal? ToplamTutar { get; set; }

        public int? KargoID { get; set; }

        public Guid? UserId { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual Kargo Kargo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetays { get; set; }
    }
}
