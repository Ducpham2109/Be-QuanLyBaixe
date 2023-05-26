using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<BResult>
    {
        public string Username { get; set; }

        public DeleteAccountCommand(string username)
        {
            Username = username;
        }
    }

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, BResult>
    {
        private readonly IAccountRepository _DRepository;

        public DeleteAccountCommandHandler(IAccountRepository DRepository)
        {
            _DRepository = DRepository;
        }

        public async Task<BResult> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            await _DRepository.DeleteAccountByUsername(request.Username);
            return BResult.Success();
        }
    }
}
