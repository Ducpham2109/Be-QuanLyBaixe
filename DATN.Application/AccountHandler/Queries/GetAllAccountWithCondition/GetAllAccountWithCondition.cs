using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAllAccountWithCondition
{
    public class GetAllAccountWithConditionQuery : IRequest<BResult<BPaging<GetAllAccountWithConditionResponse>>>
    {
        //public GetAllAccountWithConditionQuery(string search)
        //{
        //	Search = search;
        //}
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
    public class GetAllAccountWithConditionResponse
    {
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

    }

    public class GetAllAccountWithConditionQueryHandler : IRequestHandler<GetAllAccountWithConditionQuery, BResult<BPaging<GetAllAccountWithConditionResponse>>>
    {
        private readonly IAccountRepository _AccountRepository;

        public GetAllAccountWithConditionQueryHandler(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }
        public async Task<BResult<BPaging<GetAllAccountWithConditionResponse>>> Handle(GetAllAccountWithConditionQuery request, CancellationToken cancellationToken)
        {
            var Accounts = await _AccountRepository.GetAllAccountWithCondition(request.Search);

            var results = new List<GetAllAccountWithConditionResponse>();

            // Convert each Account to a response object
            foreach (var Account in Accounts)
            {
                var result = new GetAllAccountWithConditionResponse();
              
                result.UserName = Account.Username;
                result.Password = Account.Password;
                result.Role = Account.Role;
                
                results.Add(result);
            }
            var total = results.Count();
            var item = results.Skip(request.Skip).Take(request.PageSize).ToList();
            var resultFinal = new BPaging<GetAllAccountWithConditionResponse>()
            {
                Items = item,
                TotalItems = total

            };

            return BResult<BPaging<GetAllAccountWithConditionResponse>>.Success(resultFinal);
            //return results;
        }

    }
}
