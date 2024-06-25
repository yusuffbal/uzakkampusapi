using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Grades")]
    public class Grades : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double MidtermNote { get; set; }
        public double FinalNote { get; set; }
        public double? IntegrationNote { get; set; }
        public double Average { get; set; }
        public int Status { get; set; }

        [ForeignKey("CourseId")]
        public virtual Courses Courses { get; set; }

        [ForeignKey("StudentId")]
        public virtual Users Users { get; set; }
    }
}
