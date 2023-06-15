using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.AccountRepository
{
    public class AccountRepository : Repository<Accounts>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Accounts> CheckAuth(string userName, string password)
        {
            var account = await BFistOrDefaultAsync(acc => acc.Username.Equals(userName) && acc.Password.Equals(password));
            return account;
        }
        public async Task<Accounts> AddAccountAsync(Accounts entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
            await _context.Set<Accounts>().AddAsync(entity); //thêm vào rồi
            await _context.SaveChangesAsync(); // lưu vao database
            return entity;
        }
        public async Task<Accounts> UpdateAccountAsync(Accounts entity)
        {
            entity.TimingUpdate = System.DateTime.Now;
            entity.IsDeleted = false;
          
            _context.Entry(entity).State = EntityState.Modified;
          
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAccountByUsername(string Username)
        {
            var entity = await _context.Set<Accounts>().FindAsync(Username);
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Accounts> GetAccountByUsername(string Username)
        {
            var entity = await _context.Set<Accounts>().FirstOrDefaultAsync(t => t.Username.Equals(Username));
            _context.Entry(entity).State = EntityState.Detached;
            if (entity?.IsDeleted == true)
            {
                return null;
            }
            return entity;
        }
        public class AccountsMa
        {
            public int Role { get; set; }
            public int PhoneNumber { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsDeleted { get; set; }
            public int? ParkingCode { get; set; }
        }
        public async Task<IReadOnlyList<AccountsMa>> BGetPagingAsync(int skip, int pageSize)
        {
            var query = from account in _context.Accounts
                        join management in _context.Managements on account.Username equals management.Username into joinedData
                        from management in joinedData.DefaultIfEmpty()
                        where !account.IsDeleted
                        orderby account.Role ascending
                        select new
                        {
                        UserName = account.Username,
                        Password = account.Password,
                        Role = account.Role,
                        PhoneNumber = account.PhoneNumber,
                        Email = account.Email,
                        ParkingCode = management.ParkingCode != null ? management.ParkingCode:null,


                        };

            var result = query.ToList();
           List<AccountsMa> entitiesList = new List<AccountsMa>();

    foreach (var item in result)
    {
        var entity = new AccountsMa
        {
            Role = item.Role,
            PhoneNumber = item.PhoneNumber,
            Email = item.Email,
            UserName = item.UserName,
            Password = item.Password,
            ParkingCode = item.ParkingCode
        };

        entitiesList.Add(entity);
    }

    return entitiesList;
        }
        public async Task<IReadOnlyList<Accounts>> BGetPagingByRoleAsync(int skip, int pageSize, int role)
        {
            var entities =  await _context.Set<Accounts>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
        return entities;
        }
        public async Task<IReadOnlyList<Accounts>> BGetAsync(Func<Accounts, bool> predicate)
        {
            var listExist = await _context.Set<Accounts>().Where(a => a.IsDeleted == false).ToListAsync();
            
            return listExist.Where(predicate).ToList();
        }
        public async Task<int> BGetTotalAsync()
        {
            return await _context.Set<Accounts>().Where(a => a.IsDeleted == false).CountAsync();
        }
        public async Task<List<Accounts>> GetAllAccountWithCondition(string searchTerm)
        {
            var context = _context as ApplicationDbContext;
            var accounts = await context.Accounts 
                                .Where(d => (d.Username.Contains(searchTerm)
                                    || d.Password.Contains(searchTerm)
                                    )
                                    && d.IsDeleted == false)
                                .ToListAsync();
            return accounts;
        }
        public async Task ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var account = await BFistOrDefaultAsync(acc => acc.Username == userName && acc.Password == oldPassword);
            account.Password = newPassword;
            await _context.SaveChangesAsync();
        }
        public async  Task<string> ChangePasswordAsync(string email)
        {
            var account = await _context.Set<Accounts>().FirstOrDefaultAsync(a => a.Email.Equals(email));
            if(account == null)
            {
                return "Email không tồn tại ";
            }
            account.Password = GeneratePassword();
            await _context.SaveChangesAsync();
            string emailBody = $@"Tài khoản: {account.Username}<br>Mật Khẩu: {account.Password}";
            return emailBody;
        }
        private static string GeneratePassword()
        {
            var random = new Random();
            string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string specialChars = "!@#$%&*,.";

            string password = "";
            password += lowerChars[random.Next(lowerChars.Length)].ToString();
            password += upperChars[random.Next(upperChars.Length)].ToString();
            password += numbers[random.Next(numbers.Length)].ToString();

            // Chỉ có 1 ký tự đặc biệt
            password += specialChars[random.Next(specialChars.Length)].ToString();

            for (int i = 4; i < 8; i++)
            {
                string allChars = lowerChars + upperChars + numbers;
                password += allChars[random.Next(allChars.Length)].ToString();
            }

            return password;
        }
        public async Task<int> GetNewAccountWithByMonth(int month)
        {
            var total = await _context.Set<Accounts>()
                .Where(a=>a.IsDeleted == false
                &&a.TimingCreate.Month==month
                &&a.Role==2) 
                .CountAsync();
            return total;
        }
    }
}

