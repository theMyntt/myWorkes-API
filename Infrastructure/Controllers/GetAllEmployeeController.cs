﻿using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Application.UseCases;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Domain.Models;
using myWorkes.Infrastructure.DTOs;

namespace myWorkes.Infrastructure.Controllers
{
    [Route("/api/employee")]
    [Tags("Employee Search")]
	public class GetAllEmployeeController : Controller, IControllerService<GetAllEmployeeDTO, GetAllEmployeeResponseModel>
	{
        private readonly GetAllEmployeeUseCase UseCase;

		public GetAllEmployeeController(MongoDbService Service)
		{
            UseCase = new(Service);
		}

        [HttpGet("get")]
        public async Task<ActionResult<GetAllEmployeeResponseModel>> Perform([FromQuery] GetAllEmployeeDTO Dto)
        {
            return await UseCase.Run(Dto);
        }
    }
}

