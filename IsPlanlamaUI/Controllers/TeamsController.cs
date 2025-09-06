using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Service;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;

using IsPlanlamaAPI.Contract.Common.Response.TeamDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UpdateTeamDto = IsPlanlamaAPI.Contract.Common.Request.TeamDtos.UpdateTeamDto;



namespace IsPlanlamaUI.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeam _teamService;
        private readonly IUser _userService;

        public TeamsController(ITeam teamService, IUser userService)
        {
            _teamService = teamService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var teams = _teamService.GetAll();
            return View(teams);
        }

        public IActionResult Details(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(CreateTeamDto model)
        {
            if (ModelState.IsValid)
            {
                _teamService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateTeamDto
            {
                TeamName = team.TeamName
              
            };

            return View(updateDto);
        }

        
        [HttpPost]
        public IActionResult Edit(int id, UpdateTeamDto model)
        {
            if (ModelState.IsValid)
            {
                _teamService.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _teamService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageMembers(int teamId)
        {
           
            var members = _teamService.GetTeamMembers(teamId);

         
            var allUsers = _userService.GetAll();
            var availableUsers = allUsers
                          .Where(u => !members.Any(m => m.Id == u.Id))
                          .ToList();

            ViewBag.TeamId = teamId;
            ViewBag.AllUsers = availableUsers;
            ViewBag.TeamId = teamId;
            ViewBag.AllUsers = allUsers;

            return View(members); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToTeam(int teamId, int userId)
        {
            _teamService.AddUserToTeam(teamId, userId);
            return RedirectToAction("ManageMembers", new { teamId });
        }

        // Takımdan kullanıcı çıkar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromTeam(int teamId, int userId)
        {
            _teamService.RemoveUserFromTeam(teamId, userId);
            return RedirectToAction("ManageMembers", new { teamId });
        }

    }
}