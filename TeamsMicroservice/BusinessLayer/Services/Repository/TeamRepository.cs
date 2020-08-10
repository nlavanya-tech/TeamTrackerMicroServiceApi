using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsMicroservice.Entities;
using TeamsMicroservice.DataLayer.Context;

namespace TeamsMicroservice.BusinessLayer.Services.Repository
{
    public class TeamRepository : ITeamRepository
    {
        //Creating mongoDb Instance
        private readonly IMongoDbContext _context;
        public TeamRepository(IMongoDbContext context)
        {
            _context = context;
        }

        //get team from mongodb
        public async Task<IEnumerable<Teams>> TeamReadAsync()
        {
            
            var teams = await _context.teams.Find(team => true).ToListAsync();
            return teams;
        }

        //Add team into Inmemory Db and return teams
        public async Task<Teams> TeamCreateAsync(Teams teams)
        {
            await _context.teams.InsertOneAsync(teams);

            return teams;
        }

        //Update team into Inmemory Db and return teams 
        public async Task<Teams> TeamUpdateAsync(Teams teams)
        {
            ReplaceOneResult updateResult = await _context.teams.ReplaceOneAsync(filter: g => g.TeamName == teams.TeamName, replacement: teams);
            return teams;
        }

        //Delete team from INmemory Db and return teams
        public async Task<bool> TeamDeleteAsync(string teamname)
        {
            FilterDefinition<Teams> filter = Builders<Teams>.Filter.Eq(m => m.TeamName, teamname);
            DeleteResult deleteResult = await _context.teams.DeleteOneAsync(filter);
            bool result = deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            return result;
        }
    }
}
