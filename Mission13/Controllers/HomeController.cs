using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository Repo { get; set; }
        private ITeamsRepository Repo2 { get; set; }

        public int BowlerID { get; set; }

        //Constructor
        public HomeController(IBowlersRepository temp, ITeamsRepository temp2)
        {
            Repo = temp;
            Repo2 = temp2;
        }
        
        public IActionResult Index(int teamid)
        {
            var bowling = Repo.Bowlers
                //.Include(x => Bowler)
                .Where(b => b.TeamID == teamid || teamid == 0)
                .ToList();

            if (teamid == 0)
            {
                ViewBag.Header = "All Teams";

            }
            else
            {
                ViewBag.Header = Repo2.Teams.Single(x => x.TeamID == teamid).TeamName;
            }

            return View(bowling);
        }
        [HttpGet]
        public IActionResult AddBowler()
        {
            Bowler bowler = new Bowler();

            return View(bowler);
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler x)
        {
            if (x.BowlerID == 0)
            {
                Repo.AddBowler(x);
            }
            else
            {
                Repo.SaveBowler(x);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowl = Repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            Repo.DeleteBowler(bowl);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var bowl = Repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            //Team team = Repo.Teams.SingleOrDefault(x => x.TeamID == a);
            
            return View("AddBowler",bowl);

        }
    }
}