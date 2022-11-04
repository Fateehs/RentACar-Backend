using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var newSuccessDataResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);
            return Ok(newSuccessDataResult);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {

            var result = _authService.Register(registerDTO, registerDTO.Password);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var newSuccessDataResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);
            return Ok(newSuccessDataResult);
        }
    }
}


