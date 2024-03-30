using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("StudentAssigment")]
    public class StudentAssigment
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int AssigmentId { get; set; }
        public float Point { get; set; }
        public int Status { get; set; }
        public DateTime DateOfStart { get; set; }   
        public DateTime DateOfEnd { get; set;}
        public string Document { get; set; }
        [ForeignKey("StudentId")]
        public virtual Users Student { get; set; }
        [ForeignKey("AssigmentId")]
        public virtual Assigments Assigments { get; set; }


    }
}
