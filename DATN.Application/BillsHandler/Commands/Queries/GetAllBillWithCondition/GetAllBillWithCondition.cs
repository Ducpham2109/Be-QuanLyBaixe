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

namespace DATN.Application.BillsHandler.Commands.Queries.GetAllBillWithCondition
{
    public class GetAllBillWithConditionQuery : IRequest<BResult<BPaging<GetAllBillWithConditionResponse>>>
    {
        //public GetAllAccountWithConditionQuery(string search)
        //{
        //	Search = search;
        //}
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
    public class GetAllBillWithConditionResponse
    {
        public int BillsId { get; set; }
        public string Username { get; set; }
        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public string OutTime { get; set; }
        public string VehicleyType { get; set; }

        public int ParkingCode { get; set; }
        public int Cost { get; set; }
        public string ImageIn { get; set; }
        public string ImageOut { get; set; }

    }

    public class GetAllBillWithConditionQueryHandler : IRequestHandler<GetAllBillWithConditionQuery, BResult<BPaging<GetAllBillWithConditionResponse>>>
    {
        private readonly IBillRepository _billRepository;

        public GetAllBillWithConditionQueryHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public async Task<BResult<BPaging<GetAllBillWithConditionResponse>>> Handle(GetAllBillWithConditionQuery request, CancellationToken cancellationToken)
        {
            var Bills = await _billRepository.GetAllBillWithCondition(request.Search);

            var results = new List<GetAllBillWithConditionResponse>();

            // Convert each Account to a response object
            foreach (var Bill in Bills)
            {
                var result = new GetAllBillWithConditionResponse();

                result.BillsId = Bill.BillsId;
                result.LisenseVehicle = Bill.LisenseVehicle;
                result.EntryTime = Bill.EntryTime;
                result.Username = Bill.Username;
                result.ParkingCode = Bill.ParkingCode;
                result.ImageIn = Bill.ImageIn;
                result.ImageOut = Bill.ImageOut;
                result.EntryTime = Bill.EntryTime;
                result.OutTime = Bill.OutTime;
                result.VehicleyType = Bill.VehicleyType;
                results.Add(result);
            }
            var total = results.Count();
            var item = results.Skip(request.Skip).Take(request.PageSize).ToList();
            var resultFinal = new BPaging<GetAllBillWithConditionResponse>()
            {
                Items = item,
                TotalItems = total

            };

            return BResult<BPaging<GetAllBillWithConditionResponse>>.Success(resultFinal);
            //return results;
        }

    }
}
