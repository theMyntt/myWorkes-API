using System;
using Microsoft.AspNetCore.Mvc;
using myWorkes.Domain.Aggregates;

namespace myWorkes.Core
{
	public interface IRepositoryService
	{
		Task<ActionResult<IEnumerable<EmployeeAggregate>>> Filter(List<FiltersRoot> filters, int page);
		Task<ActionResult<EmployeeAggregate>> Find(List<FiltersRoot> filters);
		Task<ActionResult<StandardResponse>> Create(EmployeeAggregate employee);
		Task<ActionResult<StandardResponse>> Edit(EmployeeAggregate employee);
		Task<ActionResult<StandardResponse>> Delete(EmployeeAggregate employee);
	}
}

