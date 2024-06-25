using Core.Dtos;
using Core.Entities;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICourseServıce
    {
        public Task<Response<IEnumerable<CourseInfoDto>>> CourseByUserId(int userId);
        public Task<Response<CourseDto>> CourseById(int courseId);
        public Task<Response<Courses>> CreatePosts(AddCourseDto course);
        public Task<Response<List<GetCoursesDto>>> GetCourse();
        public Task<Response<StudentCourseDto>> AddStudentsToCourseAsync(int courseId, IEnumerable<int> studentIds);
        public Task<Response<CourseDocument>> AddDocument(AddCourseDocument document);
        public Task<Response<CourseVideos>> AddVideo(AddVideoDto videoDto);
        public Task<Response<List<GradesDto>>> GetGrades(int id);
        public Task<Response<StudentAssigment>> UploadAssigment(UploadAssigmentDto assigmentDto);





    }
}
