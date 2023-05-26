using DATN.Infastructure.Repositories.BillRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillsHandler.Commands.Queries.GetRevenveParkingCode
{
    public class GetRevenveParkingMonthWithConditionQuery : IRequest<GetRevenveParkingMonthWithConditionQueryResponse>
    {
        public int Month { get; set; }
        public int ParkingCode { get; set; }

        public GetRevenveParkingMonthWithConditionQuery()
        {
            // Constructor mặc định không tham số
        }
        //public GetRevenveParkingCodeWithConditionQuery(int parkingCode)
        //{
        //    ParkingCode = parkingCode;
        //}
    }
    public class GetRevenveParkingMonthWithConditionQueryResponse
    {
        public int Revenve { get; set; }
    }
    public class GetRevenveParkingMonthWithConditionQueryHandler : IRequestHandler<GetRevenveParkingMonthWithConditionQuery, GetRevenveParkingMonthWithConditionQueryResponse
>
    {
        private readonly IBillRepository _BillRepository;

        public GetRevenveParkingMonthWithConditionQueryHandler(IBillRepository BillRepository)
        {
            _BillRepository = BillRepository;
        }
        public async Task<GetRevenveParkingMonthWithConditionQueryResponse> Handle(GetRevenveParkingMonthWithConditionQuery request, CancellationToken cancellationToken)
        {
            var revenve = await _BillRepository.GetRevenveByParkingCodeMonth(request.Month, request.ParkingCode);
            GetRevenveParkingMonthWithConditionQueryResponse m = new GetRevenveParkingMonthWithConditionQueryResponse();
            m.Revenve = revenve;
            return m;

        }
    }
}
