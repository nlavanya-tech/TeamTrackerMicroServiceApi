using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.Entities;

namespace UsersMicroservice.DataLayer.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<Users> users { get; }

    }
}
