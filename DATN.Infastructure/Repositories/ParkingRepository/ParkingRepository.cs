using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using DATN.Infastructure.Repositories.ManagementRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.ParkingRepository
{

    public class ParkingRepository : Repository<Parkings>, IParkingRepository
    {
        public ParkingRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Parkings> AddParkingAsync(Parkings entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
            await _context.Set<Parkings>().AddAsync(entity); //thêm vào rồi
            await _context.SaveChangesAsync(); // lưu vao database
            return entity;
        }
        public async Task DeleteParkingByUsername(int ParkingCode)
        {
            var entity = await _context.Set<Parkings>().FindAsync(ParkingCode);
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Parkings> GetParkingByIdAsync(int ParkingCode)
        {
            var entity = await _context.Set<Parkings>().FirstOrDefaultAsync(t => t.ParkingCode.Equals(ParkingCode));
            _context.Entry(entity).State = EntityState.Detached;
            if (entity?.IsDeleted == true)
            {
                return null;
            }
            return entity;
        }
        public async Task<List<Parkings>> GetAllParkingWithCondition(string searchTerm)
        {
            var context = _context as ApplicationDbContext;
            var parkings = await context.Parkings
                                .Where(d => (d.ParkingAddress.Contains(searchTerm)
                                    || d.ParkingName.Contains(searchTerm))
                                    && d.IsDeleted == false)
                                .ToListAsync();
            return parkings;
        }
        public async Task<bool> CheckParking(int parkingCode)
        {
            return await _context.Set<Parkings>()
                .AnyAsync(a => a.ParkingCode == parkingCode && !a.IsDeleted);
        }
        public async Task<bool> UpdatePreLoading(int parkingCode, int preLoading)
        {
            var parking = await _context.Set<Parkings>()
                .Where(a=> a.ParkingCode == parkingCode && a.IsDeleted == false)
                .FirstOrDefaultAsync(); 
            parking.PreLoading= parking.PreLoading-preLoading;
            if(parking.PreLoading < 0)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IReadOnlyList<Parkings>> BGetPagingAsync(int skip, int pageSize)
        {
            return await _context.Set<Parkings>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
        }
        public async Task<IReadOnlyList<Parkings>> BGetPagingByParkingCodeAsync(int parkingCode)
        {
            var entity = await _context.Set<Parkings>().Where(a => a.IsDeleted == false && a.ParkingCode == parkingCode)

                .ToListAsync();

            return entity;
        }
        //public async Task<IReadOnlyList<Parkings>> BGetPagingByParkingCodeAsync(int skip, int pageSize, int parkingCode)
        //{
        //    var entity = await _context.Set<Parkings>().Where(a=>a.ParkingCode==parkingCode).Skip(skip).Take(pageSize).ToListAsync();
        //    return entity;
        //}
        public async Task<IReadOnlyList<Parkings>> BGetAsync(Func<Parkings, bool> predicate)
        {
            var listExist = await _context.Set<Parkings>().Where(a => a.IsDeleted == false).ToListAsync();
            return listExist.Where(predicate).ToList();
        }
        public async Task<int> BGetTotalAsync()
        {
            return await _context.Set<Parkings>().Where(a => a.IsDeleted == false).CountAsync();
        }
        public async Task<Parkings> UpdateParkingAsync(Parkings entity)
        {
            entity.TimingUpdate = System.DateTime.Now;
            entity.IsDeleted = false;

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> GetCapacitybyParkingCode(int parkingCode)
        {
            var capacity = await _context.Set<Parkings>()
                              .Where(a => a.IsDeleted == false
                              && a.ParkingCode == parkingCode)
                              .Select(a => a.Capacity)
                              .SumAsync();
            var vehicleFalse = await _context.Set<EntryVehicles>()
           .Where(a => a.IsDeleted == false
                        && a.ParkingCode == parkingCode
                        )
                        .CountAsync();
            var Space = capacity - vehicleFalse;
            return Space;
        }

    }


}
