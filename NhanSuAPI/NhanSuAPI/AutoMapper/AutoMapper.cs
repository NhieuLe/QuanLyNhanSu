using AutoMapper;
using NhanSuAPI.Data;
using NhanSuAPI.Models.ResponseModels;

namespace NhanSuAPI.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapNhanSu();
            MapCongViec();
            MapPhanCong();
            MapPhongBan();
        }
        private void MapNhanSu()
        {
            CreateMap<NhanSu, NhanSuResponse>().ReverseMap();
        }
        private void MapCongViec()
        {
            CreateMap<CongViec, CongViecResponse>().ReverseMap();
        }
        private void MapPhanCong()
        {
            CreateMap<PhanCong, PhanCongResponse>().ReverseMap();
        }
        private void MapPhongBan()
        {
            CreateMap<PhongBan, PhongBanResponse>().ReverseMap();
        }
    }
}
