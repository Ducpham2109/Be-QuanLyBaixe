//using DATN.Application.Models;
//using DATN.Infastructure.Repositories.AccountRepository;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace DATN.Application.AccountHandler.Commands.UpdateAccount
//{
//    public class UpdateAccountPassCommand : IRequest<BResult>
//    {
//        public int Id { get; set; }
//        public string OldPassword { get; set; }
//        public string NewPassword { get; set; }
//    }

//    public class UpdateAccountPassCommandHandler : IRequestHandler<UpdateAccountPassCommand, BResult>
//    {
//        private readonly IAccountRepository _accountRepository;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public UpdateAccountPassCommandHandler(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
//        {
//            _accountRepository = accountRepository;
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public async Task<BResult> Handle(UpdateAccountPassCommand request, CancellationToken cancellationToken)
//        {
//            //var currentUserIdLogged = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(BClaimType.Id)?.Value);
//            var account = await _accountRepository.BFistOrDefaultAsync(a =>  a.Id == request.Id && a.Password == request.OldPassword);
//            if (account == null)
//            {
//                return BResult.Failure("Mật khẩu cũ không chính xác");
//            }
//            await _accountRepository.ChangePassword(request.Id, request.OldPassword, request.NewPassword);
//            return BResult.Success();
//        }
//    }
//}
