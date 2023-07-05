using DATN.Application.AccountHandler.Queries.GetAccountPagingWithConditionQuery;
using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EntryVehiclesHandler.Queries.GetVehicleWithConditionQuery
{
    public class GetVehicle : IRequest<BResult<BPaging<GetVehicleResponse>>>
    {
        public int IDCard { get; set; }

        public GetVehicle()
        {
            // Constructor mặc định không tham số
        }
        //public GetRevenveParkingCodeWithConditionQuery(int parkingCode)
        //{
        //    ParkingCode = parkingCode;
        //}
    }
    public class GetVehicleResponse
    {
          public string Username { get; set; }
        public int IDCard { get; set; }
        public string LisenseVehicle { get; set; }
        public string VehicleyType { get; set; }
        public string EntryTime { get; set; }
        public int ParkingCode { get; set; }
        public string Image { get; set; }

    }
    public class GetRevenveParkingCodeMonthWithConditionQueryHandler : IRequestHandler<GetVehicle, BResult<BPaging<GetVehicleResponse>>>
    {
        private readonly IEntryVehiclesRepository _EntryVehiclesRepository;

        public GetRevenveParkingCodeMonthWithConditionQueryHandler(IEntryVehiclesRepository EntryVehiclesRepository)
        {
            _EntryVehiclesRepository = EntryVehiclesRepository;
        }
        public async Task<BResult<BPaging<GetVehicleResponse>>> Handle(GetVehicle request, CancellationToken cancellationToken)
        {
            
            var usernameExists = await _EntryVehiclesRepository.CheckUIDCardExists(request.IDCard);

            if (usernameExists)
            {
                var vehicles = await _EntryVehiclesRepository.GetVehicleByIDCard(request.IDCard);
                var items = EntryVehiclesMapper.Mapper.Map<List<GetVehicleResponse>>(vehicles);
                var result = new BPaging<GetVehicleResponse>()
                {
                    Items = items,

                };
                return BResult<BPaging<GetVehicleResponse>>.Success(result);
            }
            else
            {
                throw new InvalidOperationException("Entity not found");

            }


        }
    }
}
