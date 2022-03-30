using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {

        private BowlingDbContext Context { get; set; }

        public EFBowlersRepository(BowlingDbContext temp)
        {
            Context = temp;
        }

        public IQueryable<Bowler> Bowlers => Context.Bowlers;

        //not sure about this
        public IQueryable<Team> Teams => Context.Teams;

        //public object FirstOrDefault(Func<object, bool> p)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveBowler(Bowler bowler)
        {
            //Context.Update(bowler);
            Context.SaveChanges();
        }

        public void CreateBowler(Bowler bowler)
        {
            Context.Update(bowler);
            _ = Context.SaveChanges();
        }

        public void DeleteBowler(Bowler bowler)
        {
            Context.Remove(bowler);
            Context.SaveChanges();
        }
    }
}
