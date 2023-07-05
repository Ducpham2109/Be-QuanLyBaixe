using AutoMapper;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.ManagementHandler.CreateManagement;
using DATN.Application.TicketHanler.Commands.CreateTicket;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
    public class TicketMapperProfile : Profile
    {
        public TicketMapperProfile()
        {
            CreateMap<Tickets, CreateTicketCommand>().ReverseMap();
            //CreateMap<Managements, GetManagementResponse>().ReverseMap();


        }
    }
}
