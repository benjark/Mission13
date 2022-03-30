using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {

        private BowlingDbContext Context { get; set; }

        public EFTeamsRepository(BowlingDbContext temp)
        {
            Context = temp;
        }

        public IQueryable<Team> Teams => Context.Teams;


        public void SaveTeam(Team team)
        {
            if (team.TeamID == 0)
            {
                var max = Context.Teams.Max(x => x.TeamID);
                team.TeamID = (max + 1);
                Context.Update(team);
                Context.SaveChanges();
            }
            else
            {
                Context.Update(team);
                Context.SaveChanges();
            }
        }

        public void AddTeam(Team team)
        {
            if (team.TeamID == 0)
            {
                var max = Context.Bowlers.Max(x => x.BowlerID);
                team.TeamID = (max + 1);
                Context.Add(team);
                Context.SaveChanges();
            }
            else
            {
                Context.Add(team);
                Context.SaveChanges();
            }

        }

        public void DeleteTeam(Team t)
        {

            Context.Remove(t);
            Context.SaveChanges();
        }

     
    }
}
