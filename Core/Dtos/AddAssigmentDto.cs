using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AddAssigmentDto:IDto
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int courseId { get; set; }
    }
}
