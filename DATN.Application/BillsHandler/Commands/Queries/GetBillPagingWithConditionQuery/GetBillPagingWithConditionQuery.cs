using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.BillRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillsHandler.Commands.Queries.GetBillPagingWithConditionQuery
{
    public class GetBillPagingWithConditionQuery : IRequest<BResult<BPaging<GetBillPagingWithConditionQueryResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public int parkingCode { get; set; }
    }
    public class GetBillPagingWithConditionQueryResponse
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
    public class GetBillPagingWithConditionQueryHandler : IRequestHandler<GetBillPagingWithConditionQuery, BResult<BPaging<GetBillPagingWithConditionQueryResponse>>>
    {
        private readonly IBillRepository _accRepository;

        public GetBillPagingWithConditionQueryHandler(IBillRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetBillPagingWithConditionQueryResponse>>> Handle(GetBillPagingWithConditionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.BGetPagingByParkingCodeAsync(request.Skip, request.PageSize, request.parkingCode);
            var items = BillsMapper.Mapper.Map<List<GetBillPagingWithConditionQueryResponse>>(entities);
            var total = await _accRepository.BGetTotalAsync();
            var filteredItems = items.Where(item => item.ParkingCode == request.parkingCode).ToList();


            var result = new BPaging<GetBillPagingWithConditionQueryResponse>()
            {
                Items = filteredItems,

                TotalItems = total,
            };
            return BResult<BPaging<GetBillPagingWithConditionQueryResponse>>.Success(result);
        }
    }
}
