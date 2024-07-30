using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Domain.Models;
using myWorkes.Infrastructure.DTOs;
using myWorkes.Infrastructure.Repositories;

namespace myWorkes.Application.UseCases
{
	public class GetAllEmployeeUseCase : Controller, IUseCaseService<GetAllEmployeeDTO, GetAllEmployeeResponseModel>
	{
        private readonly EmployeeRepository Repository;

        public GetAllEmployeeUseCase(MongoDbService Service)
		{
            Repository = new(Service);
		}

        public async Task<ActionResult<GetAllEmployeeResponseModel>> Run(GetAllEmployeeDTO Dto)
        {
            if (Dto.Limit < 1 || Dto.Page < 1)
            {
                return BadRequest(new StandardResponse("Limit/Page needs to be greater than 1", 400));
            }

            if (Dto.Limit > 100)
            {
                return BadRequest(new StandardResponse("Limit needs to be lower than 100", 400));
            }

            var users = await Repository.Read(Dto.Page, Dto.Limit);
            var totalCount = await Repository.TotalCount();
            var totalPages = (int)Math.Ceiling(totalCount / (double)Dto.Limit);

            if (users.Value == null)
            {
                return NotFound(new StandardResponse("No users found", 404));
            }

            return Ok(new GetAllEmployeeResponseModel {
                Users = users.Value,
                Page = Dto.Page,
                Pages = totalPages
            });
        }
    }
}

