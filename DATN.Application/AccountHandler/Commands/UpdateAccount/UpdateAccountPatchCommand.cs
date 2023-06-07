//using DATN.Application.Models;
//using DATN.Infastructure.Repositories.AccountRepository;
//using MediatR;
//using Microsoft.AspNetCore.JsonPatch;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace DATN.Application.AccountHandler.Commands.UpdateAccount
//{
//	public class UpdateAccountPatchCommand : IRequest<BResult>
//	{ 
//		public UpdateAccountPatchCommand(int id, JsonPatchDocument requestPatch)
//		{
//			Id = id; 
//			RequestPatch = requestPatch;
//		}
//		public int Id { get; set; }
//		public JsonPatchDocument RequestPatch { get; set; }
//		//public string Op { get; set; }
//		//public string Path { get; set; }
//		//public string Value { get; set; }
//	}

//	public class UpdateAccountPatchCommandHandler : IRequestHandler<UpdateAccountPatchCommand, BResult>
//	{
//		private readonly IAccountRepository _accountRepository;

//		public UpdateAccountPatchCommandHandler(IAccountRepository accountRepository)
//		{
//			_accountRepository = accountRepository;

//		}

//		public async Task<BResult> Handle(UpdateAccountPatchCommand request, CancellationToken cancellationToken)
//		{
//			//var entity = WifiMapper.Mapper.Map<Wifi>(request);

//			await _accountRepository.UpdateAccountPatchAsync(request.Id, request.RequestPatch);
//			return BResult.Success();
//		}
//	}
//}
