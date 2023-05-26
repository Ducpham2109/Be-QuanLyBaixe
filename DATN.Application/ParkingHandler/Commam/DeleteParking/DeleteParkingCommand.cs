using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ParkingHandler.Commam.DeleteParking
{
    public class DeleteParkingCommand : IRequest<BResult>
    {
        public int ParkingCode { get; set; }

        public DeleteParkingCommand(int parkingCode)
        {
            ParkingCode = parkingCode;
        }
    }

    public class DeleteParkingCommandHandler : IRequestHandler<DeleteParkingCommand, BResult>
    {
        private readonly IParkingRepository _DRepository;

        public DeleteParkingCommandHandler(IParkingRepository DRepository)
        {
            _DRepository = DRepository;
        }

        public async Task<BResult> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
        {
            await _DRepository.DeleteParkingByUsername(request.ParkingCode);
            return BResult.Success();
        }
    }
}
