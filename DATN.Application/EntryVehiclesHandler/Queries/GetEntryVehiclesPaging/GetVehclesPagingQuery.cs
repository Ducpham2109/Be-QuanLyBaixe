using DATN.Application.Mapper;
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

namespace DATN.Application.EntryVehiclesHandler.Queries.GetEntryVehiclesPaging
{
    public class GetEntryVehiclesPagingQuery : IRequest<BResult<BPaging<GetEntryVehiclesPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetEntryVehiclesPagingResponse
    {

        public string Username { get; set; }
        public string LisenseVehicle { get; set; }
        public string VehicleyType { get; set; }
        public string EntryTime { get; set; }
        public int ParkingCode { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class GetEntryVehiclesPagingQueryHandler : IRequestHandler<GetEntryVehiclesPagingQuery, BResult<BPaging<GetEntryVehiclesPagingResponse>>>
    {
        private readonly IEntryVehiclesRepository _accRepository;

        public GetEntryVehiclesPagingQueryHandler(IEntryVehiclesRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetEntryVehiclesPagingResponse>>> Handle(GetEntryVehiclesPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = BillsMapper.Mapper.Map<List<GetEntryVehiclesPagingResponse>>(entities);
            var total = await _accRepository.BGetTotalAsync();

            var result = new BPaging<GetEntryVehiclesPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetEntryVehiclesPagingResponse>>.Success(result);
        }
    }
}
