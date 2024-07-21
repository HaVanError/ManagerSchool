namespace Test.Model
{
    public class ListHoiDap
    {
        public string tenNguoiHoi { get; set; }
        public string tieuDe { get; set; }
        public string noiDungCauHoi { get;set; }
        public DateTime ngayHoi { get; set; }
    
        public List<TraLoi>traLois { get; set; }

    }
}
