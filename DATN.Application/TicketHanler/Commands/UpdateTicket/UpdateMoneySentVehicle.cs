using DATN.Application.Models;
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
    public class UpdateMoneysentVehicleCommand : IRequest<BResult>
    {
        public int IDCard { get; set; }

        public int Cost { get; set; }
    }

    public class UpdateMoneysentVehicleCommandHandler : IRequestHandler<UpdateMoneysentVehicleCommand, BResult>
    {
        private readonly ITicketRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateMoneysentVehicleCommandHandler(ITicketRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BResult> Handle(UpdateMoneysentVehicleCommand request, CancellationToken cancellationToken)
        {
            //var currentUserIdLogged = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(BClaimType.Id)?.Value);
            var checkID = await _accountRepository.CheckIDCardExists(request.IDCard);
            if (checkID)
            {
                var money = await _accountRepository.ChangeMoneySentVehicle(request.IDCard, request.Cost);
                if (money < request.Cost)
                {
                    return BResult.Failure("Tài khoản không đủ, vui lòng thu tiền mặt");
                }
                else
                {
                    return BResult.Success();
                }
              
            }
            else
            {
                return BResult.Failure("IDCard chưa kích hoạt,Vui lòng thu tiền mặt"); 
            }
        }
    }
}
