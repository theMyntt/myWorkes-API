using System;
using Microsoft.AspNetCore.Mvc;

namespace myWorkes.Core
{
	public interface IUseCaseService<Input, Output>
	{
		Task<ActionResult<Output>> Run(Input Dto);
	}
}

