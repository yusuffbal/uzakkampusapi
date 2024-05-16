using Core.Dtos;
using Core.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticationService authenticationService) : CustomBaseController
    {

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await authenticationService.CreateTokenAsync(loginDto);

            return ActionResultInstance(result);
        }

    }
}
