using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class GetExamDto :IDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
    }
}
