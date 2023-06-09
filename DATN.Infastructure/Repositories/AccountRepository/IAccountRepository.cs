﻿using DATN.Core.Entities;
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
        public Task ChangePassword(string userName, string oldPassword, string newPassword);

        Task DeleteAccountByUsername(string username);
        Task<Accounts> GetAccountByUsername(string Username);
        Task<IReadOnlyList<AccountsMa>> BGetPagingAsync(int skip, int pageSize);
        Task<IReadOnlyList<Accounts>> BGetPagingByRoleAsync(int skip, int pageSize, int role);

        Task<int> BGetTotalAsync();
        Task<List<Accounts>> GetAllAccountWithCondition(string searchTerm);
        Task<string> ChangePasswordAsync(string email);
        Task<int> GetNewAccountWithByMonth(int month);
        Task<bool> CheckUsernameExists(string username);

    }
}
