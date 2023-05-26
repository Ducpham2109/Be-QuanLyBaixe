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

namespace DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesWithCondition
{
    public class GetAllEntryVehiclesWithConditionQuery : IRequest<BResult<BPaging<GetAllEntryVehiclesWithConditionResponse>>>
    {
        //public GetAllAccountWithConditionQuery(string search)
        //{
        //	Search = search;
        //}
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public int ParkingCode { get; set; }
        public string Search { get; set; }
      

    }
    public class GetAllEntryVehiclesWithConditionResponse
    {  
        public string Username { get; set; }
        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public int ParkingCode { get; set; }
        public string VehicleyType { get; set; }
        public string Image { get; set; }

    }

    public class GetAllEntryVehiclesWithConditionQueryHandler : IRequestHandler<GetAllEntryVehiclesWithConditionQuery, BResult<BPaging<GetAllEntryVehiclesWithConditionResponse>>>
    {
        private readonly IEntryVehiclesRepository _EntryVehiclesRepository;

        public GetAllEntryVehiclesWithConditionQueryHandler(IEntryVehiclesRepository EntryVehiclesRepository)
        {
            _EntryVehiclesRepository = EntryVehiclesRepository;
        }
        public async Task<BResult<BPaging<GetAllEntryVehiclesWithConditionResponse>>> Handle(GetAllEntryVehiclesWithConditionQuery request, CancellationToken cancellationToken)
        {
            var EntryVehicles = await _EntryVehiclesRepository.GetAllEntryVehiclesWithCondition(request.Search,request.ParkingCode);

            var results = new List<GetAllEntryVehiclesWithConditionResponse>();

            // Convert each Account to a response object
            foreach (var EntryVehicle in EntryVehicles)
            {
                var result = new GetAllEntryVehiclesWithConditionResponse();

                result.Username = EntryVehicle.Username;
                result.LisenseVehicle = EntryVehicle.LisenseVehicle;
                result.EntryTime = EntryVehicle.EntryTime;
                result.VehicleyType = EntryVehicle.VehicleyType;
                result.ParkingCode = EntryVehicle.ParkingCode;
                result.Image = EntryVehicle.Image;

                results.Add(result);
            }
            var total = results.Count();
            var item = results.Skip(request.Skip).Take(request.PageSize).ToList();
            var resultFinal = new BPaging<GetAllEntryVehiclesWithConditionResponse>()
            {
                Items = item,
                TotalItems = total

            };

            return BResult<BPaging<GetAllEntryVehiclesWithConditionResponse>>.Success(resultFinal);
            //return results;
        }

    }

}
