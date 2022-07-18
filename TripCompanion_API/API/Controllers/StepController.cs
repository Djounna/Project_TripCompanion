using API.Mappers;
using API.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {

        private StepService stepService;
        public StepController(StepService stepService)
        {
            this.stepService = stepService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(stepService.GetAll().Select(s => s.ToApi()));
        }

        [HttpGet]
        [Route("GetAllStepByTrip/{idTrip}")]
        public IActionResult GetAllStepByTrip(int idTrip)
        {
            return Ok(stepService.GetAllStepByTrip(idTrip).Select(s => s.ToApi()));
        }


        [HttpGet]
        [Route("{Stepname}")]
        public IActionResult GetByName(string Stepname)
        {
            return Ok(stepService.GetByName(Stepname).ToApi());
        }
        [HttpPost]
        public IActionResult AddStep(StepApiModel Step)
        {
            if (stepService.Insert(Step.ToDto()))
            {
                return Ok(Step);
            }
            else
            {
                return new BadRequestObjectResult(Step); // return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateStep(StepApiModel Step)
        {
            if (stepService.Update(Step.ToDto()))
            {
                return Ok(Step);
            }
            else
            {
                return new BadRequestObjectResult(Step);  //return BadRequest();
            }
        }

        [HttpDelete]

        public IActionResult DeleteStep(int id)
        {
            if (stepService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
