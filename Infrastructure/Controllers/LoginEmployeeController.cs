using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Application.UseCases;
using myWorkes.Core;
using myWorkes.Domain.Models;
using myWorkes.Infrastructure.DTOs;

namespace myWorkes.Infrastructure.Controllers
{
    [Route("/api/employee")]
    [Tags("Employee Auth")]
	public class LoginEmployeeController : Controller, IControllerService<LoginEmployeeDTO, LoginResponseEmployeeModel>  
	{
        private readonly LoginEmployeeUseCase UseCase;

        public LoginEmployeeController(MongoDbService service)
		{
            UseCase = new(service);
		}

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseEmployeeModel>> Perform([FromBody] LoginEmployeeDTO Dto)
        {
            return await UseCase.Run(Dto);
        }
    }
}

