using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Application.UseCases;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Infrastructure.DTOs;

namespace myWorkes.Infrastructure.Controllers
{
	[Route("/api/employee")]
	[Tags("Employee Search")]
	public class FilterEmployeeController : Controller, IControllerService<FilterEmployeeDTO, IEnumerable<EmployeeAggregate>>
	{
        private readonly FilterEmployeeUseCase UseCase;

        public FilterEmployeeController(MongoDbService Service)
        {
            UseCase = new(Service);
        }

        [HttpGet("filter")]
        public Task<ActionResult<IEnumerable<EmployeeAggregate>>> Perform(FilterEmployeeDTO Dto)
        {
            return UseCase.Run(Dto);
        }
    }
}

