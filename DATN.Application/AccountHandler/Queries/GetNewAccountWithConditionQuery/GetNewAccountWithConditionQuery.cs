using DATN.Application.AccountHandler.Queries.GetAllAccountWithCondition;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetNewAccountWithConditionQuery
{
  public class GetNewAccountWithConditionQuery : IRequest<GetNewAccountWithConditionQueryResponse>
    {
        public int Month { get; set; }
    }
    public class GetNewAccountWithConditionQueryResponse
    {
        public int TotalNewAccount { get; set; }
    }
    public class GetNewAccountWithConditionQueryHandler : IRequestHandler<GetNewAccountWithConditionQuery, GetNewAccountWithConditionQueryResponse>
    {
        private readonly IAccountRepository _AccountRepository;

        public GetNewAccountWithConditionQueryHandler(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }
        public async Task<GetNewAccountWithConditionQueryResponse> Handle(GetNewAccountWithConditionQuery request, CancellationToken cancellationToken)
        {
            var total = await _AccountRepository.GetNewAccountWithByMonth(request.Month);
            GetNewAccountWithConditionQueryResponse response = new GetNewAccountWithConditionQueryResponse();
            response.TotalNewAccount = total;

           
            return response;
            //return results;
        }

    }

}
