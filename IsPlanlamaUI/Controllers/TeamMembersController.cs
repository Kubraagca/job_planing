//using IsPlanlamaAPI.Business.Service;
//using IsPlanlamaAPI.Contract.Common.Request;
//using IsPlanlamaAPI.Contract.Common.Response;
//using IsPlanlamaAPI.Core.Entities;
//using Microsoft.AspNetCore.Mvc;


//namespace IsPlanlamaUI.Controllers
//{
//    public class TeamMembersController : Controller
//    {
//        private readonly TeamMemberService _teamMemberService;
//        private readonly TeamService _teamService;
//        private readonly UserService _userService;

//        public TeamMembersController(
//            TeamMemberService teamMemberService, 
//            TeamService teamService, 
//            UserService userService)
//        {
//            _teamMemberService = teamMemberService;
//            _teamService = teamService;
//            _userService = userService;
//        }

//        // Takım üyelerini listeleme
//        public IActionResult Index(int teamId)
//        {
//            var team = _teamService.GetById(teamId);
//            if (team == null) return NotFound();

//            ViewBag.Team = team;
//            var members = team.TeamMembers ?? new List<TeamMember>();
//            return View(members);
//        }


//        public IActionResult Add(int teamId)
//        {
//            if (teamId == 0) return BadRequest("Geçersiz takım.");

//            ViewBag.TeamId = teamId;
//            ViewBag.Users = _userService.GetAll();
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Add(int teamId, int userId)
//        {
//            if (teamId == 0 || userId == 0)
//            {
//                ModelState.AddModelError("", "Geçersiz takım veya kullanıcı seçimi.");
//                ViewBag.TeamId = teamId;
//                ViewBag.Users = _userService.GetAll();
//                return View();
//            }

//            var memberRequest = new TeamMemberRequestDTO
//            {
//                TeamId = teamId,
//                UserId = userId
//            };

//            _teamMemberService.Add(memberRequest);
//            return RedirectToAction("Index", new { teamId });
//        }

//        // Üye silme
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Delete(int id, int teamId)
//        {
//            _teamMemberService.Delete(id);
//            return RedirectToAction("Index", new { teamId });
//        }

//        public IActionResult ManageMembers(int teamId)
//        {
//            var members = _teamMemberService.GetTeamMembers(teamId) ?? new List<TeamMemberResponseDto>();
//            ViewBag.TeamId = teamId;

//            var allUsers = _teamMemberService.GetAllUsers() ?? new List<UserResponseDto>();
//            ViewBag.AllUsers = allUsers;

//            return View(members);

//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AddToTeam(int teamId, int userId)
//        {
//            if (teamId == 0 || userId == 0)
//                return BadRequest();

//            var request = new TeamMemberRequestDTO
//            {
//                TeamId = teamId,
//                UserId = userId
//            };

//            _teamMemberService.Add(request);
//            return RedirectToAction("ManageMembers", new { teamId });
//        }

//        // Üye silme
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult RemoveFromTeam(int id, int teamId)
//        {
//            _teamMemberService.Delete(id);
//            return RedirectToAction("ManageMembers", new { teamId });
//        }
//    }
//}

  