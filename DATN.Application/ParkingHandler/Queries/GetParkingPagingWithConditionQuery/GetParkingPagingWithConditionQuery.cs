using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ParkingHandler.Queries.GetParkingPagingWithConditionQuery
{
    public class GetParkingPagingWithConditionQuery : IRequest<BResult<BPaging<GetParkingPagingWithConditionQueryResponse>>>
    {

        public int ParkingCode { get; set; }
    }
    public class GetParkingPagingWithConditionQueryResponse
    {
        public int ParkingCode { get; set; }
        public string ParkingAddress { get; set; }
        public string ParkingName { get; set; }
        public int MnPrice { get; set; }
        public int MmPrice { get; set; }
        public int NnPrice { get; set; }
        public int NmPrice { get; set; }
        public int Capacity { get; set; }


    }
    public class GetParkingPagingWithConditionQueryHandler : IRequestHandler<GetParkingPagingWithConditionQuery, BResult<BPaging<GetParkingPagingWithConditionQueryResponse>>>
    {
        private readonly IParkingRepository _accRepository;

        public GetParkingPagingWithConditionQueryHandler(IParkingRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetParkingPagingWithConditionQueryResponse>>> Handle(GetParkingPagingWithConditionQuery request, CancellationToken cancellationToken)
        {

            var entities = await _accRepository.BGetPagingByParkingCodeAsync(request.ParkingCode);
            var items = ParkingMapper.Mapper.Map<List<GetParkingPagingWithConditionQueryResponse>>(entities);
          
            var total = await _accRepository.BGetTotalAsync();
            //items.ForEach(item =>
            //{
            //    item.ParkingCode = request.ParkingCode;
            //    // Thêm điều kiện cho các thuộc tính khác tùy theo yêu cầu của bạn
            //});
            var filteredItems = items.Where(item => item.ParkingCode == request.ParkingCode).ToList();


            var result = new BPaging<GetParkingPagingWithConditionQueryResponse>()
            {
                Items = filteredItems,

                TotalItems = total,
            };
            return BResult<BPaging<GetParkingPagingWithConditionQueryResponse>>.Success(result);
        }
    }

}
