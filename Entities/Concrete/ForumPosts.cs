using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("ForumPosts")]
    public class ForumPosts
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [ForeignKey("ForumId")]
        public virtual Forums Forums { get; set; }

    }
}
