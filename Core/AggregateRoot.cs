using System;
namespace myWorkes.Core
{
	public class AggregateRoot
	{
		public required string Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}

