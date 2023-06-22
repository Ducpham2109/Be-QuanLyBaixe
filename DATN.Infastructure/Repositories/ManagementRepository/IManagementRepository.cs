using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.ManagementRepository
{
    public interface IManagementRepository : IRepository<Managements>
    {
       
        Task<Managements> AddManagementAsync(Managements entity, string username);
        Task<Managements> GetManagementByUsername(string Username);
        Task DeleteManagementByUsername(string Username);
        Task <Managements> CheckManagement(string Username);
        Task <int> GetRoleByUserName(string Username);
        Task<bool> CheckUsernameExists(string username);
    }
}
