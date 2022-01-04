using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookShopAPI.Models
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<NhaXB> NhaXBs { get; set; }
        public virtual DbSet<NhomTK> NhomTKs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<ChiTietDH> ChiTietDHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhGia>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<DanhGia>()
                .HasMany(e => e.TaiKhoans)
                .WithOptional(e => e.DanhGia)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DanhMucSP>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.DanhMucSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDTNguoiNhan)
                .IsUnicode(false);

            modelBuilder.Entity<KhuyenMai>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.KhuyenMai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaXB>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXB>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.NhaXB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomTK>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.NhomTK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.TenSlide)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.TitleID)
                .IsUnicode(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.TacGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);
        }
    }
}
