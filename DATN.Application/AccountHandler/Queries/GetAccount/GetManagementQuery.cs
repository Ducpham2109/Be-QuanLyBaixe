using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.ManagementRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAccount
{
    public class GetManagementQuery : IRequest<GetManagementResponse>
    {
        public string Username { get; set; }

        public GetManagementQuery(string usename)
        {
            Username = usename;
        }
    }
    public class GetManagementResponse
    {

        public int Role { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }

    public class GetManagementQueryHandler : IRequestHandler<GetManagementQuery, GetManagementResponse>
    {
        private readonly IManagementRepository _accRepository;

        public GetManagementQueryHandler(IManagementRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<GetManagementResponse> Handle(GetManagementQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accRepository.GetManagementByUsername(request.Username);
            var result = ManagementMapper.Mapper.Map<GetManagementResponse>(entity);
            return result;

        }
    }
}
