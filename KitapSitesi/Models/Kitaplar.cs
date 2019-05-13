namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kitaplar")]
    public partial class Kitaplar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kitaplar()
        {
            SiparisDetays = new HashSet<SiparisDetay>();
        }

        [Key]
        public int KitapID { get; set; }

        [StringLength(50)]
        public string KitapAdi { get; set; }

        public int? KategoriID { get; set; }

        public decimal? SatisFiyati { get; set; }

        public decimal? AlisFiyati { get; set; }

        public int? YazarID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BasimYili { get; set; }

        public string Aciklama { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EklenmeTarihi { get; set; }

        [Column(TypeName = "image")]
        public byte[] Resim { get; set; }

        public decimal IndirimOrani { get; set; }

        public int? YayinEviID { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        public virtual YayinEvi YayinEvi { get; set; }

        public virtual Yazarlar Yazarlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetays { get; set; }
    }
}
