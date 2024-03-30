using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Courses")]

    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public int Credit { get; set; }
        public int Passinggrade { get; set; }
        [Column(TypeName = "date")] public DateTime CreatedDate { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Users Teacher { get; set; }
    }
}
