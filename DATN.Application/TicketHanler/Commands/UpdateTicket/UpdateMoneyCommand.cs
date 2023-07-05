using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.TicketRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.TicketHanler.Commands.UpdateTicket
{
    public class UpdateMoneyCommand : IRequest<BResult>
    {
        public int IDCard  { get; set; }
        
        public int Monney { get; set; }
    }

    public class UpdateMoneyCommandHandler : IRequestHandler<UpdateMoneyCommand, BResult>
    {
        private readonly ITicketRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateMoneyCommandHandler(ITicketRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BResult> Handle(UpdateMoneyCommand request, CancellationToken cancellationToken)
        {
            //var currentUserIdLogged = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(BClaimType.Id)?.Value);
            var checkID = await _accountRepository.CheckIDCardExists(request.IDCard);
            if (checkID)
            {
                await _accountRepository.ChangeMoney(request.IDCard, request.Monney);
                return BResult.Success();
            }
            else
            {
                return BResult.Failure("IDCard không tồn tại, bạn cần thêm mới");

            }
        }
    }
}
