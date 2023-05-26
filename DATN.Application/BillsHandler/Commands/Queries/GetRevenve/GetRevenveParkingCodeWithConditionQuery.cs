using DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesWithCondition;
using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Application.ParkingHandler.Queries;
using DATN.Infastructure.Repositories.BillRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillHandler.Queries.GetRevenveParkingCode
{
    public class GetRevenveMonthWithConditionQuery : IRequest<GetRevenveMonthWithConditionQueryResponse>
    {
        public int Month { get; set; }

        public GetRevenveMonthWithConditionQuery()
        {
            // Constructor mặc định không tham số
        }
        //public GetRevenveParkingCodeWithConditionQuery(int parkingCode)
        //{
        //    ParkingCode = parkingCode;
        //}
    }
    public class GetRevenveMonthWithConditionQueryResponse
    {
        public int Revenve { get; set; }
    }
    public class GetRevenveParkingCodeWithConditionQueryHandler : IRequestHandler<GetRevenveMonthWithConditionQuery, GetRevenveMonthWithConditionQueryResponse>
    {
        private readonly IBillRepository _BillRepository;

        public GetRevenveParkingCodeWithConditionQueryHandler(IBillRepository BillRepository)
        {
            _BillRepository = BillRepository;
        }
        public async Task<GetRevenveMonthWithConditionQueryResponse> Handle(GetRevenveMonthWithConditionQuery request, CancellationToken cancellationToken)
        {
             var revenve = await _BillRepository.GetRevenveByMonth( request.Month);
            GetRevenveMonthWithConditionQueryResponse m = new GetRevenveMonthWithConditionQueryResponse();
            m.Revenve = revenve;
            return m;
    
        }
    }
}
