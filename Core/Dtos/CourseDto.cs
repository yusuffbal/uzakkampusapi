using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CourseDto:IDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseTitle { get; set; }
        public List<CourseVideos>? CourseVideo { get; set; }
        public List<CourseDocument>? CourseDocument { get; set; }
        public List<Exams>? CourseExams { get; set; }
        public List<Assigments>? CourseAssigment { get; set; }
        public List<Quiz>? CourseQuiz { get; set; }

    }
}
