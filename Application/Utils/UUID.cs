using System;
namespace myWorkes.Application.Utils
{
	public class UUID
	{
		public static string generate()
		{
			return Guid.NewGuid().ToString();
		}
	}
}

