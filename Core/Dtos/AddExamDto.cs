using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AddExamDto:IDto
    {
        public string examName { get; set; }
        public int courseId { get; set; }
        public string examDescription { get; set; }
        public int examType { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
    }
}
