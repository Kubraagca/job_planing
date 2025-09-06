using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Contract.Common.Request.PlanDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsPlanlamaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlan _service;

        public PlanController(IPlan service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result=_service.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdatePlan(UpdatePlanDtos updates)

        {
            _service.Update(updates);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeletePlan(int id)
        {
            _service.Delete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPost]
        public IActionResult CreatePlan(CreatePlanDtos createPlanDtos)
        {
            _service.AddPlan(createPlanDtos);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("GetById")]
        public IActionResult GetPlan(int id)
        { var result=  _service.GetById(id);
            return Ok(result);
        }

    }
}

