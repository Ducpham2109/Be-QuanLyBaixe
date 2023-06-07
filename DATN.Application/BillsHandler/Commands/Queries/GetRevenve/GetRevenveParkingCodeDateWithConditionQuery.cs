using DATN.Infastructure.Repositories.BillRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillsHandler.Commands.Queries.GetRevenve
{
    public class GetRevenveParkingDateWithConditionQuery : IRequest<GetRevenveParkingDateWithConditionQueryResponse>
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int ParkingCode { get; set; }

        public GetRevenveParkingDateWithConditionQuery()
        {
            // Constructor mặc định không tham số
        }
        //public GetRevenveParkingCodeWithConditionQuery(int parkingCode)
        //{
        //    ParkingCode = parkingCode;
        //}
    }
    public class GetRevenveParkingDateWithConditionQueryResponse
    {
        public int Revenve { get; set; }
    }
    public class GetRevenveParkingDateWithConditionQueryHandler : IRequestHandler<GetRevenveParkingDateWithConditionQuery, GetRevenveParkingDateWithConditionQueryResponse
>
    {
        private readonly IBillRepository _BillRepository;

        public GetRevenveParkingDateWithConditionQueryHandler(IBillRepository BillRepository)
        {
            _BillRepository = BillRepository;
        }
        public async Task<GetRevenveParkingDateWithConditionQueryResponse> Handle(GetRevenveParkingDateWithConditionQuery request, CancellationToken cancellationToken)
        {
            var revenve = await _BillRepository.GetRevenveByParkingCodeMonthDay( request.ParkingCode, request.Month, request.Day);
            GetRevenveParkingDateWithConditionQueryResponse m = new GetRevenveParkingDateWithConditionQueryResponse();
            m.Revenve = revenve;
            return m;

        }
    }
}
