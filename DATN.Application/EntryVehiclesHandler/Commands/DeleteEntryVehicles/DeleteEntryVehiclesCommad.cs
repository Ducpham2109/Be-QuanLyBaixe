using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EntryVehiclesHandler.Commands.DeleteEntryVehicles
{
    public class DeleteEntryVehiclesCommand : IRequest<DeleteEntryVehiclesCommandResponse>
    {
        public string LisenseVehicle { get; set; }
        public string VehileyType { get; set; }
        public int ParkingCode { get; set; }

        public DeleteEntryVehiclesCommand()
        {
            //LisenseVehicle = lisenseVehicle;
            //VehileyType = vehicleyType;
            //ParkingCode = parkingCode;
        }
    }
    public class DeleteEntryVehiclesCommandResponse
    {
        public int Cost { get; set; }
    }
    public class DeleteEntryVehiclesCommandHandler : IRequestHandler<DeleteEntryVehiclesCommand, DeleteEntryVehiclesCommandResponse>
    {
        private readonly IEntryVehiclesRepository _DRepository;

        public DeleteEntryVehiclesCommandHandler(IEntryVehiclesRepository DRepository)
        {
            _DRepository = DRepository;
        }

        public async Task<DeleteEntryVehiclesCommandResponse> Handle(DeleteEntryVehiclesCommand request, CancellationToken cancellationToken)
        {
            var cost = await _DRepository.DeleteEntryVehiclesByLisenseVehicle(request.LisenseVehicle,request.VehileyType, request.ParkingCode);
            DeleteEntryVehiclesCommandResponse m = new DeleteEntryVehiclesCommandResponse();
            m.Cost = cost;
            return m;
        }
    }

}
