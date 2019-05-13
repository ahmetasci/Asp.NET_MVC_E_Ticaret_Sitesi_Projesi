namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calisanlar")]
    public partial class Calisanlar
    {
        [Key]
        public int CalisanID { get; set; }

        [StringLength(50)]
        public string CalisanAdiSoyadi { get; set; }

        public string Adresi { get; set; }

        public int? TelefonNumarasi { get; set; }

        [StringLength(50)]
        public string MedeniDurumu { get; set; }

        public decimal? Maasi { get; set; }

        public int? MagazaID { get; set; }

        public virtual Magazalar Magazalar { get; set; }
    }
}
