using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamsMicroservice.BusinessLayer.Interface;
using TeamsMicroservice.Entities;

namespace TeamsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;

        }
        // GET: api/Team
        [HttpGet]
        public async Task<IEnumerable<Teams>> GetAllTeams()
        {
            var teams = await _service.TeamReadAsync();

            return teams;
        }

        // POST: api/Team
        [HttpPost]
        public void AddNewTeam([FromBody] Teams teams)
        {
            _service.TeamCreateAsync(teams);
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public void UpdateTeam(string teamname, [FromBody] Teams teams)
        {
              _service.TeamUpdateAsync(teams);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteTeam(string teamname)
        {
             _service.TeamDeleteAsync(teamname);
        }
    }
}
