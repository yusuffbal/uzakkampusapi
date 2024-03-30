﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Exams")]
    public class Exams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int CourseId { get; set; }
        public int Type { get; set; }
        
        [ForeignKey("CourseId")]
        public virtual Courses Courses { get; set; }
    }
}
