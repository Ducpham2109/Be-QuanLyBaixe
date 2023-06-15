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
using static DATN.Infastructure.Repositories.AccountRepository.AccountRepository;

namespace DATN.Application.AccountHandler.Queries.GetAccountPaging
{
    public class GetAccountPagingQuery : IRequest<List<GetAccountPagingResponse>>
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
        public int? ParkingCode { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class GetAccountPagingQueryHandler : IRequestHandler<GetAccountPagingQuery, List<GetAccountPagingResponse>>
    {
        private readonly IAccountRepository _accRepository;

        public GetAccountPagingQueryHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }
        public async Task<List<GetAccountPagingResponse>> Handle(GetAccountPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accRepository.BGetPagingAsync(request.Skip, request.PageSize);
            //var items = AccountMapper.Mapper.Map<List<GetAccountPagingResponse>>(entities);
            List<GetAccountPagingResponse> entitiesList = new List<GetAccountPagingResponse>();

            foreach (var item in entities)
            {
                var entity = new GetAccountPagingResponse
                {
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    UserName = item.UserName,
                    Password = item.Password,
                    ParkingCode= item.ParkingCode,
                    Role = item.Role,
                };

                entitiesList.Add(entity);
            }

            return entitiesList;
         
        }
    }
}
