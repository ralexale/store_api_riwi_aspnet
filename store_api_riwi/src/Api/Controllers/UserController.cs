using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Infrastructure.AbstractServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace store_api_riwi.src.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ICommonService<UserResponse, UserRequest> _userService;

        private IValidator<UserRequest> _userValidator;

        public UserController(ICommonService<UserResponse, UserRequest> userService, 
            IValidator<UserRequest> userValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResponse>> Get() => await _userService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById(int id)
        {
            var user = await _userService.GetById(id);

            return user == null ? NotFound() : Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create(UserRequest userRequest)
        {
            var validation = await _userValidator.ValidateAsync(userRequest);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var userResponse = await _userService.Create(userRequest);

            return CreatedAtAction(nameof(GetById), new { id = userResponse.Id}, userResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> Update(int id, UserRequest userRequest)
        {
            var validation = await _userValidator.ValidateAsync(userRequest);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var userResponse = await _userService.Update(id, userRequest);

            return userResponse == null ? NotFound() : Ok(userResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<UserResponse>> Delete(int id)
        {
            var userResponse = await _userService.Delete(id);

            return userResponse == null ? NotFound() : Ok(userResponse);
        }
    }
}
