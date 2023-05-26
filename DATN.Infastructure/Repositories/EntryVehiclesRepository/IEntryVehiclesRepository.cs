using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.EntryVehiclesRepository
{
    public interface IEntryVehiclesRepository : IRepository<EntryVehicles>
    {
        Task<EntryVehicles> AddEntryVehiclesAsync(EntryVehicles entity);
        Task<List<EntryVehicles>> GetAllEntryVehiclesWithCondition(string searchTerm,int parkingCode);
        Task<IReadOnlyList<EntryVehicles>> BGetPagingAsync(int skip, int pageSize);
        Task<int> BGetTotalAsync();
        Task<int> DeleteEntryVehiclesByLisenseVehicle(string lisenseVehicle, string vehicleyType, int parkingCode);
    }
}
