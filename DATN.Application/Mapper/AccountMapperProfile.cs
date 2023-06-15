using AutoMapper;
using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.AccountHandler.Queries.GetAccountPagingWithConditionQuery;
//using DATN.Application.AccountHandler.Commands.UpdateAccount;
//using DATN.Application.AccountHandler.Queries.GetAccount;
//using DATN.Application.AccountHandler.Queries.GetAccountByImei;
//using DATN.Application.AccountHandler.Queries.GetAccountByMultipleImei;
//using DATN.Application.AccountHandler.Queries.GetAccountMultipleRole;
//using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Core.Entities;

namespace DATN.Application.Mapper
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<Accounts, CreateAccountCommand>().ReverseMap();
            //CreateMap<Accounts, UpdateAccountPassCommand>().ReverseMap();
            CreateMap<Accounts, UpdateAccountCommand>().ReverseMap();
            CreateMap<Accounts, GetAccountResponse>().ReverseMap();
            CreateMap<Accounts, GetAccountPagingResponse>().ReverseMap();
            CreateMap<Accounts, GetAccountPagingWithConditionQueryResponse>().ReverseMap();

            //CreateMap<Accounts, GetAccountByImeiResponse>().ReverseMap();
            //CreateMap<Accounts, GetAccountMultipleImeiResponse>().ReverseMap();
            //CreateMap<Accounts, GetAccountMultipleRoleResponse>().ReverseMap();

        }
    }
}
