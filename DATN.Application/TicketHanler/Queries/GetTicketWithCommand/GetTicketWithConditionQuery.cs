using DATN.Application.Models;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using DATN.Infastructure.Repositories.TicketRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.TicketHanler.Queries.GetTicketWithCommand
{
    public class GetTicketWithConditionQuery : IRequest<GetTicketWithConditionResponse>
    {
        //public GetAllAccountWithConditionQuery(string search)
        //{
        //	Search = search;
        //}
        public int IDCard { get; set; }


    }
    public class GetTicketWithConditionResponse
    {
  
        public int Monney { get; set; }

    }

    public class GetTicketWithConditionQueryHandler : IRequestHandler<GetTicketWithConditionQuery, GetTicketWithConditionResponse>
    {
        private readonly ITicketRepository _EntryVehiclesRepository;

        public GetTicketWithConditionQueryHandler(ITicketRepository EntryVehiclesRepository)
        {
            _EntryVehiclesRepository = EntryVehiclesRepository;
        }
        public async Task<GetTicketWithConditionResponse>Handle(GetTicketWithConditionQuery request, CancellationToken cancellationToken)
        {
            var checkID = await _EntryVehiclesRepository.CheckIDCardExists(request.IDCard);
            if (checkID)
            {
                var entity = await _EntryVehiclesRepository.GetTicketWithConditionQuery(request.IDCard);
                GetTicketWithConditionResponse response = new GetTicketWithConditionResponse();
              
                response.Monney = entity.Monney;
                return response;
            }
            else
            {
                throw new Exception("Không tìm thấy IDCard."); // Ném ngoại lệ với thông báo lỗi
            }

        }
        
            //return results;
        }

    }


