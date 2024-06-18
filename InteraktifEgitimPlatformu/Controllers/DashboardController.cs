using Core.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;  // Response<T> sınıfını bu namespace'den alabilirsiniz

namespace WebAPI.Controllers
{
    [Route("api/Dashboard")]
    [ApiController]
    public class DashboardController(IDashboardService dashboardService) : CustomBaseController
    {
        

        [HttpPost]
        [Route("DashboardAnaliyses")]
        public async Task<IActionResult> DashboardAnaliyses(int Id)
        {
            var result = await dashboardService.DashboardAnalysisAsync(Id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("DashboardProgressTable")]
        public async Task<IActionResult> DashboardProgressTable(int Id)
        {
            var result = await dashboardService.DashboardCourseProgressAsync(Id);
            return ActionResultInstance(result);
        }
    }
}
