using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class DashboardDto : IDto
    {
        public int? CoursesCount { get; set; }
        public int? QuizCount { get; set; }
        public int? ExamsQount { get; set; } 
        public int? AssigmentsCount { get; set; }
        public List<Courses>? Courses { get; set; }

    }
}
