using Microsoft.EntityFrameworkCore;
using NhanSuAPI.Data;

namespace NhanSuAPI.Repositories
{
    public class NhanSuRepository : BaseRepository<NhanSu>
    {
        public async Task<IQueryable<NhanSu>> GetNhanSusWithInclude()
        {
            return _context.Set<NhanSu>().Include(i => i.PhanCongs)
                .Where(t => t.DeleteDate == null);
        }
        public async Task<NhanSu> CreateNhanSuAsync(NhanSu model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<NhanSu> UpdateNhanSuAsync(NhanSu model)
        {
            return await Update(model);
        }
    }
}
