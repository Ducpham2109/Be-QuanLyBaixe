using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.ManagementRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ParkingHandler.Commam.CreateParking
{
    public class CreateParkingCommand : IRequest<BResult>
    {


        public int ParkingCode { get; set; }
        public string ParkingAddress { get; set; }
        public string ParkingName { get; set; }
        public int MnPrice { get; set; }
        public int MmPrice { get; set; }
        public int NnPrice { get; set; }
        public int NmPrice { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class CreateParkingCommandHandler : IRequestHandler<CreateParkingCommand, BResult>
    {
        private readonly IParkingRepository _PaRepository;

        public CreateParkingCommandHandler(IParkingRepository PaRepository)
        {
            _PaRepository = PaRepository;
        }

        public async Task<BResult> Handle(CreateParkingCommand request, CancellationToken cancellationToken)
        {
            var entity = ParkingMapper.Mapper.Map<Parkings>(request);
            var result = await _PaRepository.AddParkingAsync(entity);

            return BResult.Success();
        }
    }
}
