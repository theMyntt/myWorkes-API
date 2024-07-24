using System;
using Microsoft.AspNetCore.Mvc;

namespace myWorkes.Core
{
	public interface IControllerService<Input, Output>
	{
		Task<ActionResult<Output>> Perform(Input Dto);
	}
}

