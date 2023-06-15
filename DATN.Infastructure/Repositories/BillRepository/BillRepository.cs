using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.BillRepository
{
    public class BillRepository : Repository<Bills>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Bills> AddBillAsync(Bills entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
            await _context.Set<Bills>().AddAsync(entity); //thêm vào rồi
            await _context.SaveChangesAsync(); // lưu vao database
            return entity;
        }
        public async Task<List<Bills>> GetAllBillWithCondition(string searchTerm)
        {
            var context = _context as ApplicationDbContext;
            var Bill = await context.Bills
                                .Where(d => (d.Username.Contains(searchTerm)
                                    || d.EntryTime.Contains(searchTerm)
                                    || d.OutTime.Contains(searchTerm)
                                    || d.LisenseVehicle.Contains(searchTerm)

                                    )
                                    && d.IsDeleted == false)
                                .ToListAsync();
            return Bill;
        }
        public async Task<IReadOnlyList<Bills>> BGetPagingAsync(int skip, int pageSize)
        {
            return await _context.Set<Bills>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
        }
        public async Task<IReadOnlyList<Bills>> BGetPagingByParkingCodeAsync(int skip, int pageSize, int parkingCode)
        {
            return await _context.Set<Bills>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<IReadOnlyList<Bills>> BGetAsync(Func<Bills, bool> predicate)
        {
            var listExist = await _context.Set<Bills>().Where(a => a.IsDeleted == false).ToListAsync();
            return listExist.Where(predicate).ToList();
        }
        public async Task<int> BGetTotalAsync()
        {
            return await _context.Set<Bills>().Where(a => a.IsDeleted == false).CountAsync();
        }
        public async Task<int> GetRevenveByMonth(int month)
        {
            var totalCost = await _context.Set<Bills>()
                              .Where(a => a.IsDeleted == false

                               && a.TimingCreate.Month == month)
                              .Select(a => a.Cost)
                              .SumAsync();
            return totalCost;
        }
        public async Task<int> GetRevenveByParkingCodeMonth(int month, int parkingCode)

        {
            var totalCost = await _context.Set<Bills>()
                              .Where(a => a.IsDeleted == false
                              && a.ParkingCode == parkingCode
                               && a.TimingCreate.Month == month)
                              .Select(a => a.Cost)
                              .SumAsync();
            return totalCost;


        }
        public async Task<int> GetRevenveByParkingCodeMonthDay( int parkingCode, int month, int day)

        {
            var totalCost = await _context.Set<Bills>()
                              .Where(a => a.IsDeleted == false
                               && a.TimingCreate.Month == month
                              && a.ParkingCode == parkingCode
                               && a.TimingCreate.Day == day)
                              .Select(a => a.Cost)
                              .SumAsync();
            return totalCost;


        }
    }
}
