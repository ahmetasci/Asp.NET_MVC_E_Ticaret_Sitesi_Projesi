namespace KitapSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiparisDetay")]
    public partial class SiparisDetay
    {
        public int SiparisDetayID { get; set; }

        public decimal? BirimFiyat { get; set; }

        public int? Miktar { get; set; }

        public int? KitapID { get; set; }

        public bool? SatildiMi { get; set; }

        public int? SiparisID { get; set; }

        public virtual Kitaplar Kitaplar { get; set; }

        public virtual Siparisler Siparisler { get; set; }
    }
}
