namespace NhanSuAPI.Data
{
    public class PhongBan : Entity
    {
        public string TenPhongBan { get; set; }
        public ICollection<NhanSu>? NhanSus { get; set; }
    }
}
