using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ParkingHandler.Queries.GetCapacityParkingCodeWithCondition
{
    public class GetCapacityParkingCodeWithCondition : IRequest<GetCapacityParkingCodeWithConditionResponse>
    {
        public int ParkingCode { get; set; }
        public GetCapacityParkingCodeWithCondition() { }
    }
    public class GetCapacityParkingCodeWithConditionResponse
    {
        public int Capacity { get; set; }
    }
    public class GetCapacityParkingCodeWithConditionHandler : IRequestHandler<GetCapacityParkingCodeWithCondition, GetCapacityParkingCodeWithConditionResponse>
    {
        private readonly IParkingRepository _ParkingRepository;

        public GetCapacityParkingCodeWithConditionHandler(IParkingRepository ParkingRepository)
        {
            _ParkingRepository = ParkingRepository;
        }
        public async Task<GetCapacityParkingCodeWithConditionResponse> Handle(GetCapacityParkingCodeWithCondition request, CancellationToken cancellationToken)
        {
            var capacity = await _ParkingRepository.GetCapacitybyParkingCode(request.ParkingCode);
            GetCapacityParkingCodeWithConditionResponse response = new GetCapacityParkingCodeWithConditionResponse();

            response.Capacity = capacity;
            return response;
        }
    }
}
