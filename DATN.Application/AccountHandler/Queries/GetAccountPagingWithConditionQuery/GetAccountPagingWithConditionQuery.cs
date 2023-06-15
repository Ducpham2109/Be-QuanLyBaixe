using DATN.Application.AccountHandler.Queries.GetAccountPaging;
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

namespace DATN.Application.AccountHandler.Queries.GetAccountPagingWithConditionQuery
{
    public class GetAccountPagingWithConditionQuery : IRequest<BResult<BPaging<GetAccountPagingWithConditionQueryResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public int role { get; set; }
    }
    public class GetAccountPagingWithConditionQueryResponse
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
    public class GetAccountPagingWithConditionQueryHandler : IRequestHandler<GetAccountPagingWithConditionQuery, BResult<BPaging<GetAccountPagingWithConditionQueryResponse>>>
    {
        private readonly IAccountRepository _accRepository;

        public GetAccountPagingWithConditionQueryHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<BResult<BPaging<GetAccountPagingWithConditionQueryResponse>>> Handle(GetAccountPagingWithConditionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.BGetPagingByRoleAsync(request.Skip, request.PageSize, request.role);
            var items = AccountMapper.Mapper.Map<List<GetAccountPagingWithConditionQueryResponse>>(entities);
            var total = await _accRepository.BGetTotalAsync();
            //items.ForEach(item =>
            //{
            //    item.Role = request.role;
            //    // Thêm điều kiện cho các thuộc tính khác tùy theo yêu cầu của bạn
            //});
            var filteredItems = items.Where(item => item.Role == request.role).ToList();

            var result = new BPaging<GetAccountPagingWithConditionQueryResponse>()
            {
                Items = filteredItems,

                TotalItems = total,
            };
            return BResult<BPaging<GetAccountPagingWithConditionQueryResponse>>.Success(result);
        }
    }
}
