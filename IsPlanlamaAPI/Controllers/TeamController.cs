using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Core.Entities;
using IsPlanlamaAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IsPlanlamaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeam _team;

        public TeamController(ITeam team)
        {
            _team = team;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _team.GetAll();
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateTeam(UpdateTeamDto update)
        {
            _team.Update(update);
            return Ok("Güncelleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            _team.Delete(id);
            return Ok("Sillme işlemi başarılı");

        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDto create)
        {
            _team.Add(create);
            return Ok("ekleme işlemi başarılı");
        }
        [HttpGet("GetById")]
        public IActionResult GetTeam(int id)
        {
            var result = _team.GetById(id);
            return Ok(result);
        }
    }
}

