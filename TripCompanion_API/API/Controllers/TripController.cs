using API.Mappers;
using API.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TripController : ControllerBase
    {
        private TripService tripService;
        public TripController(TripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(tripService.GetAll().Select(t => t.ToApi()));
        }

        [HttpGet]
        [Route("GetAllTripByUser/{idUser}")]
        public IActionResult GetAllTripByUser(int idUser)
        {
            return Ok(tripService.GetAllTripByUser(idUser).Select(t => t.ToApi()));
        }

        [HttpGet]
        [Route("GetTripById/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(tripService.GetById(id).ToApi());
        }


        [HttpGet]
        [Route("{Tripname}")]
        public IActionResult GetByName(string Tripname)
        {
            return Ok(tripService.GetByName(Tripname).ToApi());
        }

        [HttpPost]
        public IActionResult AddTrip(TripApiModel Trip)
        {
            if (tripService.Insert(Trip.ToDto()))
            {
                return Ok(Trip);
            }
            else
            {
                return new BadRequestObjectResult(Trip); // return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateTrip(TripApiModel Trip)
        {
            if (tripService.Update(Trip.ToDto()))
            {
                return Ok(Trip);
            }
            else
            {
                return new BadRequestObjectResult(Trip);  //return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteTrip(int id)
        {
            if (tripService.Delete(id))
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
