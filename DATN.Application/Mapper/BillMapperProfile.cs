using AutoMapper;
using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.BillsHandler.Commands.CreateBills;
using DATN.Application.BillsHandler.Commands.Queries.GetBillPaging;
using DATN.Application.BillsHandler.Commands.Queries.GetBillPagingWithConditionQuery;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
    public class BillMapperProfile : Profile
    {
        public BillMapperProfile()
        {
            CreateMap<Bills, CreateBillCommand>().ReverseMap();
            CreateMap<Bills, GetBillPagingResponse>().ReverseMap();
            CreateMap<Bills, GetBillPagingWithConditionQueryResponse>().ReverseMap();
            CreateMap<Bills, GetVehiclesSentWithConditionQueryResponse>().ReverseMap();

        }
    }
}
