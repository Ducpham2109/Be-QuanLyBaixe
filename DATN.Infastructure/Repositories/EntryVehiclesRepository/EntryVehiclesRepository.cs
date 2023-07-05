using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.EntryVehiclesRepository
{
    public class EntryVehiclesRepository : Repository<EntryVehicles>, IEntryVehiclesRepository
    {
        public EntryVehiclesRepository(ApplicationDbContext context) : base(context)
        {
         
        }
        public async Task<EntryVehicles> AddEntryVehiclesAsync(EntryVehicles entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
            await _context.Set<EntryVehicles>().AddAsync(entity); //thêm vào rồi
            await _context.SaveChangesAsync(); // lưu vao database
            return entity;
        }
        public async Task<List<EntryVehicles>> GetAllEntryVehiclesWithCondition(string searchTerm, int parkingCode)
        {
            var context = _context as ApplicationDbContext;
            var EntryVehicles = await context.EntryVehicles
                                .Where(d => (d.Username.Contains(searchTerm)
                                    || d.LisenseVehicle.Contains(searchTerm))
                                    && d.IsDeleted == false
                                    && d.ParkingCode==parkingCode)
                                .ToListAsync();
            return EntryVehicles;
        }
        public async Task<IReadOnlyList<EntryVehicles>> BGetAsync(Func<EntryVehicles, bool> predicate)
        {
            var listExist = await _context.Set<EntryVehicles>().Where(a => a.IsDeleted == false).ToListAsync();
            return listExist.Where(predicate).ToList();
        }
        public async Task<int> BGetTotalAsync()
        {
            return await _context.Set<EntryVehicles>().Where(a => a.IsDeleted == false).CountAsync();
        }
        public async Task<IReadOnlyList<EntryVehicles>> BGetPagingAsync(int skip, int pageSize)
        {
            var entities =  await _context.Set<EntryVehicles>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
            return entities;
        }
      
        public async Task<int> GetEntryVehiclesByLisenseVehicle(int IDCard, int parkingCode)
        {
            var entity = await _context.Set<EntryVehicles>().FirstOrDefaultAsync(t => t.IDCard.Equals(IDCard));
            entity.TimingDelete = System.DateTime.Now;
           
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var price = await _context.Set<Parkings>()
                             .Where(a => a.IsDeleted == false
                              && a.ParkingCode == parkingCode 
                              )
                             .Select(a => new
                             {
                                 MnPrice = a.MnPrice,
                                 NmPrice = a.NmPrice,
                                 MmPrice = a.MmPrice,
                                 NnPrice = a.NnPrice
                             })
                             .ToListAsync();
            var vehycle = await _context.Set<EntryVehicles>()
                          .Where(a => a.IsDeleted == false
                           && a.ParkingCode == parkingCode
                          // && a.VehicleyType == vehicleyType
                           && a.IDCard == IDCard
                           )
                          .OrderByDescending(a => a.TimingDelete)
                          .Select(a => new
                          {
                              vehicleyType = a.VehicleyType,
                              timeIn = a.TimingCreate,
                              timeOut = a.TimingDelete
                          })
                        .FirstOrDefaultAsync();
           
            int MnPrice = price.FirstOrDefault()?.MnPrice ?? 0;
            int NmPrice = price.FirstOrDefault()?.NmPrice ?? 0;
            int MmPrice = price.FirstOrDefault()?.MmPrice ?? 0;
            int NnPrice = price.FirstOrDefault()?.NnPrice ?? 0;
            int cost=0;
            string veType = vehycle.vehicleyType;
            var hourIn = vehycle.timeIn.Hour;
            var hourOut = vehycle.timeOut.Hour;
            var dayIn = vehycle.timeIn.Day;
            var dayOut = vehycle.timeOut.Day;
            int timeIn = (int)(dayIn * 60 + hourIn);
            int timeOut = (int)(dayOut * 60 + hourOut);
            if (veType == "xe oto")
            {
                if (hourIn >= 22)
                {
                    if (timeOut - timeIn >= 12)
                    {
                        cost = NnPrice + 15000 * ((timeOut - timeIn) / 12);
                    }
                    else cost = NnPrice;
                }
                else if (timeOut - timeIn >= 12)
                {
                    cost = NmPrice + 15000 * ((timeOut - timeIn) / 12);
                }
                     else cost = NmPrice;
            }
            else 
            {
                if (hourIn >= 22)
                {
                    if (timeOut - timeIn >= 12)
                    {
                        cost = MnPrice + 5000 * ((timeOut - timeIn) / 12);
                    }
                    else cost = MnPrice;
                }
                else
                {
                    if (timeOut - timeIn >= 12)
                    {
                        cost = MmPrice + 5000 * ((timeOut - timeIn) / 12);
                    }
                    else cost = MmPrice;
                }
            }
            return cost;
        }
        public async Task DeleteVehicleByIDCard(int idcard)
        {
            var entity = await _context.Set<EntryVehicles>()
                .Where(e => e.IDCard == idcard
                &&e.IsDeleted==false)
                .FirstOrDefaultAsync();

            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public class Res
        {
            public int VehiclesFalseCounter { get; set; }
            public int VehiclesTrueCounter { get; set; }

        }
        public async Task<Res> GetTotalVehyclesByParkingCode(int parkingCode, int month)
        {
            List<int> totalVehycles = new List<int>();
            var vehicleTrue = await _context.Set<EntryVehicles>()
                 .Where(a => a.IsDeleted == true
                              && a.ParkingCode == parkingCode
                              && a.TimingCreate.Month== month
                              )
                 .CountAsync();
            var vehicleFalse = await _context.Set<EntryVehicles>()
              .Where(a => a.IsDeleted == false
                           && a.ParkingCode == parkingCode
                              && a.TimingCreate.Month == month

                           )
              .CountAsync();
            Res m = new Res();
            m.VehiclesFalseCounter = vehicleFalse;
            m.VehiclesTrueCounter = vehicleTrue;
            return m;
        }
        public async Task<bool> CheckLisenseExists(string lisenseVehicle)
        {
            return await _context.Set<EntryVehicles>()
               .AnyAsync(a => a.LisenseVehicle == lisenseVehicle && !a.IsDeleted);
        }
        public async Task<Res> GetTotalVehyclesByMonth(int month)
        {
            List<int> totalVehycles = new List<int>();
            var vehicleTrue = await _context.Set<EntryVehicles>()
                 .Where(a => a.IsDeleted == true
                              && a.TimingCreate.Month == month
                              )
                 .CountAsync();
            var vehicleFalse = await _context.Set<EntryVehicles>()
              .Where(a => a.IsDeleted == false
                              && a.TimingCreate.Month == month

                           )
              .CountAsync();
            Res m = new Res();
            m.VehiclesFalseCounter = vehicleFalse;
            m.VehiclesTrueCounter = vehicleTrue;
            return m;
        }
        public async Task<IReadOnlyList<EntryVehicles>> GetVehicleByIDCard(int idCard)
        {
            var entity = await _context.Set<EntryVehicles>()
    .Where(a => a.IsDeleted == false && a.IDCard == idCard)
    .ToListAsync();


            return entity;

        }
        public async Task<bool> CheckUIDCardExists(int idcard)
        {
            return await _context.Set<EntryVehicles>()
                .AnyAsync(a => a.IDCard == idcard && a.IsDeleted== false);
        }
    }
}
