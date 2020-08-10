using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsMicroservice.Entities;

namespace TeamsMicroservice.DataLayer.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<Teams> teams { get; }
    }
}
