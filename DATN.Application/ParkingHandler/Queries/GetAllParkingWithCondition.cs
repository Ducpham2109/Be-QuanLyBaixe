using DATN.Application.Models;
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
    public class GetAllParkingWithConditionQuery : IRequest<BResult<BPaging<GetAlllParkingWithConditionResponse>>>
    {
        //public GetAllAccountWithConditionQuery(string search)
        //{
        //	Search = search;
        //}
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
    public class GetAlllParkingWithConditionResponse
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

    public class GetAllParkingWithConditionQueryHandler : IRequestHandler<GetAllParkingWithConditionQuery, BResult<BPaging<GetAlllParkingWithConditionResponse>>>
    {
        private readonly IParkingRepository _ParkingRepository;

        public GetAllParkingWithConditionQueryHandler(IParkingRepository ParkingRepository)
        {
            _ParkingRepository = ParkingRepository;
        }
        public async Task<BResult<BPaging<GetAlllParkingWithConditionResponse>>> Handle(GetAllParkingWithConditionQuery request, CancellationToken cancellationToken)
        {
            var Parkings= await _ParkingRepository.GetAllParkingWithCondition(request.Search);

            var results = new List<GetAlllParkingWithConditionResponse>();

            // Convert each Account to a response object
            foreach (var Parking in Parkings)
            {
                var result = new GetAlllParkingWithConditionResponse();
                result.ParkingAddress= Parking.ParkingAddress;
                result.ParkingCode = Parking.ParkingCode;
                result.ParkingName = Parking.ParkingName;
                result.MnPrice = Parking.MnPrice;
                result.MmPrice = Parking.MmPrice;
                result.NnPrice = Parking.NnPrice;
                result.NmPrice = Parking.NmPrice;
                result.Capacity = Parking.Capacity;
                results.Add(result);
            }
            var total = results.Count();
            var item = results.Skip(request.Skip).Take(request.PageSize).ToList();
            var resultFinal = new BPaging<GetAlllParkingWithConditionResponse>()
            {
                Items = item,
                TotalItems = total

            };

            return BResult<BPaging<GetAlllParkingWithConditionResponse>>.Success(resultFinal);
            //return results;
        }

    }
}
