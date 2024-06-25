using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UploadAssigmentDto :IDto
    {
        public int assigmentId { get; set; }
        public int studentId { get; set; }
        public string assigmentDocument { get; set; }
    }
}
