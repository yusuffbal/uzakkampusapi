using Core.Entities;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("ExamsDetail")]
    public class ExamsDetail : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string AnswerText { get; set; }
        public string Correct { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set;}
        public string Choice3 { get; set; }
        public string Choice4 { get; set;}
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exams Exams { get; set; }
    }
}
