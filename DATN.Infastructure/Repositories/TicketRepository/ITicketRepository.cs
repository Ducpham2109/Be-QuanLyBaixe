using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.TicketRepository
{
    public interface ITicketRepository : IRepository<Tickets>
    {
        Task<Tickets> AddTicketAsync(Tickets entity, int idCard, int money, int parkingCode);
        Task<bool> CheckIDCardExists(int idcard);
        public Task ChangeMoney(int idcard, int money);
        public Task<int> ChangeMoneySentVehicle(int idcard, int cost);
        
        Task<Tickets> GetTicketWithConditionQuery(int idcard);



    }
}
