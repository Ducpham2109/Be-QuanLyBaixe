using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.BillRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.BillsHandler.Commands.CreateBills
{
    public class CreateBillCommand : IRequest<BResult>
    {
        public int BillsId { get; set; }
        public string Username { get; set; }
        public string VehicleyType { get; set; }

        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public string OutTime { get; set; }
        public int ParkingCode { get; set; }
        public int Cost { get; set; }
        public string ImageIn { get; set; }
        public string ImageOut { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, BResult>
    {
        private readonly IBillRepository _accRepository;

        public CreateBillCommandHandler(IBillRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<BResult> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var entity = BillsMapper.Mapper.Map<Bills>(request);
            var result = await _accRepository.AddBillAsync(entity);

            return BResult.Success();
        }
    }
}
