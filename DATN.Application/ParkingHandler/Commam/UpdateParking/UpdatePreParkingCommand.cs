using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ParkingHandler.Commam.UpdateParking
{
    public class UpdatePreParkingCommand : IRequest<BResult>
    {
        public int ParkingCode { get; set; }
     public int PreLoading { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class UpdatePreParkingCommandHandler : IRequestHandler<UpdatePreParkingCommand, BResult>
    {
        private readonly IParkingRepository _PaRepository;

        public UpdatePreParkingCommandHandler(IParkingRepository PaRepository)
        {
            _PaRepository = PaRepository;
        }

        public async Task<BResult> Handle(UpdatePreParkingCommand request, CancellationToken cancellationToken)
        {
            var entity = ParkingMapper.Mapper.Map<Parkings>(request);
            var IDCardExists = await _PaRepository.CheckParking(request.ParkingCode);

            if (IDCardExists)
            {
                var result = await _PaRepository.UpdatePreLoading(request.ParkingCode, request.PreLoading);
                if(result = true)
                {
                return BResult.Success();
                }
                else
                {
                    return BResult.Failure("Số tiền nhận phải nhỏ hơn số tiền User đã nạp");
                }
            }
            else
            {
                return BResult.Failure("ParkingCode không tồn tại");
               
             }
        }
    }
}
