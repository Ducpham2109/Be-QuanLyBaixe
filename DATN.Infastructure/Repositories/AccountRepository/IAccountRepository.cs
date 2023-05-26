using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DATN.Infastructure.Repositories.AccountRepository.AccountRepository;

namespace DATN.Infastructure.Repositories.AccountRepository
{
	public interface IAccountRepository : IRepository<Accounts>
	{
		public Task<Accounts> CheckAuth(string userName, string password);
		Task<Accounts> AddAccountAsync(Accounts entity);
        Task<Accounts> UpdateAccountAsync(Accounts entity);
        Task DeleteAccountByUsername(string Username);
        Task<Accounts> GetAccountByUsername(string Username);
        Task<IReadOnlyList<Accounts>> BGetPagingAsync(int skip, int pageSize);
        Task<int> BGetTotalAsync();
        Task<List<Accounts>> GetAllAccountWithCondition(string searchTerm);

    }
}
