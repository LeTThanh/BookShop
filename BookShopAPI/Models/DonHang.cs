namespace BookShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDHs = new HashSet<ChiTietDH>();
        }

        [Key]
        public long MaDH { get; set; }

        public long MaTK { get; set; }

        [Required]
        [StringLength(100)]
        public string NguoiDat { get; set; }

        [Required]
        [StringLength(100)]
        public string NguoiNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDatHang { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string DiaChiNguoiNhan { get; set; }

        [Required]
        [StringLength(15)]
        public string SDTNguoiNhan { get; set; }

        public int TongTien { get; set; }

        public int TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
