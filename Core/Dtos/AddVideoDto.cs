using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AddVideoDto : IDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string Video { get; set; }
    }
}
