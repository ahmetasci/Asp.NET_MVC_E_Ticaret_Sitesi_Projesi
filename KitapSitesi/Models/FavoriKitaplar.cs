namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FavoriKitaplar")]
    public partial class FavoriKitaplar
    {
        [Key]
        public int KitapID { get; set; }

        [StringLength(50)]
        public string KitapAdi { get; set; }

        public decimal? SatisFiyati { get; set; }

        public int? YazarID { get; set; }

        public int? KategoriID { get; set; }

        public int? YayinEviID { get; set; }

        public Guid? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BasimYili { get; set; }

        public decimal IndirimOrani { get; set; }

        [Column(TypeName = "image")]
        public byte[] Resim { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        public virtual YayinEvi YayinEvi { get; set; }

        public virtual Yazarlar Yazarlar { get; set; }
    }
}
