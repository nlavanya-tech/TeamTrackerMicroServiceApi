using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.Entities;

namespace UsersMicroservice.DataLayer.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        //Create context of Mongo DB
        private readonly IMongoDatabase _db;

        //get mongodb connection string values options from app settings
        public MongoDbContext(IOptions<MongoDbSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        //Get All teams Collection from MongoDB

        public IMongoCollection<Users> users => _db.GetCollection<Users>("users");
    }

}
