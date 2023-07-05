using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EntryVehiclesHandler.Commands.DeleteEntryVehicle
{
    public class DeleteEntryVehicleCommand : IRequest<BResult>
    {
        public int IdCard { get; set; }

        public DeleteEntryVehicleCommand(int IDCard)
        {
            IdCard = IDCard;
        }
    }

    public class DeleteEntryVehicleCommandHandler : IRequestHandler<DeleteEntryVehicleCommand, BResult>
    {
        private readonly IEntryVehiclesRepository _DRepository;

        public DeleteEntryVehicleCommandHandler(IEntryVehiclesRepository DRepository)
        {
            _DRepository = DRepository;
        }

        public async Task<BResult> Handle(DeleteEntryVehicleCommand request, CancellationToken cancellationToken)
        {
            await _DRepository.DeleteVehicleByIDCard(request.IdCard);
            return BResult.Success();
        }
    }
}
