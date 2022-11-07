using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getdtobyid")]
        public IActionResult GetDTOById(int id)
        {
            var result = _userService.GetDTOById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("updatefirstandlastname")]
        public IActionResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO)
        {
            var result = _userService.UpdateFirstAndLastName(updateFirstAndLastNameDTO);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("updateemail")]
        public IActionResult UpdateEmail(UpdateEmailDTO updateEmailDTO)
        {
            var result = _userService.UpdateEmail(updateEmailDTO);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }


        // *** TEST CONTROLLERS ***

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserbyid")]
        public IActionResult GetUserById(int userId)
        {
            var result = _userService.GetUserById(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

