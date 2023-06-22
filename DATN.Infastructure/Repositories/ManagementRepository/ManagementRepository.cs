using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.ManagementRepository
{
    public class ManagementRepository : Repository<Managements>, IManagementRepository
    {
        public ManagementRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<int> GetRoleByUserName(string userName)
        {
            var role = await _context.Set<Accounts>()
              .Where(a => a.IsDeleted == false
              && a.Username == userName)
              .Select(a => a.Role)
              .FirstOrDefaultAsync();
            return role;

        }
        public async Task<bool> CheckUsernameExists(string username)
        {
            return await _context.Set<Managements>()
                .AnyAsync(a => a.Username == username && !a.IsDeleted);
        }

        public async Task<Managements> AddManagementAsync(Managements entity, string username)
        {
                entity.TimingCreate = System.DateTime.Now;
                entity.IsDeleted = false;
                await _context.Set<Managements>().AddAsync(entity); //thêm vào rồi
                await _context.SaveChangesAsync(); // lưu vao database
                return entity;
         

        }
        public async Task<Managements> GetManagementByUsername(string Username)
        {
            var entity = await _context.Set<Managements>().FirstOrDefaultAsync(t => t.Username.Equals(Username));
            _context.Entry(entity).State = EntityState.Detached;
            if (entity?.IsDeleted == true)
            {
                return null;
            }
            return entity;
        }
        public async Task DeleteManagementByUsername(string Username)
        {
            var entity = await _context.Set<Managements>().FindAsync(Username);
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Managements> CheckManagement(string userName)
        {
            var entity = await _context.Set<Managements>().FirstOrDefaultAsync(t => t.Username.Equals(userName));
            _context.Entry(entity).State = EntityState.Detached;
            if (entity?.IsDeleted == true)
            {
                return null;
            }
            return entity;
        }
    }
}
