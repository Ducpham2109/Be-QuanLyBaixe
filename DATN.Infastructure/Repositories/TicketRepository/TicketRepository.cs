using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.TicketRepository
{
    public class TicketRepository : Repository<Tickets>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Tickets> AddTicketAsync(Tickets entity, int idCard, int money, int parkingCode)
        {
            var ticket = await _context.Set<Tickets>()
               .Where(a => a.IDCard == idCard && a.IsDeleted == false)
               .FirstOrDefaultAsync();
            var parking = await _context.Set<Parkings>()
                .Where(b => b.ParkingCode == parkingCode && b.IsDeleted == false)
                .FirstOrDefaultAsync();
                parking.PreLoading = parking.PreLoading + money;
                await _context.SaveChangesAsync();
            if (ticket == null)
            {
                entity.TimingCreate = System.DateTime.Now;
                entity.IsDeleted = false;
                await _context.Set<Tickets>().AddAsync(entity); //thêm vào rồi
                await _context.SaveChangesAsync(); // lưu vao database
                return entity;
            }
            else
            {
                ticket.Monney = money + ticket.Monney;
                await _context.SaveChangesAsync();
                return ticket;
            }
           
        }
        public async Task<bool> CheckIDCardExists(int idcard)
        {
            return await _context.Set<Tickets>()
                .AnyAsync(a => a.IDCard == idcard && !a.IsDeleted);
        }
        public async Task ChangeMoney(int idcard, int money)
        {
            var ticket = await _context.Set<Tickets>()
                .Where(a => a.IDCard==idcard&&a.IsDeleted==false)
                .FirstOrDefaultAsync();
            ticket.Monney = money + ticket.Monney;
            await _context.SaveChangesAsync();
        }
        public async Task<int> ChangeMoneySentVehicle(int idcard, int cost)
        {
            var ticket = await _context.Set<Tickets>()
                .Where(a => a.IDCard == idcard && a.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (ticket.Monney >= cost) { 
            ticket.Monney = ticket.Monney - cost;
        }
            await _context.SaveChangesAsync();
            return ticket.Monney;
        }
        public async Task<Tickets> GetTicketWithConditionQuery(int idcard)
        {
            var entity = await _context.Set<Tickets>().Where(a => a.IsDeleted == false
            &&a.IDCard==idcard).FirstOrDefaultAsync();
            return entity;
        }
    }
}
