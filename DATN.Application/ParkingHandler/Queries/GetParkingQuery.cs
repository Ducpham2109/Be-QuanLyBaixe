using DATN.Application.Mapper;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ParkingHandler.Queries
{
    public class GetParkingQuery : IRequest<GetParkingResponse>
    {
        public int ParkingCode { get; set; }

        public GetParkingQuery(int parkingCode)
        {
            ParkingCode = parkingCode;
        }
    }
    public class GetParkingResponse
    {
        public int ParkingCode { get; set; }
        public string ParkingAddress { get; set; }
        public string ParkingName { get; set; }
        public int MnPrice { get; set; }
        public int MmPrice { get; set; }
        public int NnPrice { get; set; }
        public int NmPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }

    public class GetParkingQueryHandler : IRequestHandler<GetParkingQuery, GetParkingResponse>
    {
        private readonly IParkingRepository _ParkRepository;

        public GetParkingQueryHandler(IParkingRepository parkRepository)
        {
            _ParkRepository = parkRepository;
        }

        public async Task<GetParkingResponse> Handle(GetParkingQuery request, CancellationToken cancellationToken)
        {
                var entity = await _ParkRepository.GetParkingByIdAsync(request.ParkingCode);
            var result = ParkingMapper.Mapper.Map<GetParkingResponse>(entity);
            return result;

        }
    }
}
