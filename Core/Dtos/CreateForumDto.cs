using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreateForumDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AddForumParticipantDto> ForumParticipant { get; set; }
    }

    public class AddForumParticipantDto
    {
        public int UserId { get; set; }
    }



}
