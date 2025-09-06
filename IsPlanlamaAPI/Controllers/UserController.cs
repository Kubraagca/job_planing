using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsPlanlamaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _user.GetAll();
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDto update)
        {
            _user.Update(update);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _user.Delete(id);
            return Ok("Sillme işlemi başarılı");

        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto create)
        {
            _user.Add(create);
            return Ok("ekleme işlemi başarılı");
        }

        [HttpGet("GetById")]
        public IActionResult GetUser(int id)
        {
            var result = _user.GetById(id);
            return Ok(result);
        }
    }
}
