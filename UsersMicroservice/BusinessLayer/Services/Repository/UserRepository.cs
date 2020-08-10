using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.DataLayer.Context;
using UsersMicroservice.Entities;

namespace UsersMicroservice.BusinessLayer.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDbContext _context;
        public UserRepository(IMongoDbContext context)
        {
            _context = context;
        }
        //Get All UserNames
        public async Task<IEnumerable<Users>> GetAllUserName()
        {
            var users = await _context.users.Find(user => true).ToListAsync();
            return users;
        }
        //Get All Users details
        public async Task<IEnumerable<Users>> UserReadAsync()
        {
            var users = await _context.users.Find(user => true).ToListAsync();
            return users;

        }
        //Add user into Inmemory Db and return user
        public async Task<Users> UserCreateAsync(Users users)
        {

            await _context.users.InsertOneAsync(users);

            return users;
        }
        //Update user into Inmemory Db and return user 
        public async Task<Users> UserUpdateAsync(Users user)
        {
            ReplaceOneResult updateResult = await _context.users.ReplaceOneAsync(filter: g => g.Email == user.Email, replacement: user);
            return user;
        }
        //Delete team from INmemory Db and return teams
        public async Task<bool> UserDeleteAsync(string email)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.Email, email);
            DeleteResult deleteResult = await _context.users.DeleteOneAsync(filter);
            bool result = deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            return result;

        }
    }
}
