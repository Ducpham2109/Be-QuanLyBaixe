using AutoMapper;
using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.EntryVehiclesHandler.CreateEntryVehicles;

using DATN.Application.EntryVehiclesHandler.Queries.GetEntryVehiclesPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
    public class EntryVehiclesMapperProfile : Profile
    {
        public EntryVehiclesMapperProfile()
        {
            CreateMap<EntryVehicles, CreateEntryVehiclesCommand>().ReverseMap();
            //CreateMap<Accounts, UpdateAccountPassCommand>().ReverseMap();
            //CreateMap<Accounts, UpdateAccountCommand>().ReverseMap();

            CreateMap<EntryVehicles, GetEntryVehiclesPagingResponse>().ReverseMap();
            ////CreateMap<Accounts, GetAccountByImeiResponse>().ReverseMap();
            //CreateMap<Accounts, GetAccountMultipleImeiResponse>().ReverseMap();
            //CreateMap<Accounts, GetAccountMultipleRoleResponse>().ReverseMap();

        }
    }
}
