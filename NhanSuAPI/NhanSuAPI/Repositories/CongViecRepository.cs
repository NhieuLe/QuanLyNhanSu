using Microsoft.EntityFrameworkCore;
using NhanSuAPI.Data;

namespace NhanSuAPI.Repositories
{
    public class CongViecRepository : BaseRepository<CongViec>
    {
        public async Task<IQueryable<CongViec>> GetCongViecsWithInclude()
        {
            return _context.Set<CongViec>()
                .Where(t => t.DeleteDate == null);
        }

        public async Task<CongViec> CreateCongViecAsync(CongViec model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<CongViec> UpdateCongViecAsync(CongViec model)
        {
            return await Update(model);
        }
    }
}
