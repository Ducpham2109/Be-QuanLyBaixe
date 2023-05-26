using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.ManagementRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ManagementHandler.DeleteManagement
{
    public class DeleteManagementCommand : IRequest<BResult>
    {
        public string Username { get; set; }

        public DeleteManagementCommand(string username)
        {
            Username = username;
        }
    }

    public class DeleteManagementCommandHandler : IRequestHandler<DeleteManagementCommand, BResult>
    {
        private readonly IManagementRepository _DRepository;

        public DeleteManagementCommandHandler(IManagementRepository DRepository)
        {
            _DRepository = DRepository;
        }

        public async Task<BResult> Handle(DeleteManagementCommand request, CancellationToken cancellationToken)
        {
            await _DRepository.DeleteManagementByUsername(request.Username);
            return BResult.Success();
        }
    }
}
