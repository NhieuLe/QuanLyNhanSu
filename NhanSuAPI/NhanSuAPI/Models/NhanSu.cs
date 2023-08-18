namespace NhanSuAPI.Data
{
    public class NhanSu : Entity
    {
        public string Ten { get; set; }
        public string? GioiTinh { get; set; }

        public string? MaPhongBan { get; set; }

        public PhongBan PhongBan { get; set; }
        public ICollection<PhanCong>? PhanCongs { get; set; }
    }
}
