using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("StudentExams")]
    public class StudentExams : IEntity
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int ExamId { get; set; }
        public float Point { get; set; }
        public int Status { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int Type { get; set; }
        [ForeignKey("StudentId")]
        public virtual Users Student { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exams Exams { get; set; }
    }
}
