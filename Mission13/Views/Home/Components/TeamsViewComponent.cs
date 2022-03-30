using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private ITeamsRepository repo { get; set; }

    public TeamsViewComponent(ITeamsRepository temp)
    {
        repo = temp;
    }
    public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];

            var t = repo.Teams;
             
            return View(t);
        }
    }
}