﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("ForumParticipants")]
    public class ForumParticipants
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }

        [ForeignKey("ForumId")]
        public virtual Forums Forums { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
