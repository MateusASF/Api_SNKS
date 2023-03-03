using Api_SNKS.Core.Intrerfaces.Users;
using Api_SNKS.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_SNKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("/user/profile{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetProfileUserAsync(string id)
        {
            var user = await _userService.GetProfileUserAsync(id);
            if (user == null)
            {
                return BadRequest("Usuário Não encontrado");
            }
            return Ok(user);
        }
    }
}
