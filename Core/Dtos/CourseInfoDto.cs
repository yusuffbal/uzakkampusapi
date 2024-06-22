using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CourseInfoDto:IDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseTitle { get; set; }
    }
}
