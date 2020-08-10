using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsMicroservice.Entities;

namespace TeamsMicroservice.BusinessLayer.Services.Repository
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Teams>> TeamReadAsync();
        Task<Teams> TeamCreateAsync(Teams teams);
        Task<Teams> TeamUpdateAsync(Teams teams);
        Task<bool> TeamDeleteAsync(string teamname);
    }
}
