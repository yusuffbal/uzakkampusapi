using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Assigments")]
    public class Assigments : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        [Column(TypeName = "date")] public DateTime DateOfStart { get; set; }
        [Column(TypeName = "date")] public DateTime DateOfEnd { get; set; }
        
        [ForeignKey("CourseId")]
        public virtual Courses course { get; set; }

    }
}
