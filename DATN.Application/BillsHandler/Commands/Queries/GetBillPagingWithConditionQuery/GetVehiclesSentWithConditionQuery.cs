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
    public class GetVehiclesSentWithConditionQuery : IRequest<BResult<BPaging<GetVehiclesSentWithConditionQueryResponse>>>
    {
        public string UserName { get; set; }
    }
    public class GetVehiclesSentWithConditionQueryResponse
    {

        public int BillsId { get; set; }
        public string Username { get; set; }
        public string VehicleyType { get; set; }
        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public string OutTime { get; set; }
        public int ParkingCode { get; set; }
        public int Cost { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class GetVehiclesSentWithConditionQueryHandler : IRequestHandler<GetVehiclesSentWithConditionQuery, BResult<BPaging<GetVehiclesSentWithConditionQueryResponse>>>
    {
        private readonly IBillRepository _accRepository;

        public GetVehiclesSentWithConditionQueryHandler(IBillRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetVehiclesSentWithConditionQueryResponse>>> Handle(GetVehiclesSentWithConditionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.GetVehiclesSentByUserName(request.UserName);
            var items = BillsMapper.Mapper.Map<List<GetVehiclesSentWithConditionQueryResponse>>(entities);
            var total = await _accRepository.BGetTotalAsync();

            var result = new BPaging<GetVehiclesSentWithConditionQueryResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetVehiclesSentWithConditionQueryResponse>>.Success(result);
        }
    }
}
