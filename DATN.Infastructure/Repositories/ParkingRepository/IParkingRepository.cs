using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.ParkingRepository
{
    public interface IParkingRepository : IRepository<Parkings>
    {

        Task<Parkings> AddParkingAsync(Parkings entity);
        
        Task DeleteParkingByUsername(int ParkingCode);
        Task<Parkings> GetParkingByIdAsync(int ParkingCode);
        Task<bool> CheckParking(int parkingCode); 
        Task<bool> UpdatePreLoading(int parkingCode, int preLoading); 

        Task<List<Parkings>> GetAllParkingWithCondition(string searchTerm);
        Task<IReadOnlyList<Parkings>> BGetPagingAsync(int skip, int pageSize); 
        Task<IReadOnlyList<Parkings>> BGetPagingByParkingCodeAsync( int parkingCode); 
            
        Task<int> BGetTotalAsync();
        Task<int> GetCapacitybyParkingCode(int parkingCode);
        Task<Parkings> UpdateParkingAsync(Parkings entity);
    }
}
