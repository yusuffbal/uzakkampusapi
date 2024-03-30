﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("StudentQuiz")]
    public class StudentQuiz
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public float Point { get; set; }
        public int Status { get; set; }

        [ForeignKey("StudentId")]
        public virtual Users Student { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
    }
}
