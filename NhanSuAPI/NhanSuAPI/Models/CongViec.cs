namespace NhanSuAPI.Data
{
    public class CongViec : Entity
    {
        public string TenCongViec { get; set; }
        public ICollection<CongViec>? CongViecs { get; set; }
    }
}
