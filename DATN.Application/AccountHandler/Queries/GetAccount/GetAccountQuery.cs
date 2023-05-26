using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAccount
{
    public class GetAccountQuery : IRequest<GetAccountResponse>
    {
        public string Username { get; set; }

        public GetAccountQuery(string usename)
        {
            Username = usename;
        }
    }
    public class GetAccountResponse
    {
        
        public int Role { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }

    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountResponse>
    {
        private readonly IAccountRepository _accRepository;

        public GetAccountQueryHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<GetAccountResponse> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accRepository.GetAccountByUsername(request.Username);
            var result = AccountMapper.Mapper.Map<GetAccountResponse>(entity);
            return result;

        }
    }
}
