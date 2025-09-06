using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Core.Entities;
using IsPlanlamaAPI.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsPlanlamaUI.Controllers
{
    public class TakvimController : Controller
    {
        private readonly ITeam _teamService;
        private readonly IUser _userService;
        private readonly IPlan _planService;
    
       public TakvimController(ITeam teamService, IUser userService, IPlan planService)
        {
            _teamService = teamService;
            _userService = userService;
            _planService = planService;
        }
        public IActionResult Index(int? TeamId, int? UserId)
        {
            var teams = _teamService.GetAll();
            ViewBag.Teams = new SelectList(teams, "Id", "TeamName", TeamId);

            var users = _userService.GetAll();
            ViewBag.Users = new SelectList(users, "Id", "UserName", UserId);

            var plans = _planService.GetFilteredPlans(TeamId, UserId);

            return View(plans);
        }
    }
    
}