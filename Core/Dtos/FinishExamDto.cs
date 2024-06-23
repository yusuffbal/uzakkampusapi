using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class FinishExamDto :IDto
    {
        public int StudentID { get; set; }
        public int ExamId { get; set; }
        public float Point { get; set; }
        public int Status { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
    }
}
