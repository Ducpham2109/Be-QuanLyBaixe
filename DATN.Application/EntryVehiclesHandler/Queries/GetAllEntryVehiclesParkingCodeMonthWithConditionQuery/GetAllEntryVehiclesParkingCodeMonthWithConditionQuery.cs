using DATN.Infastructure.Repositories.BillRepository;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesParkingCodeMonthWithCondition
{
   
    public class GetAllEntryVehiclesMonthWithConditionQuery : IRequest<GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse>
    {
        public int Month { get; set; }

        public GetAllEntryVehiclesMonthWithConditionQuery()
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
    public class GetRevenveParkingCodeMonthWithConditionQueryHandler : IRequestHandler<GetAllEntryVehiclesMonthWithConditionQuery, GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse>
    {
        private readonly IEntryVehiclesRepository _EntryVehiclesRepository;

        public GetRevenveParkingCodeMonthWithConditionQueryHandler(IEntryVehiclesRepository EntryVehiclesRepository)
        {
            _EntryVehiclesRepository = EntryVehiclesRepository;
        }
        public async Task<GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse> Handle(GetAllEntryVehiclesMonthWithConditionQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _EntryVehiclesRepository.GetTotalVehyclesByMonth( request.Month);
            GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse m = new GetAllEntryVehiclesParkingCodeMonthWithConditionQueryResponse();
            m.TotalVehiclesTrue = vehicles.VehiclesTrueCounter;
            m.TotalVehiclesFalse = vehicles.VehiclesFalseCounter;
            return m ;

        }
    }
}
