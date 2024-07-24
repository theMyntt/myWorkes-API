using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using myWorkes.Core;
using myWorkes.Domain.Enums;

namespace myWorkes.Infrastructure.Schema
{
	public class Employee : EntityRoot
	{
		[BsonElement("name")]
		[BsonRepresentation(BsonType.String)]
		public required string Name { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public required string Email { get; set; }

        [BsonElement("phone")]
        [BsonRepresentation(BsonType.String)]
        public string? Phone { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]
        public required string Password { get; set; }

        [BsonElement("type")]
        [BsonRepresentation(BsonType.String)]
        public required EEmployeerType Type { get; set; }

        [BsonElement("allowedSystems")]
        [BsonRepresentation(BsonType.Array)]
        public List<string>? AllowedSystems { get; set; }
    }
}

