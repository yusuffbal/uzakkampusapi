using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AddCourseDocument :IDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string Document { get; set; }
    }
}
