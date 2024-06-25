using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("StudentAssigment")]
    public class StudentAssigment : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssigmentId { get; set; }
        public float? Point { get; set; }
        public int Status { get; set; }
        public string Document { get; set; }
        [ForeignKey("StudentId")]
        public virtual Users Student { get; set; }
        [ForeignKey("AssigmentId")]
        public virtual Assigments Assigments { get; set; }


    }
}
