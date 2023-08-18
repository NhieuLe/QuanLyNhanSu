namespace NhanSuAPI.Models.ResponseModels
{
    public class PhanCongResponse
    {
        public string? MaNhanSu { get; set; }
        public string? MaCongViec { get; set; }

        public DateTimeOffset NgayBD { get; set; }
        public DateTimeOffset NgayKT { get; set; }
    }
}
