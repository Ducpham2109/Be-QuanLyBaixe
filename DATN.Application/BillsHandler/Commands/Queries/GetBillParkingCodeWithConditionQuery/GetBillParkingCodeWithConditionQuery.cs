using DATN.Application.Models;
using DATN.Infastructure.Repositories.BillRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillsHandler.Commands.Queries.GetBillParkingCodeWithConditionQuery
{
    public class GetBillParkingCodeWithConditionQuery : IRequest<BResult<BPaging<GetBillParkingCodeWithConditionQueryResponse>>>
    {
        //public GetAllAccountWithConditionQuery(string search)
        //{
        //	Search = search;
        //}
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public int ParkingCode { get; set; }

    }
    public class GetBillParkingCodeWithConditionQueryResponse
    {
        public int BillsId { get; set; }
        public string Username { get; set; }
        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public string OutTime { get; set; }
        public string VehicleyType { get; set; }
        public int ParkingCode { get; set; }
        public int Cost { get; set; }
       

    }

    public class GetBillParkingCodeWithConditionQueryHandler : IRequestHandler<GetBillParkingCodeWithConditionQuery, BResult<BPaging<GetBillParkingCodeWithConditionQueryResponse>>>
    {
        private readonly IBillRepository _billRepository;

        public GetBillParkingCodeWithConditionQueryHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public async Task<BResult<BPaging<GetBillParkingCodeWithConditionQueryResponse>>> Handle(GetBillParkingCodeWithConditionQuery request, CancellationToken cancellationToken)
        {
            var Bills = await _billRepository.GetBillParkingCodeWithCondition(request.Search, request.ParkingCode);

            var results = new List<GetBillParkingCodeWithConditionQueryResponse>();

            // Convert each Account to a response object
            foreach (var Bill in Bills)
            {
                var result = new GetBillParkingCodeWithConditionQueryResponse();

                result.BillsId = Bill.BillsId;
                result.LisenseVehicle = Bill.LisenseVehicle;
                result.EntryTime = Bill.EntryTime;
                result.Username = Bill.Username;
                result.ParkingCode = Bill.ParkingCode;
                result.EntryTime = Bill.EntryTime;
                result.OutTime = Bill.OutTime;
                result.Cost = Bill.Cost;
                result.VehicleyType = Bill.VehicleyType;
                results.Add(result);
            }
            var total = results.Count();
            var item = results.Skip(request.Skip).Take(request.PageSize).ToList();
            var resultFinal = new BPaging<GetBillParkingCodeWithConditionQueryResponse>()
            {
                Items = item,
                TotalItems = total

            };

            return BResult<BPaging<GetBillParkingCodeWithConditionQueryResponse>>.Success(resultFinal);
            //return results;
        }

    }
}
