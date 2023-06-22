using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EntryVehiclesHandler.CreateEntryVehicles
{
    public class CreateEntryVehiclesCommand : IRequest<BResult>
    {
        public string Username { get; set; }
        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public string VehicleyType { get; set; }

        public int ParkingCode { get; set; }
        public string Image { get; set; }
        //public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class CreateEntryVehiclesCommandHandler : IRequestHandler<CreateEntryVehiclesCommand, BResult>
    {
        private readonly IEntryVehiclesRepository _accRepository;

        public CreateEntryVehiclesCommandHandler(IEntryVehiclesRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<BResult> Handle(CreateEntryVehiclesCommand request, CancellationToken cancellationToken)
        {
            var entity = BillsMapper.Mapper.Map<EntryVehicles>(request);
            var result = await _accRepository.AddEntryVehiclesAsync(entity);

            return BResult.Success();
        }
    }
}
