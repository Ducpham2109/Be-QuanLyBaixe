

using AutoMapper;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.ManagementHandler.CreateManagement;
using DATN.Application.ParkingHandler.Queries;
using DATN.Core.Entities;

namespace DATN.Application.Mapper
{
    public class ManagementMapperProfile : Profile
    {
        public ManagementMapperProfile()
        {
            CreateMap<Managements, CreateManagementCommand>().ReverseMap();
            CreateMap<Managements, GetManagementResponse>().ReverseMap();


        }
    }
}
