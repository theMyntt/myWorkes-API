using System;
using myWorkes.Domain.Aggregates;

namespace myWorkes.Domain.Models
{
	public class GetAllEmployeeResponseModel
	{
		public required IEnumerable<EmployeeAggregate> Users { get; set; }
		public int Page { get; set; }
		public int Pages { get; set; }
	}
}

