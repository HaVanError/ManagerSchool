using PdfSharpCore.Pdf;
using PdfSharpCore;
using System.IO;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Microsoft.EntityFrameworkCore;

namespace Test.Response
{
    public class DeThi_KiemTraResponse : IDeThi_KiemTra
    {
        private readonly Database db;
        public static int pagesize { get; set; } = 5;
        public DeThi_KiemTraResponse(Database db)
        {
            this.db = db;
        }

        public string DuyetBai(int id,string trangThai)
        {
                var check = db.DeThis.SingleOrDefault(x => x.Id.Equals(id));
                if (check != null)
                {
                    var thongBao = new ThongBao();
                    thongBao.tieuDeThongBao = check.TenBaiThi + "Da Duoc Admin Duyet ";
                    thongBao.TenNguoiThongBao = check.TenGiaoVien;
                    check.TinhTrang = trangThai;
                    db.ThongBaos.Add(thongBao);
                    
                    db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                return "Thanh Cong";
                }
            return "Loi";
              
        }
        public List<DeThiViewModel> getAll(string name, int page = 1)
        {
            var check = db.DeThis.AsQueryable();
            check = check.Skip((page-1)*pagesize).Take(pagesize);
            var kq = check.Select(x => new DeThiViewModel
            {
                tenDeThi =x.TenBaiThi,
                hinhThuc = x.hinhThuc,
                Mon = x.maMonHoc,
                ngay = x.ThoiGiangThi,
                trangThai = x.TinhTrang,
                TenGV = x.TenGiaoVien


            }).Where(x=>x.TenGV == name).ToList();
            return kq.ToList();
        }

        public DeThi themDeThiTracNghiem(string TenBaiThi, string mon, string hinhThuc, List<CauHoiTracNghiem> s, string gio, string phut)
        {
         

            var document = new PdfDocument();
            string htmlcontent = "<div style='width:100%; text-align:Left'>";

            //htmlcontent += "<h2  style='width:100%; text-align:Center'> CTY ASTA  </h2>";

            htmlcontent += "<br>";

            var tg = "";
            if (gio == "0")
            {
                tg = phut + "phút";

            }
            else
            {
                tg = gio + "giờ" + phut + "phút";
            }
            var monHoc = db.MonHocs.SingleOrDefault(x => x.maMonHoc.Equals(mon));
          
            var checkgv = db.GiaoViens.SingleOrDefault(x => x.maGiaoVien == monHoc.maGiaoVien);
            if (monHoc != null)
            {
                htmlcontent += "<h2> Tên Bài:" + TenBaiThi + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + " Môn:" + monHoc.tenMonHoc + "&nbsp;" + "&nbsp;" + "Thời Gian:" + tg + "</h2>";
            }

            htmlcontent += "<br>";
            if (checkgv != null)
            {
                htmlcontent += "<h2>Giáo Viên :" + checkgv.user.Name + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "Hình Thức:" + hinhThuc + "</h2>";
            }

            htmlcontent += "<br>";
            htmlcontent += "<br>";
            foreach (var item in s)
            {
                htmlcontent += "<h2>Câu :" + item.ThuTuCauHoi +""+ item.NoiDungCauHoi + "</h2>";
                htmlcontent += "<h3> A :" + item.dapAn1 + "</h3>";
                htmlcontent += "<h3> B :" + item.dapAn2 + "</h3>";
                htmlcontent += "<h3> C :" + item.dapAn3 + "</h3>";
                htmlcontent += "<h3> D :" + item.dapAn4 + "</h3>";
            }
            htmlcontent += "<br>";
            htmlcontent += "<br>";
            htmlcontent += "<h2 style='text-align:Center' > Danh Sách Đáp Án" + "</h2>";
            htmlcontent += "<Table>";
            foreach(var items in s)
            {
                htmlcontent += "<tr>";
                htmlcontent += " <th style='border:1px solid black;' Câu :>" + items.ThuTuCauHoi+"."+items.dapAnChinhXac+"</th >";
                htmlcontent += "</tr>";
             
            }
            


            htmlcontent += "</Table>";

            htmlcontent += "</div>";
            var dethi = new DeThi();

            PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
                dethi.Content = response;
                dethi.TenBaiThi = TenBaiThi;
               // dethi.CauHoiTracNghiem = s;
                dethi.maMonHoc = mon;
                if (gio != "0")
                {
                    dethi.ThoiGiangThi = (gio + "giờ" + phut + "Phút");
                }
                else
                {
                    dethi.ThoiGiangThi = (phut + "Phút");
                }

                dethi.TenGiaoVien = checkgv.user.Name;
                dethi.TinhTrang = "Cho Duyet";
                dethi.hinhThuc = hinhThuc;
                var thongBaoAdmin = new ThongBaoAdmin();
                thongBaoAdmin.tieuDe = "Giao Vien" + dethi.TenGiaoVien + "gui phe duyet bai thi " + dethi.TenBaiThi;
                db.ThongBaoAdmins.Add(thongBaoAdmin);
                db.DeThis.Add(dethi);
                db.SaveChanges();
            }
            string Filename = TenBaiThi + ".pdf";
            return dethi;
        }

        public DeThi themDeThiTuLuan(string TenBaiThi, string mon, string hinhThuc, List<TuLuan> s, string gio, string phut)
        {
          
            
            var document = new PdfDocument();
            string htmlcontent = "<div style='width:100%; text-align:Left'>";

            htmlcontent += "<h2  style='width:100%; text-align:Center'> CTY ASTA  </h2>";

            htmlcontent += "<br>";

            var tg = "";
            if (gio == "0")
            {
                tg = phut + "phút";

            }
            else
            {
                tg = gio + "giờ" + phut + "phút";
            }
            var monHoc = db.MonHocs.SingleOrDefault(x=>x.maMonHoc.Equals(mon));
            var checkgv = db.GiaoViens.SingleOrDefault(x => x.maGiaoVien == monHoc.maGiaoVien);
            if (monHoc != null)
            {
                htmlcontent += "<h2> Tên Bài:" + TenBaiThi + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + " Môn:" + monHoc.tenMonHoc + "&nbsp;" + "&nbsp;" + "Thời Gian:" + tg + "</h2>";
            }
           
            htmlcontent += "<br>";
            if (checkgv != null)
            {
                htmlcontent += "<h2>Giáo Viên :" + checkgv.user.Name + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "Hình Thức:" + hinhThuc + "</h2>";
            }
          
            htmlcontent += "<br>";
            htmlcontent += "<br>";
            foreach (var item in s)
            {
                htmlcontent += "<h2>Câu:" + item.ThuTuCauHoi + "</h2>";
                htmlcontent += "<h3> " + item.NoiDung + "</h3>";
            }

            htmlcontent += "</div>";
            var dethi = new DeThi();

            PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
                dethi.Content = response;
                dethi.TenBaiThi = TenBaiThi;
                //dethi.CauHoi = s;
                dethi.maMonHoc = mon;
                if (gio != "0")
                {
                    dethi.ThoiGiangThi = (gio + "giờ" + phut + "Phút");
                }
                else
                {
                    dethi.ThoiGiangThi = (phut + "Phút");
                }

                dethi.TenGiaoVien = checkgv.user.Name;
                dethi.TinhTrang = "Cho Duyet";
                dethi.hinhThuc = hinhThuc;
                var thongBaoAdmin = new ThongBaoAdmin();
                thongBaoAdmin.tieuDe = "Giao Vien" + dethi.TenGiaoVien + "gui phe duyet bai thi " + dethi.TenBaiThi;
                db.ThongBaoAdmins.Add(thongBaoAdmin);
                db.DeThis.Add(dethi);
                db.SaveChanges();
            }
            string Filename = TenBaiThi + ".pdf";
            return dethi;
        }

        public DeThi XemChiTietDeThi(int id)
        {
           var check = db.DeThis.SingleOrDefault(a => a.Id == id);
            if (check != null)
            {

                return new DeThi
                {
                    hinhThuc = check.hinhThuc,
                    TinhTrang = check.TinhTrang,
                    TenBaiThi = check.TenBaiThi,
                    TenGiaoVien = check.TenGiaoVien,
                    ThoiGiangThi = check.ThoiGiangThi,
                    maMonHoc = check.maMonHoc,
                    Content = check.Content,
              
                };
            }
            return null;
        }

        public List<DeThiViewModel> getAllDTAdmin(int page = 1)
        {
            var check = db.DeThis.AsQueryable();
            check = check.Skip((page - 1) * pagesize).Take(pagesize);
            var kq = check.Select(x => new DeThiViewModel
            {
                tenDeThi = x.TenBaiThi,
                hinhThuc = x.hinhThuc,
                Mon = x.maMonHoc,
                ngay = x.ThoiGiangThi,
                trangThai = x.TinhTrang,
                TenGV = x.TenGiaoVien


            }).ToList();
            return kq.ToList();
        }

       
    }
}
