using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AddCourseDto:IDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public int Credit { get; set; }
        public int Passinggrade { get; set; }
    }
}
