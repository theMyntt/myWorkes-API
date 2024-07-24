using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace myWorkes.Core
{
	public class EntityRoot
	{
		[BsonId]
		[BsonElement("_id")]
		[BsonRepresentation(BsonType.String)]
		public required string Id { get; set; }

		[BsonElement("createdAt")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}

