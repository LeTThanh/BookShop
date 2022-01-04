namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDH",
                c => new
                    {
                        MaDH = c.Long(nullable: false),
                        MaSach = c.Long(nullable: false),
                        TenSP = c.String(nullable: false, maxLength: 100),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaDH, t.MaSach, t.TenSP, t.SoLuong, t.DonGia })
                .ForeignKey("dbo.DonHang", t => t.MaDH, cascadeDelete: true)
                .ForeignKey("dbo.Sach", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaDH)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        MaDH = c.Long(nullable: false, identity: true),
                        MaTK = c.Long(nullable: false),
                        NguoiDat = c.String(nullable: false, maxLength: 100),
                        NguoiNhan = c.String(nullable: false, maxLength: 100),
                        NgayDatHang = c.DateTime(nullable: false),
                        DiaChiNguoiNhan = c.String(nullable: false, storeType: "ntext"),
                        SDTNguoiNhan = c.String(nullable: false, maxLength: 15, unicode: false),
                        TongTien = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDH)
                .ForeignKey("dbo.TaiKhoan", t => t.MaTK, cascadeDelete: true)
                .Index(t => t.MaTK);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        MaTK = c.Long(nullable: false, identity: true),
                        MaNhomTK = c.Long(nullable: false),
                        TenTK = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 20, unicode: false),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        DiaChi = c.String(nullable: false, maxLength: 300),
                        NgaySinh = c.DateTime(),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        SDT = c.String(nullable: false, maxLength: 15, unicode: false),
                        AnhDaiDien = c.String(nullable: false, maxLength: 100, unicode: false),
                        NgayTao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaTK)
                .ForeignKey("dbo.NhomTK", t => t.MaNhomTK, cascadeDelete: true)
                .Index(t => t.MaNhomTK);
            
            CreateTable(
                "dbo.NhomTK",
                c => new
                    {
                        MaNhomTK = c.Long(nullable: false, identity: true),
                        TenNhomTK = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNhomTK);
            
            CreateTable(
                "dbo.Sach",
                c => new
                    {
                        MaSach = c.Long(nullable: false, identity: true),
                        MaTG = c.Long(nullable: false),
                        MaNXB = c.Long(nullable: false),
                        MaDM = c.Long(nullable: false),
                        MaKM = c.Long(nullable: false),
                        TenSach = c.String(nullable: false, maxLength: 100),
                        NgayPhatHanh = c.DateTime(nullable: false),
                        MoTa = c.String(nullable: false, storeType: "ntext"),
                        HinhAnh = c.String(nullable: false, maxLength: 100, unicode: false),
                        GiaBan = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.DanhMucSP", t => t.MaDM, cascadeDelete: true)
                .ForeignKey("dbo.KhuyenMai", t => t.MaKM, cascadeDelete: true)
                .ForeignKey("dbo.NhaXB", t => t.MaNXB, cascadeDelete: true)
                .ForeignKey("dbo.TacGia", t => t.MaTG, cascadeDelete: true)
                .Index(t => t.MaTG)
                .Index(t => t.MaNXB)
                .Index(t => t.MaDM)
                .Index(t => t.MaKM);
            
            CreateTable(
                "dbo.DanhMucSP",
                c => new
                    {
                        MaDM = c.Long(nullable: false, identity: true),
                        TenDM = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MaDM);
            
            CreateTable(
                "dbo.KhuyenMai",
                c => new
                    {
                        MaKM = c.Long(nullable: false, identity: true),
                        TenKM = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(nullable: false, storeType: "ntext"),
                        ChietKhau = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKM);
            
            CreateTable(
                "dbo.NhaXB",
                c => new
                    {
                        MaNXB = c.Long(nullable: false, identity: true),
                        TenNXB = c.String(nullable: false, maxLength: 300),
                        MoTa = c.String(nullable: false, storeType: "ntext"),
                        HinhAnh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNXB);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        MaTG = c.Long(nullable: false, identity: true),
                        TenTG = c.String(nullable: false, maxLength: 150),
                        MoTa = c.String(nullable: false, storeType: "ntext"),
                        HinhAnh = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaTG);
            
            CreateTable(
                "dbo.DanhGia",
                c => new
                    {
                        MaDanhGia = c.Long(nullable: false, identity: true),
                        MaTK = c.Long(nullable: false),
                        TenTK = c.String(nullable: false, maxLength: 50, unicode: false),
                        NoiDung = c.String(nullable: false, storeType: "ntext"),
                        NgayDanhGia = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MaDanhGia)
                .ForeignKey("dbo.TaiKhoan", t => t.MaTK, cascadeDelete: true)
                .Index(t => t.MaTK);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        MaSlide = c.Int(nullable: false, identity: true),
                        TenSlide = c.String(nullable: false, maxLength: 50, unicode: false),
                        HinhAnh = c.String(nullable: false, maxLength: 50, unicode: false),
                        Url = c.String(maxLength: 50, unicode: false),
                        TitleID = c.String(maxLength: 20),
                        TTHienThi = c.Int(),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaSlide);
            
            CreateTable(
                "dbo.TinTuc",
                c => new
                    {
                        MaTinTuc = c.Long(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 500),
                        NoiDung = c.String(nullable: false, storeType: "ntext"),
                        NgayTao = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MaTinTuc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DanhGia", "MaTK", "dbo.TaiKhoan");
            DropForeignKey("dbo.Sach", "MaTG", "dbo.TacGia");
            DropForeignKey("dbo.Sach", "MaNXB", "dbo.NhaXB");
            DropForeignKey("dbo.Sach", "MaKM", "dbo.KhuyenMai");
            DropForeignKey("dbo.Sach", "MaDM", "dbo.DanhMucSP");
            DropForeignKey("dbo.ChiTietDH", "MaSach", "dbo.Sach");
            DropForeignKey("dbo.TaiKhoan", "MaNhomTK", "dbo.NhomTK");
            DropForeignKey("dbo.DonHang", "MaTK", "dbo.TaiKhoan");
            DropForeignKey("dbo.ChiTietDH", "MaDH", "dbo.DonHang");
            DropIndex("dbo.DanhGia", new[] { "MaTK" });
            DropIndex("dbo.Sach", new[] { "MaKM" });
            DropIndex("dbo.Sach", new[] { "MaDM" });
            DropIndex("dbo.Sach", new[] { "MaNXB" });
            DropIndex("dbo.Sach", new[] { "MaTG" });
            DropIndex("dbo.TaiKhoan", new[] { "MaNhomTK" });
            DropIndex("dbo.DonHang", new[] { "MaTK" });
            DropIndex("dbo.ChiTietDH", new[] { "MaSach" });
            DropIndex("dbo.ChiTietDH", new[] { "MaDH" });
            DropTable("dbo.TinTuc");
            DropTable("dbo.Slide");
            DropTable("dbo.DanhGia");
            DropTable("dbo.TacGia");
            DropTable("dbo.NhaXB");
            DropTable("dbo.KhuyenMai");
            DropTable("dbo.DanhMucSP");
            DropTable("dbo.Sach");
            DropTable("dbo.NhomTK");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.DonHang");
            DropTable("dbo.ChiTietDH");
        }
    }
}
