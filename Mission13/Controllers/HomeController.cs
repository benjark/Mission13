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
        

        //Constructor
        public HomeController(IBowlersRepository temp)
        {
            Repo = temp;
        }

        public IActionResult Index()
        {
            var bowling = Repo.Bowlers
                //.Include(x => Bowler)

                .ToList();

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

            Repo.CreateBowler(x);
            Repo.SaveBowler(x);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            Bowler bowl = Repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            Repo.DeleteBowler(bowl);
            return RedirectToAction("Index");
        }
    }
}