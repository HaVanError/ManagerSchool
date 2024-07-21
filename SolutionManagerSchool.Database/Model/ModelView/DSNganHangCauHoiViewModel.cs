namespace Test.Model.ModelView
{
    public class DSNganHangCauHoiViewModel
    {
        public string Id { get; set; }
        public string mon { get; set; }
        public string doKho { get; set; }
        public string nguoiSoHuu { get; set; }
        public DateTime suaDoiLanCuoi { get; set; }
        //  public int idCauHoi { get; set; }
         public List< CauHoiTN> CauHoiTN { get; set; }
    }
}
