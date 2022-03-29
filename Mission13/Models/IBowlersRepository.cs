using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
       IQueryable<Bowler> Bowlers { get; }
        //Not sure about this bit
        IQueryable<Team> Teams { get; }

        object FirstOrDefault(Func<object, bool> p);

        public void SaveBowler(Bowler bowler);
        public void CreateBowler(Bowler bowler);
        public void DeleteBowler(Bowler bowler);
        
    }
}
