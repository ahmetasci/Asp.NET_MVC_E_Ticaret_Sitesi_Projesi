namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YayinEvi")]
    public partial class YayinEvi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YayinEvi()
        {
            FavoriKitaplars = new HashSet<FavoriKitaplar>();
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int YayinEviID { get; set; }

        [StringLength(50)]
        public string YayinEviAdi { get; set; }

        public string Adres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriKitaplar> FavoriKitaplars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
