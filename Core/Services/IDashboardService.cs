using Core.Dtos;
using Entities.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDashboardService
    {
        public Task<Response<DashboardDto>> DashboardAnalysisAsync(int userId);
        public Task<Response<IEnumerable<DashboardProgressDto>>> DashboardCourseProgressAsync(int userId);


    }
}
