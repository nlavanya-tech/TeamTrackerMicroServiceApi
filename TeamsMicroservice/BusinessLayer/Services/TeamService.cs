using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsMicroservice.BusinessLayer.Interface;
using TeamsMicroservice.BusinessLayer.Services.Repository;
using TeamsMicroservice.Entities;

namespace TeamsMicroservice.BusinessLayer.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
               
        }
        public async Task<IEnumerable<Teams>> TeamReadAsync()
        {
            var teams = await _repository.TeamReadAsync();
            return teams;
        }
        public async Task<Teams> TeamCreateAsync(Teams Teams)
        {
            var teams = await _repository.TeamCreateAsync(Teams);
            return teams;
        }
        public async Task<Teams> TeamUpdateAsync(Teams Teams)
        {
            var teams = await _repository.TeamUpdateAsync(Teams);
            return teams;

        }

        public async Task<bool> TeamDeleteAsync(string teamname)
        {
            bool result = await _repository.TeamDeleteAsync(teamname);
            return result;
        }

    }
}
