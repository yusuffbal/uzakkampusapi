using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("StudentCourse")]
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Participation { get; set; }
       
        [ForeignKey("CourseId")]
        public virtual Courses Courses { get; set; }
        
        [ForeignKey("StudentId")]
        public virtual Users Users { get; set; }


    }
}
