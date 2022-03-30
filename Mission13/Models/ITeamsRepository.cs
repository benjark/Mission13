using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Mission13.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get; }

        public void SaveTeam(Team t);
        public void AddTeam(Team t);
        public void DeleteTeam(Team t);
    }
}
