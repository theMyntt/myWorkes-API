using System;
using Microsoft.AspNetCore.Mvc;

namespace myWorkes.Core
{
	public interface IRepositoryService<Aggregate>
	{
		Task<ActionResult<IEnumerable<Aggregate>>> Filter(List<FiltersRoot> filters, int page);
		Task<ActionResult<Aggregate>> Find(List<FiltersRoot> filters);
		Task<ActionResult<StandardResponse>> Create(Aggregate employee);
		Task<ActionResult<StandardResponse>> Edit(Aggregate employee);
		Task<ActionResult<StandardResponse>> Delete(Aggregate employee);
	}
}

