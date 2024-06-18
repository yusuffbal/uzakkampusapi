using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class DashboardProgressDto
    {
        public string CourseName { get; set; }
        public string Teacher { get; set; }
        public int CourseParticipant { get; set; }
        public float midtermNote { get; set; }
        public float FinalNote { get; set; }
    }
}
