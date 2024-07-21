using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.DatabaseContext
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }
        public DbSet<User>Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<HocSinh> HocSinhs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<MonHoc> MonHocs{ get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<BaiGiang> BaiGiangs { get; set;}
        public DbSet<DuyetBaiGiang> DuyetBaiGiangs { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<CauHoi> CauHois { get; set; }
        public DbSet<TraLoi> TraLois { get; set; }
        public DbSet<DeThi> DeThis { get; set; }
        public DbSet<NganHangCauHoiTN> NganHangCauHois { get; set; }
        public DbSet<CauHoiTN> CauHoiTN { get; set; }
        public DbSet<ThongBaoAdmin> ThongBaoAdmins { get; set; }
        public DbSet<TaiNguyen> TaiNguyens { get; set; }
        // public DbSet<DeThiTracNghiem> DeThiTracNghiems { get; set; }
        // public DbSet<TuLuan> TuLuans { get; set; }
        //public DbSet<CauHoiTracNghiem> TracNghiems { get; set; }
        //public DbSet<MonHoc_HS> MonHoc_HSs { get; set; }

    }
}
