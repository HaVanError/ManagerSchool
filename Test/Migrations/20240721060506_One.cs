using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHoiTN",
                columns: table => new
                {
                    maCauHoiTN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieuDeCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    B = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dapAnChinhXac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNganHangCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoiTN", x => x.maCauHoiTN);
                });

            migrationBuilder.CreateTable(
                name: "DeThi&KiemTra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiThi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenGiaoVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGiangThi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi&KiemTra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    maKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.maKhoa);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    maLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenLop = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.maLop);
                });

            migrationBuilder.CreateTable(
                name: "NganHangCauHoi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doKho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nguoiSoHuu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    suaDoiLanCuoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganHangCauHoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiNguyen",
                columns: table => new
                {
                    IdTaiNguyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTaiNguyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NgayUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maChuDe = table.Column<int>(type: "int", nullable: false),
                    hinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maBaiGiang = table.Column<int>(type: "int", nullable: false),
                    UpdateByMember = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiNguyen", x => x.IdTaiNguyen);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    maThongBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieuDeThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNguoiThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.maThongBao);
                });

            migrationBuilder.CreateTable(
                name: "ThongBaoAdmin",
                columns: table => new
                {
                    maTBaoAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaoAdmin", x => x.maTBaoAdmin);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gioTinh = table.Column<bool>(type: "bit", nullable: false),
                    hinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maQuyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_Quyen_maQuyen",
                        column: x => x.maQuyen,
                        principalTable: "Quyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoVien",
                columns: table => new
                {
                    maGiaoVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maTK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoVien", x => x.maGiaoVien);
                    table.ForeignKey(
                        name: "FK_GiaoVien_Khoa_maKhoa",
                        column: x => x.maKhoa,
                        principalTable: "Khoa",
                        principalColumn: "maKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaoVien_TaiKhoan_maTK",
                        column: x => x.maTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocSinh",
                columns: table => new
                {
                    maHocSinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maTK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinh", x => x.maHocSinh);
                    table.ForeignKey(
                        name: "FK_HocSinh_Khoa_maKhoa",
                        column: x => x.maKhoa,
                        principalTable: "Khoa",
                        principalColumn: "maKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocSinh_Lop_maLop",
                        column: x => x.maLop,
                        principalTable: "Lop",
                        principalColumn: "maLop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocSinh_TaiKhoan_maTK",
                        column: x => x.maTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuanTriAdmin",
                columns: table => new
                {
                    IDAdmin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maTK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanTriAdmin", x => x.IDAdmin);
                    table.ForeignKey(
                        name: "FK_QuanTriAdmin_TaiKhoan_maTK",
                        column: x => x.maTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    idJwt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianHetHan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_TaiKhoan_idUser",
                        column: x => x.idUser,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    maMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maGiaoVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    maLop = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.maMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_GiaoVien_maGiaoVien",
                        column: x => x.maGiaoVien,
                        principalTable: "GiaoVien",
                        principalColumn: "maGiaoVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_Lop_maLop",
                        column: x => x.maLop,
                        principalTable: "Lop",
                        principalColumn: "maLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiGiang",
                columns: table => new
                {
                    maBaiGiang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenBaiGiang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kichThuc = table.Column<int>(type: "int", nullable: false),
                    NgayUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UpdateByMember = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maChuDe = table.Column<int>(type: "int", nullable: false),
                    hinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiGiang", x => x.maBaiGiang);
                    table.ForeignKey(
                        name: "FK_BaiGiang_MonHoc_maMonHoc",
                        column: x => x.maMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "maMonHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    maCauHoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noiDungCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thich = table.Column<bool>(type: "bit", nullable: false),
                    Mon = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.maCauHoi);
                    table.ForeignKey(
                        name: "FK_CauHoi_MonHoc_Mon",
                        column: x => x.Mon,
                        principalTable: "MonHoc",
                        principalColumn: "maMonHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuDe_MonHoc_maMonHoc",
                        column: x => x.maMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "maMonHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuyetBai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maBaiGiang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyetBai", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DuyetBai_BaiGiang_maBaiGiang",
                        column: x => x.maBaiGiang,
                        principalTable: "BaiGiang",
                        principalColumn: "maBaiGiang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauTraLoi",
                columns: table => new
                {
                    maTl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNguoiTraLoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maCauHoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauTraLoi", x => x.maTl);
                    table.ForeignKey(
                        name: "FK_CauTraLoi_CauHoi_maCauHoi",
                        column: x => x.maCauHoi,
                        principalTable: "CauHoi",
                        principalColumn: "maCauHoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_maMonHoc",
                table: "BaiGiang",
                column: "maMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_Mon",
                table: "CauHoi",
                column: "Mon");

            migrationBuilder.CreateIndex(
                name: "IX_CauTraLoi_maCauHoi",
                table: "CauTraLoi",
                column: "maCauHoi");

            migrationBuilder.CreateIndex(
                name: "IX_ChuDe_maMonHoc",
                table: "ChuDe",
                column: "maMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DuyetBai_maBaiGiang",
                table: "DuyetBai",
                column: "maBaiGiang");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoVien_maKhoa",
                table: "GiaoVien",
                column: "maKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoVien_maTK",
                table: "GiaoVien",
                column: "maTK");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_maKhoa",
                table: "HocSinh",
                column: "maKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_maLop",
                table: "HocSinh",
                column: "maLop");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_maTK",
                table: "HocSinh",
                column: "maTK");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_maGiaoVien",
                table: "MonHoc",
                column: "maGiaoVien");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_maLop",
                table: "MonHoc",
                column: "maLop");

            migrationBuilder.CreateIndex(
                name: "IX_QuanTriAdmin_maTK",
                table: "QuanTriAdmin",
                column: "maTK");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_idUser",
                table: "RefreshToken",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_maQuyen",
                table: "TaiKhoan",
                column: "maQuyen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CauHoiTN");

            migrationBuilder.DropTable(
                name: "CauTraLoi");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropTable(
                name: "DeThi&KiemTra");

            migrationBuilder.DropTable(
                name: "DuyetBai");

            migrationBuilder.DropTable(
                name: "HocSinh");

            migrationBuilder.DropTable(
                name: "NganHangCauHoi");

            migrationBuilder.DropTable(
                name: "QuanTriAdmin");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "TaiNguyen");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThongBaoAdmin");

            migrationBuilder.DropTable(
                name: "CauHoi");

            migrationBuilder.DropTable(
                name: "BaiGiang");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "GiaoVien");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "Quyen");
        }
    }
}
