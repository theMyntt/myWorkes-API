using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Core;
using myWorkes.Domain.Models;
using myWorkes.Infrastructure.DTOs;
using myWorkes.Infrastructure.Repositories;

namespace myWorkes.Application.UseCases
{
	public class LoginEmployeeUseCase : Controller, IUseCaseService<LoginEmployeeDTO, LoginResponseEmployeeModel> 
	{
        private readonly EmployeeRepository Repository;

		public LoginEmployeeUseCase(MongoDbService service)
		{
            Repository = new(service);
		}

        public async Task<ActionResult<LoginResponseEmployeeModel>> Run(LoginEmployeeDTO Dto)
        {
            List<FiltersRoot> filters = new();

            filters.Add(new FiltersRoot { Field = "email", Value = Dto.Email });
            filters.Add(new FiltersRoot { Field = "password", Value = Dto.Password });

            var aggregate = await Repository.Find(filters);

            if (aggregate.Value == null)
            {
                return NotFound(new StandardResponse("No employee found", 404));
            }

            return Ok(new LoginResponseEmployeeModel { Name = aggregate.Value.Name, Token = aggregate.Value.Id });
        }
    }
}

