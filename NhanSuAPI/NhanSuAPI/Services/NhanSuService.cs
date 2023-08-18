using AutoMapper;
using NhanSuAPI.Data;
using NhanSuAPI.Repositories;
using NhanSuAPI.Services;

namespace NhanSuAPI.Services
{
    public interface INhanSuService
    {
        public Task<ICollection<NhanSu>> GetAllNhanSusAsync();
        public Task<NhanSu> CreateNhanSuAsync(NhanSu model);
        public Task<NhanSu> UpdateNhanSuAsync(NhanSu model);
        public Task<NhanSu> DeleteNhanSuAsync(string id);
    }
    public class NhanSuService : INhanSuService
    {
        private readonly IMapper _mapper;
        private readonly NhanSuRepository _NhanSuRepository;

        public NhanSuService(IMapper mapper, NhanSuRepository NhanSuRepository)
        {
            _mapper = mapper;
            _NhanSuRepository = NhanSuRepository;
        }

        public async Task<ICollection<NhanSu>> GetAllNhanSusAsync()
        {
            var NhanSus = await _NhanSuRepository.GetNhanSusWithInclude();
            return NhanSus.ToList();
        }

        public async Task<NhanSu> CreateNhanSuAsync(NhanSu model)
        {
            var result = await _NhanSuRepository.CreateNhanSuAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<NhanSu> UpdateNhanSuAsync(NhanSu model)
        {
            var result = await _NhanSuRepository.UpdateNhanSuAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<NhanSu> DeleteNhanSuAsync(string id)
        {
            var result = await GetNhanSuById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateNhanSuAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<NhanSu> GetNhanSuById(string Id)
        {
            return await _NhanSuRepository.GetById(Id);
        }
    }
}
