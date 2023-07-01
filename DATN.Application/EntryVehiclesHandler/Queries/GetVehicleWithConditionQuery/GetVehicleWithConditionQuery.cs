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
    public class GetVehicle : IRequest<GetVehicleResponse>
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
    public class GetRevenveParkingCodeMonthWithConditionQueryHandler : IRequestHandler<GetVehicle, GetVehicleResponse>
    {
        private readonly IEntryVehiclesRepository _EntryVehiclesRepository;

        public GetRevenveParkingCodeMonthWithConditionQueryHandler(IEntryVehiclesRepository EntryVehiclesRepository)
        {
            _EntryVehiclesRepository = EntryVehiclesRepository;
        }
        public async Task<GetVehicleResponse> Handle(GetVehicle request, CancellationToken cancellationToken)
        {
            var vehicles = await _EntryVehiclesRepository.GetVehicleByIDCard(request.IDCard);
                GetVehicleResponse m = new GetVehicleResponse();
            m.IDCard = vehicles.IDCard;
            m.ParkingCode= vehicles.ParkingCode;
            m.LisenseVehicle = vehicles.LisenseVehicle;
            m.Username= vehicles.Username;
            m.EntryTime= vehicles.EntryTime;
            m.VehicleyType= vehicles.VehicleyType;
            m.Image= vehicles.Image;
            return m;

        }
    }
}
