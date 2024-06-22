using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class ForumPostDto:IDto
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string? PostImage { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public DateTime? DateOfCreated { get; set; }

    }

    public class ForumDetailDto
    {
        public int ForumId { get; set; }
        public string ForumTitle { get; set; }
        public string ForumDescription { get; set; }
        public List<ForumPostDto> Posts { get; set; }
    }
}
