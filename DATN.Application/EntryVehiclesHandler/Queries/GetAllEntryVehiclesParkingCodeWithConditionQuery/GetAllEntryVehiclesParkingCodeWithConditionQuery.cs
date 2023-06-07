using DATN.Infastructure.Repositories.BillRepository;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesParkingCodeWithCondition
{
   
    public class GetAllEntryVehiclesParkingCodeMonthWithConditionQuery : IRequest<GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse>
    {
        public int ParkingCode { get; set; }
        public int Month { get; set; }

        public GetAllEntryVehiclesParkingCodeMonthWithConditionQuery()
        {
            // Constructor mặc định không tham số
        }
        //public GetRevenveParkingCodeWithConditionQuery(int parkingCode)
        //{
        //    ParkingCode = parkingCode;
        //}
    }
    public class GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse
    {
        public int TotalVehiclesFalse { get; set; }
        public int TotalVehiclesTrue { get; set; }

    }
    public class GetRevenveParkingCodeMonthWithConditionQueryHandler : IRequestHandler<GetAllEntryVehiclesParkingCodeMonthWithConditionQuery, GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse>
    {
        private readonly IEntryVehiclesRepository _EntryVehiclesRepository;

        public GetRevenveParkingCodeMonthWithConditionQueryHandler(IEntryVehiclesRepository EntryVehiclesRepository)
        {
            _EntryVehiclesRepository = EntryVehiclesRepository;
        }
        public async Task<GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse> Handle(GetAllEntryVehiclesParkingCodeMonthWithConditionQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _EntryVehiclesRepository.GetTotalVehyclesByParkingCode(request.ParkingCode, request.Month);
            GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse m = new GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse();
            m.TotalVehiclesTrue = vehicles.VehiclesTrueCounter;
            m.TotalVehiclesFalse = vehicles.VehiclesFalseCounter;
            return m ;

        }
    }
}
