using AutoMapper;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.ManagementHandler.CreateManagement;
using DATN.Application.ParkingHandler.Commam.CreateParking;
using DATN.Application.ParkingHandler.Commam.UpdateParking;
using DATN.Application.ParkingHandler.Queries;
using DATN.Application.ParkingHandler.Queries.GetAccountPaging;
using DATN.Application.ParkingHandler.Queries.GetParkingPagingWithConditionQuery;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
    public class ParkingMapperProfile : Profile
    {
        public ParkingMapperProfile()
        {
            CreateMap<Parkings, CreateParkingCommand>().ReverseMap();
            CreateMap<Parkings, GetParkingResponse>().ReverseMap();
            CreateMap<Parkings, GetParkingPagingResponse>().ReverseMap();
            CreateMap<Parkings, GetParkingPagingWithConditionQueryResponse>().ReverseMap();

            CreateMap<Parkings, UpdateParkingCommand>().ReverseMap(); 

        }
    }
}
