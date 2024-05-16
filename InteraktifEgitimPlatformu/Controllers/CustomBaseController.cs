using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace WebAPI.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        public IActionResult ActionResultInstance<T>(IEnumerable<T> response) where T : class
        {
            return new ObjectResult(response);
        }

        public IActionResult ActionResultInstance<T>(ResponseCount<T> response) where T : struct
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
