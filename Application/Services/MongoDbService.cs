using System;
using MongoDB.Driver;

namespace myWorkes.Application.Services
{
	public class MongoDbService
	{
		private IConfiguration _configuration;
		private IMongoDatabase _database;

		public MongoDbService(IConfiguration _configuration)
		{
			this._configuration = _configuration;

			var connectionString = _configuration.GetConnectionString("DbConnection");
			var mongoUri = MongoUrl.Create(connectionString);
			var mongoClient = new MongoClient(mongoUri);
			_database = mongoClient.GetDatabase(mongoUri.DatabaseName);
		}

		public IMongoDatabase? Database => _database;
	}
}

