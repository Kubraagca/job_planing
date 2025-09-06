using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Contract.Common.Request;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsPlanlamaUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _userService;

        public UsersController(IUser userService)
        {
            _userService = userService;
        }

     
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }


        [HttpGet]
        public IActionResult Create()
        {
            // Dropdown için sadece takımları alıyoruz
            var teams = _userService.GetAllTeams(); // Servis metodu
            ViewBag.Teams = teams.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Id} - {t.TeamName}"
            }).ToList();

            return View(); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserDto request)
        {
            if (!ModelState.IsValid)
            {
                var teams = _userService.GetAllTeams();
                ViewBag.Teams = teams.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = $"{t.Id} - {t.TeamName}"
                }).ToList();

                return View(request);
            }

            _userService.Add(request);
            return RedirectToAction("Index");
        }

      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

       
            var teams = _userService.GetAllTeams();
            ViewBag.Teams = teams.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Id} - {t.TeamName}"
            }).ToList();

            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateUserDto request)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            _userService.Update(request);
            return RedirectToAction("Index");
        }

        // POST: /Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddToTeam(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            var teams = _userService.GetAllTeams();
            ViewBag.Teams = teams.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Id} - {t.TeamName}"
            }).ToList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToTeam(int id, int teamId)
        {
            _userService.AddToTeam(id, teamId);
            return RedirectToAction("Index");
        }
    }
}
