using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetDetails();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("rulesforadding")]
        public IActionResult RulesForAdding(Rental rental)
        {
            var result = _rentalService.RulesForAdding(rental);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
