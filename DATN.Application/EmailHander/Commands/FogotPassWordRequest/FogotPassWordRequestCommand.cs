using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.EmailReponsitory;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EmailHander.Commands.FogotPassWordRequest
{
    public class ForgotPasswordRequestCommand : IRequest<BResult>
    {
        public string ToEmail { get; set; }
    }
    public class EmailRequestCommandHandler : IRequestHandler<ForgotPasswordRequestCommand, BResult>
    {
        private readonly IEmailService _emailService;
        private readonly IAccountRepository _accountRepository;
        public EmailRequestCommandHandler(IEmailService emailService, IAccountRepository deviceRepository)
        {
            _emailService = emailService;
            _accountRepository = deviceRepository;
        }
        public async Task<BResult> Handle(ForgotPasswordRequestCommand request, CancellationToken cancellationToken)
        {
            var checkEmail = _accountRepository.ChangePasswordAsync(request.ToEmail);
            string afterCheckEmail = checkEmail.Result;
            if (afterCheckEmail == "không tồn tại Email")
            {
                return BResult.Failure("Email không tồn tại,kiểm tra lại Email");

            }
            try
            {
                await _emailService.ForgotPassWordAsync(request.ToEmail, afterCheckEmail);
                return BResult.Success();
            }
            catch (Exception ex)
            {

                return BResult.Failure(ex.ToString());
            }
        }
    }
}