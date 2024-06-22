using Core.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UserController(IUserService userService) : CustomBaseController
    {
        [Authorize]
        [HttpPost]
        [Route("GetCurrentUser")]

        public async Task<IActionResult> GetCurrentUser(LoginDto loginDto)
        {
            var result = await userService.GetCurrentUser(loginDto);

            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("GetTeacher")]

        public async Task<IActionResult> GetTeacher()
        {
            var result = await userService.GetTeacher();

            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("GetNotStudentCourse")]

        public async Task<IActionResult> GetStudent(int courseId)
        {
            var result = await userService.GetStudent(courseId);

            return ActionResultInstance(result);
        }
        [HttpPost]
        [Route("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var result = await userService.GetAllStudent();
            return ActionResultInstance(result);
        }

    }
}
