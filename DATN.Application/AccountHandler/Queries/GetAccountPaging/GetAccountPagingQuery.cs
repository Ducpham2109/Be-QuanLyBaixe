using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAccountPaging
{
    public class GetAccountPagingQuery : IRequest<BResult<BPaging<GetAccountPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAccountPagingResponse
    {
   
        public int Role { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class GetAccountPagingQueryHandler : IRequestHandler<GetAccountPagingQuery, BResult<BPaging<GetAccountPagingResponse>>>
    {
        private readonly IAccountRepository _accRepository;

        public GetAccountPagingQueryHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetAccountPagingResponse>>> Handle(GetAccountPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = AccountMapper.Mapper.Map<List<GetAccountPagingResponse>>(entities);
            var total = await _accRepository.BGetTotalAsync();

            var result = new BPaging<GetAccountPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetAccountPagingResponse>>.Success(result);
        }
    }
}
