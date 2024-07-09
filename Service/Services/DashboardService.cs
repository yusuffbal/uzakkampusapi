using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DashboardService(IGenericRepository<StudentAssigment> _studentAssigmentRepository,
            IGenericRepository<StudentExams> _studentExamRepository,
            IGenericRepository<StudentCourse> _studentCourseRepository,
            IGenericRepository<StudentQuiz> _studentQuizRepository,
            IGenericRepository<Courses> _coursesRepository,
            IGenericRepository<Grades> _gradesRepository
            ) : IDashboardService
    {

        public async Task<Response<DashboardDto>> DashboardAnalysisAsync(int userId)
        {
            
            
                var assigmentsCountTask = await _studentAssigmentRepository.GetListCount(s => s.StudentId == userId);
                var examsCountTask = await _studentExamRepository.GetListCount(s => s.StudentID == userId);
                var coursesCountTask = await _studentCourseRepository.GetListCount(s => s.StudentId == userId);
                var quizCountTask = await _studentQuizRepository.GetListCount(s => s.StudentId == userId);

                var coursesTask = _studentCourseRepository.GetListByExpAsync(
                    s => s.StudentId == userId,
                    include: q => q.Include(sc => sc.Courses),
                    orderBy: null,
                    pageNumber: 1,
                    pageSize: 2
                );

            var courses = (await coursesTask).Select(sc => sc.Courses).ToList(); 


            var dashboardDto = new DashboardDto
                {
                    AssigmentsCount =  assigmentsCountTask,
                    ExamsQount =  examsCountTask,
                    CoursesCount =  coursesCountTask,
                    QuizCount =  quizCountTask,
                    Courses = courses
            };

                return Response<DashboardDto>.Success(dashboardDto, 200);
            
            
            
        }

        public async Task<Response<IEnumerable<DashboardProgressDto>>> DashboardCourseProgressAsync(int userId)
        {
            var studentCourses = await _studentCourseRepository.GetListByExpAsync(
                sc => sc.StudentId == userId,
                include: sc => sc
                    .Include(sc => sc.Courses)
                    .ThenInclude(c => c.Teacher)
                    .Include(sc => sc.Users)
            );

            var dashboardProgressDtoList = new List<DashboardProgressDto>();

            foreach (var sc in studentCourses)
            {
                var midtermNote = await _gradesRepository.Where(g => g.StudentId == userId && g.CourseId == sc.CourseId)
                                    .SumAsync(g => (float?)g.MidtermNote) ?? 0;

                var finalNote = await _gradesRepository.Where(g => g.StudentId == userId && g.CourseId == sc.CourseId)
                                    .SumAsync(g => (float?)g.FinalNote) ?? 0;

                var dto = new DashboardProgressDto
                {
                    CourseName = sc.Courses.Name,
                    Teacher = sc.Courses.Teacher.Name + " " + sc.Courses.Teacher.Surname,
                    CourseParticipant = sc.Participation,
                    midtermNote = midtermNote,
                    FinalNote = finalNote
                };

                dashboardProgressDtoList.Add(dto);
            }

            return Response<IEnumerable<DashboardProgressDto>>.Success(dashboardProgressDtoList, 200);
        }


    }
}
