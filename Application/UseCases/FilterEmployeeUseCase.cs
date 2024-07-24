using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Application.Services;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Infrastructure.DTOs;
using myWorkes.Infrastructure.Repositories;

namespace myWorkes.Application.UseCases
{
	public class FilterEmployeeUseCase : Controller, IUseCaseService<FilterEmployeeDTO, IEnumerable<EmployeeAggregate>>
	{
        private readonly EmployeeRepository Repository;

        public FilterEmployeeUseCase(MongoDbService Service)
        {
            Repository = new(Service);
        }

        public async Task<ActionResult<IEnumerable<EmployeeAggregate>>> Run(FilterEmployeeDTO Dto)
        {
            if (Dto.Page < 1)
            {
                return BadRequest(new StandardResponse("Bad Request", 400));
            }

            List<FiltersRoot> filters = new();
            string[] fields = { "name", "email", "phone" };

            if (Dto.Search != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    filters.Add(new FiltersRoot
                    {
                        Field = fields[i],
                        Value = Dto.Search
                    });
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Dto.Email))
                {
                    filters.Add(new FiltersRoot { Field = "email", Value = Dto.Email });
                }

                if (!string.IsNullOrEmpty(Dto.Name))
                {
                    filters.Add(new FiltersRoot { Field = "name", Value = Dto.Name });
                }

                if (!string.IsNullOrEmpty(Dto.Phone))
                {
                    filters.Add(new FiltersRoot { Field = "phone", Value = Dto.Phone });
                }
            }

            return await Repository.Filter(filters, Dto.Page);
        }
    }
}

