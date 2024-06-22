using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreatePostDto:IDto
    {
        public int ForumId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string? image { get; set; }
        public int AuthorId { get; set; }
    }
}
