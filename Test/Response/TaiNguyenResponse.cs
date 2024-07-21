using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class TaiNguyenResponse : ITaiNguyen
    {
        private readonly Database db;
        private int pagasize { get; set; } = 5;

        public TaiNguyenResponse(Database db)
        {
            this.db = db;
        }
        public async Task<FileUploadResponse>  Add(List<IFormFile> File, string maMonHoc, string tenBaiGiang, string gv, int maChuDe,int maBaiGiang)
        {
            long size = File.Sum(f => f.Length);
            List<FileUploadResponseData> uploadedFiles = new List<FileUploadResponseData>();

            try
            {
                foreach (var f in File)
                {
                    string name = f.FileName.Replace(@"\\\\", @"\\");

                    if (f.Length > 0)
                    {
                        var memoryStream = new MemoryStream();

                        try
                        {
                            await f.CopyToAsync(memoryStream);

                            if (memoryStream.Length < 20971521111111111)
                            {
                                var check = db.MonHocs.FirstOrDefault(x => x.maMonHoc == maMonHoc);

                                var nameGV = "";
                                var tenLop = "";
                                if (check != null)
                                {

                                    var giaovien = db.GiaoViens.FirstOrDefault(a => a.user.Email == gv);
                                    if (giaovien != null)
                                    {
                                        var user = db.Users.FirstOrDefault(b => b.Id == giaovien.maTK);
                                        if (user != null)
                                        {
                                            nameGV = user.Name;

                                        }
                                    }
                                    var checkLop = db.Lops.FirstOrDefault(c => c.maLop == check.maLop);
                                    if (checkLop != null)
                                    {
                                        tenLop = checkLop.tenLop;
                                    }
                                }
                                var file = new TaiNguyen()
                                {
                                    tenTaiNguyen = Path.GetFileName(tenBaiGiang),
                                    maBaiGiang = maBaiGiang,
                                    NgayUpload = DateTime.Now,
                                    UpdateByMember = nameGV,
                                    TrangThai = false,
                                    hinhThuc = "Tài Nguyên",
                                    ghiChu = "",
                                    maChuDe = maChuDe,
                                    maMonHoc = maMonHoc,
                                    Content = memoryStream.ToArray()
                                };
                                var thongbao = new ThongBao()
                                {
                                    tieuDeThongBao = "Giáo Viên " + nameGV + " Tài nguyên " + tenBaiGiang,
                                    TenNguoiThongBao = nameGV,
                                    

                                };
                                var thongBaoAd = new ThongBaoAdmin()
                                {
                                    tieuDe = "Giao Vien" + nameGV + "Gui Phe Duyet" + tenBaiGiang,

                                };
                                db.ThongBaoAdmins.Add(thongBaoAd);
                                db.TaiNguyens.Add(file);
                                db.ThongBaos.Add(thongbao);
                                await db.SaveChangesAsync();
                                uploadedFiles.Add(new FileUploadResponseData()
                                {
                                    Status = "OK",
                                    FileName = Path.GetFileName(name),
                                    ErrorMessage = "",
                                });

                            }
                            else
                            {
                                uploadedFiles.Add(new FileUploadResponseData()
                                {
                                    Id = 0,
                                    Status = "ERROR",
                                    FileName = Path.GetFileName(name),
                                    ErrorMessage = "File " + f + " Upload that bai"
                                });
                            }
                        }
                        finally
                        {
                            memoryStream.Close();
                            memoryStream.Dispose();
                        }
                    }
                }
                return new FileUploadResponse() { Data = uploadedFiles, ErrorMessage = "" };
            }
            catch (Exception ex)
            {
                return new FileUploadResponse() { ErrorMessage = ex.Message.ToString() };
            }
        }

        public string Delete(string name)
        {
           var check = db.TaiNguyens.SingleOrDefault(x=>x.tenTaiNguyen==name);
            if (check != null)
            {
                db.TaiNguyens.Remove(check);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public async Task<byte[]> DownloadFile(int id)
        {
            try
            {
                var selectedFile = db.TaiNguyens
                    .Where(f => f.IdTaiNguyen == id).SingleOrDefault();

                if (selectedFile == null)
                    return null;
                return selectedFile.Content;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TaiNguyenViewModel> GetAll(string name,int page = 1)
        {
            var check = db.TaiNguyens.AsQueryable();
            check = check.Skip((page - 1)*pagasize).Take(pagasize);
            var kq = check.Select(x => new TaiNguyenViewModel
            {
                IdTaiNguyen = x.IdTaiNguyen,
                tenTaiNguyen = x.tenTaiNguyen,
                ghiChu = x.ghiChu,
                hinhThuc = x.hinhThuc,  
                maBaiGiang=x.maBaiGiang,
                maChuDe=x.maChuDe,
                maMonHoc=x.maMonHoc,
                NgayUpload= x.NgayUpload,
                NguoiSoHuu=x.UpdateByMember,
                TrangThai= x.TrangThai,   
            }).Where(x=>x.NguoiSoHuu == name).ToList();
            return kq.ToList();
        }

        public TaiNguyen DuyetTaiNguyen(bool trangThai, int id, string ghiChu)
        {
            var check = db.TaiNguyens.SingleOrDefault(x => x.IdTaiNguyen == id);
            if (check != null)
            {
                check.TrangThai = trangThai;
                check.ghiChu = ghiChu;
                if (trangThai == false)
                {
                    check.TrangThai = false;
                    check.ghiChu = ghiChu;

                }
                db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }


            return null;
        }
    }
}
