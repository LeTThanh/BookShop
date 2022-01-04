namespace BookShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDHs = new HashSet<ChiTietDH>();
        }

        [Key]
        public long MaSach { get; set; }

        public long MaTG { get; set; }

        public long MaNXB { get; set; }

        public long MaDM { get; set; }

        public long MaKM { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayPhatHanh { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string MoTa { get; set; }

        [Required]
        [StringLength(100)]
        public string HinhAnh { get; set; }

        public int GiaBan { get; set; }

        public int SoLuong { get; set; }

        public int TrangThai { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual NhaXB NhaXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
