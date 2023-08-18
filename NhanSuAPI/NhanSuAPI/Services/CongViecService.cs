using AutoMapper;
using NhanSuAPI.Data;
using NhanSuAPI.Repositories;

namespace NhanSuAPI.Services
{
    public interface ICongViecService
    {
        public Task<ICollection<CongViec>> GetAllCongViecsAsync();
        public Task<CongViec> CreateCongViecAsync(CongViec model);
        public Task<CongViec> UpdateCongViecAsync(CongViec model);
        public Task<CongViec> DeleteCongViecAsync(string id);
    }
    public class CongViecService : ICongViecService
    {
        private readonly IMapper _mapper;
        private readonly CongViecRepository _CongViecRepository;

        public CongViecService(IMapper mapper, CongViecRepository CongViecRepository)
        {
            _mapper = mapper;
            _CongViecRepository = CongViecRepository;
        }

        public async Task<ICollection<CongViec>> GetAllCongViecsAsync()
        {
            var CongViecs = await _CongViecRepository.GetCongViecsWithInclude();
            return CongViecs.ToList();
        }

        public async Task<CongViec> CreateCongViecAsync(CongViec model)
        {
            var result = await _CongViecRepository.CreateCongViecAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<CongViec> UpdateCongViecAsync(CongViec model)
        {
            var result = await _CongViecRepository.UpdateCongViecAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<CongViec> DeleteCongViecAsync(string id)
        {
            var result = await GetCongViecById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateCongViecAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<CongViec> GetCongViecById(string Id)
        {
            return await _CongViecRepository.GetById(Id);
        }
    }
}
