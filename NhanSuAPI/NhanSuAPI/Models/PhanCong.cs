namespace NhanSuAPI.Data
{
    public class PhanCong
    {
        public string? MaNhanSu { get; set; }
        public string? MaCongViec { get; set; }
        public DateTimeOffset? DeleteDate { get; set; }
        public DateTimeOffset NgayBD { get; set; }
        public DateTimeOffset NgayKT { get; set; }
        public NhanSu NhanSu { get; set; }
        public CongViec CongViec { get; set; }
    }
}
