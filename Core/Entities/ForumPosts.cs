using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("ForumPosts")]
    public class ForumPosts : IEntity
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public DateTime? DateOfCreated { get; set; }

        [ForeignKey("ForumId")]
        public virtual Forums Forums { get; set; }


        [ForeignKey("AuthorId")]
        public virtual Users Author { get; set; }

    }
}
