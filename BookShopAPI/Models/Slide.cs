namespace BookShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int MaSlide { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSlide { get; set; }

        [Required]
        [StringLength(50)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string Url { get; set; }

        [StringLength(20)]
        public string TitleID { get; set; }

        public int? TTHienThi { get; set; }

        public int? TrangThai { get; set; }
    }
}
