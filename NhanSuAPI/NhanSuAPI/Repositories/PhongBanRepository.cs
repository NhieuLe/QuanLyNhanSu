using Microsoft.EntityFrameworkCore;
using NhanSuAPI.Data;

namespace NhanSuAPI.Repositories
{
    public class PhongBanRepository : BaseRepository<PhongBan>
    {
        public async Task<IQueryable<PhongBan>> GetPhongBansWithInclude()
        {
            return _context.Set<PhongBan>().Include(i => i.NhanSus)
                .Where(t => t.DeleteDate == null);
        }

        public async Task<PhongBan> CreatePhongBanAsync(PhongBan model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<PhongBan> UpdatePhongBanAsync(PhongBan model)
        {
            return await Update(model);
        }
    }
}
