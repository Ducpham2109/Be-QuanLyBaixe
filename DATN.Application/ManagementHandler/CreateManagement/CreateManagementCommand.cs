
using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.ManagementRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.ManagementHandler.CreateManagement
{
    public class CreateManagementCommand : IRequest<BResult>
    {


        public string Username { get; set; }
        public int ParkingCode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class CreateManagementCommandHandler : IRequestHandler<CreateManagementCommand, BResult>
    {
        private readonly IManagementRepository _MaRepository;

        public CreateManagementCommandHandler(IManagementRepository MaRepository)
        {
            _MaRepository = MaRepository;
        }

        public async Task<BResult> Handle(CreateManagementCommand request, CancellationToken cancellationToken)
        {
            var entity = ManagementMapper.Mapper.Map<Managements>(request);
            var role = await _MaRepository.GetRoleByUserName(request.Username);
            var usernameExists = await _MaRepository.CheckUsernameExists(request.Username);

          
            if (role != 1)
            {
                return BResult.Failure("Chọn tài khoản có quyền Admin ");

            }
            else
            {
                if (usernameExists)
                {
                    return BResult.Failure("Admin này đã được thêm quyền");
                }
                else
                {
                    var result = await _MaRepository.AddManagementAsync(entity, request.Username);
                    return BResult.Success();
                }
            }
        }
    }
}
