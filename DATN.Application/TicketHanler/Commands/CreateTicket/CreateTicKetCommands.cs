using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.TicketRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.TicketHanler.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<BResult>
    {
        public int IDCard { get; set; }
        public int Money { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, BResult>
    {
        private readonly ITicketRepository _accRepository;

        public CreateTicketCommandHandler(ITicketRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<BResult> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = TicketMapper.Mapper.Map<Tickets>(request);
            //var IDCardExists = await _accRepository.CheckIDCardExists(request.IDCard);

            //if (IDCardExists)
            //{
            //    return BResult.Failure("IDCard đã tồn tại");
            //}
            //else
            //{
                var result = await _accRepository.AddTicketAsync(entity, request.IDCard, request.Money);
                return BResult.Success();
           // }
        }
    }
}
