using System;
using System.ComponentModel.DataAnnotations;

namespace myWorkes.Infrastructure.DTOs
{
	public class FilterEmployeeDTO
	{
		public string? Search { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Phone { get; set; }

		[Required]
		public int Page { get; set; }
	}
}

