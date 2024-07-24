using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Application.UseCases;
using myWorkes.Core;
using myWorkes.Infrastructure.DTOs;

namespace myWorkes.Infrastructure.Controllers
{
    [Route("api/employee")]
    [Tags("Employee Management")]
    public class NewEmployeeController : Controller, IControllerService<NewEmployeeDTO, StandardResponse>
    {
        private readonly NewEmployeeeUseCase UseCase;

        public NewEmployeeController(MongoDbService Service)
        {
            UseCase = new(Service);
        }

        [HttpPost("new")]
        public Task<ActionResult<StandardResponse>> Perform([FromBody] NewEmployeeDTO Dto)
        {
            return UseCase.Run(Dto);
        }
    }
}

