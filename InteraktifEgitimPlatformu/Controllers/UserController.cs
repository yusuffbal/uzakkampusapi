using Core.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]

    public class UserController(IUserService userService) : CustomBaseController
    {
        [HttpPost]
        [Route("GetCurrentUser")]

        public async Task<IActionResult> GetCurrentUser(LoginDto loginDto)
        {
            var result = await userService.GetCurrentUser(loginDto);

            return ActionResultInstance(result);
        }

    }
}
