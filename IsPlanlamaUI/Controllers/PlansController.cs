using IsPlanlamaAPI.Business.Abstract;

using IsPlanlamaAPI.Contract.Common.Request.PlanDtos;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;



namespace IsPlanlamaUI.Controllers
{
    public class PlansController : Controller
    {
        private readonly IPlan _planService;
        private readonly ITeam _teamService;
        private readonly IUser _userService;

        public PlansController(IPlan planService, ITeam teamService, IUser userService)
        {
            _planService = planService;
            _teamService = teamService;
            _userService = userService;
        }

        // Tüm planları listele
        public IActionResult Index()
        {
            ViewBag.StatusList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Planlandı", Value = "Planlandi" },
        new SelectListItem { Text = "Onaylandı", Value = "Onaylandi" },
        new SelectListItem { Text = "İptal Edildi", Value = "IptalEdildi" },
        new SelectListItem { Text = "Revizyon İste", Value = "RevizyonIstendi" },
        new SelectListItem { Text = "Tamamlandı", Value = "Tamamlandi" }
    };
            var plans = _planService.GetAll();
            return View(plans);
        }


        public IActionResult Create()
        {
            var teams = _teamService.GetAll();
            ViewBag.Teams = teams.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Id} - {t.TeamName}"
            }).ToList();

            var users = _userService.GetAll();
            ViewBag.Users = users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.Id} - {u.UserName} {u.Surname}"
            }).ToList();

            var plans = _planService.GetAll();
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreatePlanDtos planDto)

        {
            if (!ModelState.IsValid)
                return View(planDto);

            _planService.AddPlan(planDto);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _planService.Delete(id);
            return RedirectToAction("Index");
        }

   

        public IActionResult Update(int id)
        {
            var plan = _planService.GetById(id);
            if (plan == null) return NotFound();

            ViewBag.StatusList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Planlandı", Value = "Planlandi" },
        new SelectListItem { Text = "Onaylandı", Value = "Onaylandi" },
        new SelectListItem { Text = "İptal Edildi", Value = "IptalEdildi" },
        new SelectListItem { Text = "Revizyon İste", Value = "RevizyonIstendi" },
        new SelectListItem { Text = "Tamamlandı", Value = "Tamamlandi" }
    };

            return View(plan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UpdatePlanDtos request)
        {
           
                _planService.Update(request);
                return Ok("Plan başarıyla güncellendi");
            
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status, string revizyonAciklama)
        {
            _planService.UpdateStatus(id, status, revizyonAciklama);
            return Ok();


        }
       
    }
}
