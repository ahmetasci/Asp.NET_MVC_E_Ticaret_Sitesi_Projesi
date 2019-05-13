namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kargo")]
    public partial class Kargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kargo()
        {
            Siparislers = new HashSet<Siparisler>();
        }

        public int KargoID { get; set; }

        [StringLength(50)]
        public string SirketAdi { get; set; }

        public int? TeslimatSuresi { get; set; }

        public decimal? KargoFiyati { get; set; }

        public string Adres { get; set; }

        public int? Telefon { get; set; }

        public string WebSite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparisler> Siparislers { get; set; }
    }
}
