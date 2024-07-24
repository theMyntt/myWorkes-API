using System;
namespace myWorkes.Core
{
	public class StandardResponse
	{
		public string? Message { get; set; }
		public int StatusCode { get; set; }

		public StandardResponse() { }

		public StandardResponse(string message, int statusCode)
		{
			Message = message;
			StatusCode = statusCode;
		}
	}
}

