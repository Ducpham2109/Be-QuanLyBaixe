using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.BillRepository;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillsHandler.Commands.Queries.GetBillPaging
{
    public class GetBillPagingQuery : IRequest<BResult<BPaging<GetBillPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetBillPagingResponse
    {

        public int BillsId { get; set; }
        public string Username { get; set; }
        public string LisenseVehicle { get; set; }
        public string VehicleyType { get; set; }

        public string EntryTime { get; set; }
        public string OutTime { get; set; }
        public int ParkingCode { get; set; }
        public int Cost { get; set; }
        public string ImageIn { get; set; }
        public string ImageOut { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class GetBillPagingQueryHandler : IRequestHandler<GetBillPagingQuery, BResult<BPaging<GetBillPagingResponse>>>
    {
        private readonly IBillRepository _accRepository;

        public GetBillPagingQueryHandler(IBillRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetBillPagingResponse>>> Handle(GetBillPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = BillsMapper.Mapper.Map<List<GetBillPagingResponse>>(entities);
            var total = await _accRepository.BGetTotalAsync();

            var result = new BPaging<GetBillPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetBillPagingResponse>>.Success(result);
        }
    }
}
