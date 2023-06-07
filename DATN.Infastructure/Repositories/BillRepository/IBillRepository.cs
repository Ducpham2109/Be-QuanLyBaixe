using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.BillRepository
{
    public interface IBillRepository : IRepository<Bills>
    {
        Task<Bills> AddBillAsync(Bills entity);
        Task<List<Bills>> GetAllBillWithCondition(string searchTerm);
        Task<IReadOnlyList<Bills>> BGetPagingAsync(int skip, int pageSize);
        Task<int> BGetTotalAsync();
        Task<int> GetRevenveByMonth( int month);
        Task<int> GetRevenveByParkingCodeMonth(int month, int parkingCode);
        Task<int> GetRevenveByParkingCodeMonthDay(int parkingCode, int month, int day);


    }
}
