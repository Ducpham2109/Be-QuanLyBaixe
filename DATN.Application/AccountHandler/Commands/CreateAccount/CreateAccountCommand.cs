using DATN.Application.BillsHandler.Commands.CreateBills;
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

namespace DATN.Application.AccountHandler.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<BResult>
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public int Role { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, BResult>
    {
        private readonly IAccountRepository _accRepository;

        public CreateAccountCommandHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<BResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = AccountMapper.Mapper.Map<Accounts>(request);
            var result = await _accRepository.AddAccountAsync(entity);

            return BResult.Success();
        }
    }
}

