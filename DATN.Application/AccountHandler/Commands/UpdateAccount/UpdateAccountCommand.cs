using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<BResult>
    {
   
        public int Role { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, BResult>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<BResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = AccountMapper.Mapper.Map<Accounts>(request);
            var result = await _accountRepository.UpdateAccountAsync(entity);

            return BResult.Success();
            //if (result.Success == false)
            //{
            //    return BResult.Failure(result.Message);
            //}
            //else
            //{
            //    return BResult.Success(result.Message);
            //}
        }
    }
}
