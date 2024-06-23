using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class ExamDto :IDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string ExamDescription { get; set; }
        public DateTime ExamStartTime{ get; set; }
        public DateTime ExamEndTime { get; set; }
        public int Type { get; set; }

    }
}
