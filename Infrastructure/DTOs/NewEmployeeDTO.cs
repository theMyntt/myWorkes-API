using System;
using System.ComponentModel.DataAnnotations;
using myWorkes.Domain.Enums;

namespace myWorkes.Infrastructure.DTOs
{
	public class NewEmployeeDTO
	{
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public EEmployeerType Type { get; set; }

        public List<string>? AllowedSystems { get; set; }
    }
}

