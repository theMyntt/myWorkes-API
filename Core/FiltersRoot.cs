using System;
namespace myWorkes.Core
{
	public class FiltersRoot
	{
		public required string Field { get; set; }
		public required string Value { get; set; }

		public FiltersRoot() { }

		public FiltersRoot(string Field, string Value)
		{
			this.Field = Field;
			this.Value = Value;
		}
	}
}

