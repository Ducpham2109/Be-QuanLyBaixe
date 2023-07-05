using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DATN.Infastructure.Repositories.EntryVehiclesRepository.EntryVehiclesRepository;

namespace DATN.Infastructure.Repositories.EntryVehiclesRepository
{
    public interface IEntryVehiclesRepository : IRepository<EntryVehicles>
    {
        Task<EntryVehicles> AddEntryVehiclesAsync(EntryVehicles entity);
        Task<List<EntryVehicles>> GetAllEntryVehiclesWithCondition(string searchTerm,int parkingCode);
        Task<IReadOnlyList<EntryVehicles>> BGetPagingAsync(int skip, int pageSize);
        Task<int> BGetTotalAsync();
        Task<int> GetEntryVehiclesByLisenseVehicle(int IDCard, int parkingCode);
        Task<Res> GetTotalVehyclesByParkingCode(int parkingCode, int month);
        Task<IReadOnlyList<EntryVehicles>> GetVehicleByIDCard(int idCard);
        Task<bool> CheckUIDCardExists(int idcard);
        Task DeleteVehicleByIDCard(int idcard);
        Task<Res> GetTotalVehyclesByMonth( int month); 
        Task<bool> CheckLisenseExists(string lisenseVehicle);


    }
}
