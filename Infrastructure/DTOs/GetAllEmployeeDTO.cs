using System;
using System.ComponentModel.DataAnnotations;

namespace myWorkes.Infrastructure.DTOs
{
	public class GetAllEmployeeDTO
	{
		[Required]
		public int Page { get; set; }

		[Required]
		public int Limit { get; set; }
	}
}

