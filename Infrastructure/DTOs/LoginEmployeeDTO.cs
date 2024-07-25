using System;
using System.ComponentModel.DataAnnotations;

namespace myWorkes.Infrastructure.DTOs
{
	public class LoginEmployeeDTO
	{
		[Required]
		public required string Email { get; set; }

		[Required]
		public required string Password { get; set; }
	}
}

