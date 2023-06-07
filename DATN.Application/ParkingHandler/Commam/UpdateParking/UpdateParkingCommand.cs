using DATN.Application.Mapper;
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

namespace DATN.Application.ParkingHandler.Commam.UpdateParking
{
    public class UpdateParkingCommand : IRequest<BResult>
    {

        public int ParkingCode { get; set; }
        public string ParkingAddress { get; set; }
        public string ParkingName { get; set; }
        public int MnPrice { get; set; }
        public int MmPrice { get; set; }
        public int NnPrice { get; set; }
        public int Capacity { get; set; }

        public int NmPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class UpdateParkingCommandHandler : IRequestHandler<UpdateParkingCommand, BResult>
    {
        private readonly IParkingRepository _ParkingRepository;

        public UpdateParkingCommandHandler(IParkingRepository parkingRepository)
        {
            _ParkingRepository = parkingRepository;
        }

        public async Task<BResult> Handle(UpdateParkingCommand request, CancellationToken cancellationToken)
        {
            var entity = ParkingMapper.Mapper.Map<Parkings>(request);
            var result = await _ParkingRepository.UpdateParkingAsync(entity);

            return BResult.Success();
         
        }
    }
}
