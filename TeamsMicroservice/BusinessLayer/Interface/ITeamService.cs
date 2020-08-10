using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsMicroservice.Entities;

namespace TeamsMicroservice.BusinessLayer.Interface
{
    public interface ITeamService
    {
        public Task<IEnumerable<Teams>> TeamReadAsync();
        public Task<Teams> TeamCreateAsync(Teams teams);
        public Task<Teams> TeamUpdateAsync(Teams teams);
        public Task<bool> TeamDeleteAsync(string teamname);
    }
}
