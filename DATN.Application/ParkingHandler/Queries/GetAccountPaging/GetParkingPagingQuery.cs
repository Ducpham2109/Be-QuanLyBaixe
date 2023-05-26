using DATN.Application.Mapper;
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

namespace DATN.Application.ParkingHandler.Queries.GetAccountPaging
{
    public class GetParkingPagingQuery : IRequest<BResult<BPaging<GetParkingPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetParkingPagingResponse
    {
        public int ParkingCode { get; set; }
        public string ParkingAddress { get; set; }
        public string ParkingName { get; set; }
        public int MnPrice { get; set; }
        public int MmPrice { get; set; }
        public int NnPrice { get; set; }
        public int NmPrice { get; set; }

    }
    public class GetParkingPagingQueryHandler : IRequestHandler<GetParkingPagingQuery, BResult<BPaging<GetParkingPagingResponse>>>
    {
        private readonly IParkingRepository _accRepository;

        public GetParkingPagingQueryHandler(IParkingRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetParkingPagingResponse>>> Handle(GetParkingPagingQuery request, CancellationToken cancellationToken)
        {

            var entities = await _accRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = ParkingMapper.Mapper.Map<List<GetParkingPagingResponse>>(entities);

            var total = await _accRepository.BGetTotalAsync();

            var result = new BPaging<GetParkingPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetParkingPagingResponse>>.Success(result);
        }
    }
}
