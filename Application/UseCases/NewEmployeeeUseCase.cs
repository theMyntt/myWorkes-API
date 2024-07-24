using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Infrastructure.DTOs;
using myWorkes.Infrastructure.Repositories;

namespace myWorkes.Application.UseCases
{
	public class NewEmployeeeUseCase : Controller, IUseCaseService<NewEmployeeDTO, StandardResponse>
	{
        private readonly EmployeeRepository Repository;

        public NewEmployeeeUseCase(MongoDbService Service)
        {
            Repository = new(Service);
        }

        public async Task<ActionResult<StandardResponse>> Run(NewEmployeeDTO Dto)
        {
            EmployeeAggregate aggregate = new(Dto.Name, Dto.Email,Dto.Phone,Dto.Password,Dto.Type,Dto.AllowedSystems);

            return await Repository.Create(aggregate);
        }
    }
}

