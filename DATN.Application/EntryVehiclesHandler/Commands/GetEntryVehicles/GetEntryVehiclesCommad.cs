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

namespace DATN.Application.EntryVehiclesHandler.Commands.GetEntryVehicles
{
    public class GetEntryVehiclesCommand : IRequest<GetEntryVehiclesCommandResponse>
    {
        public int IDCard { get; set; }
        public int ParkingCode { get; set; }

        public GetEntryVehiclesCommand()
        {
            //LisenseVehicle = lisenseVehicle;
            //VehileyType = vehicleyType;
            //ParkingCode = parkingCode;
        }
    }
    public class GetEntryVehiclesCommandResponse
    {
        public int Cost { get; set; }
    }
    public class GetEntryVehiclesCommandHandler : IRequestHandler<GetEntryVehiclesCommand, GetEntryVehiclesCommandResponse>
    {
        private readonly IEntryVehiclesRepository _DRepository;

        public GetEntryVehiclesCommandHandler(IEntryVehiclesRepository DRepository)
        {
            _DRepository = DRepository;
        }

        public async Task<GetEntryVehiclesCommandResponse> Handle(GetEntryVehiclesCommand request, CancellationToken cancellationToken)
        {
            var cost = await _DRepository.GetEntryVehiclesByLisenseVehicle(request.IDCard ,request.ParkingCode);
            GetEntryVehiclesCommandResponse m = new GetEntryVehiclesCommandResponse();
            m.Cost = cost;
            return m;
        }
    }

}
