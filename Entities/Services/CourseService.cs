using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using DataAcces;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CourseService(
        IGenericRepository<StudentCourse> _studentCourseRepository,
        IGenericRepository<Assigments> _courseAssigmentRepository,
        IGenericRepository<CourseDocument> _courseDocumentRepository,
        IGenericRepository<Courses> _courseRepository,
        IGenericRepository<CourseVideos> _courseVideosRepository,
        IGenericRepository<Exams> _courseExamsRepository,
        IGenericRepository<Quiz> _coureQuizRepository,
        IGenericRepository<Grades> _gradesRepository,
        IGenericRepository<StudentAssigment> _studentAssigmentRepository,
        IUnitOfWork unitOfWork

        ) : ICourseServıce
    {
        public async Task<Response<IEnumerable<CourseInfoDto>>> CourseByUserId(int userId)
        {
            var studentCourses = await _studentCourseRepository.GetListByExpAsync(
                sc => sc.StudentId == userId,
                include: sc => sc.Include(sc => sc.Courses).ThenInclude(c => c.Teacher)
            );

            var courseIds = studentCourses.Select(sc => sc.CourseId).ToList();

            var courses = await _courseRepository.Where(c => courseIds.Contains(c.Id)).ToListAsync();

            var courseInfoDtoList = courses.Select(course => new CourseInfoDto
            {
                Id = course.Id,
                CourseName = course.Name,
                CourseTitle = course.Title
            }).ToList();

            return Response<IEnumerable<CourseInfoDto>>.Success(courseInfoDtoList, 200);
        }


        public async Task<Response<CourseDto>> CourseById(int courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                var errorDto = new ErrorDto("Kayıt bulunamadı.", true);
                var response = Response<CourseDto>.Fail(errorDto, 404);

            }

            var courseVideos = await _courseVideosRepository.Where(cv => cv.CourseId == courseId).ToListAsync();
            var courseDocuments = await _courseDocumentRepository.Where(cd => cd.CourseId == courseId).ToListAsync();
            var courseExams = await _courseExamsRepository.Where(ce => ce.CourseId == courseId).ToListAsync();
            var courseAssignments = await _courseAssigmentRepository.Where(ca => ca.CourseId == courseId).ToListAsync();
            var courseQuizzes = await _coureQuizRepository.Where(cq => cq.CourseId == courseId).ToListAsync();

            var courseDto = new CourseDto
            {
                Id = course.Id,
                CourseName = course.Name,
                CourseTitle = course.Title,
                CourseVideo = courseVideos,
                CourseDocument = courseDocuments,
                CourseExams = courseExams,
                CourseAssigment = courseAssignments,
                CourseQuiz = courseQuizzes
            };

            return Response<CourseDto>.Success(courseDto, 200);
        }

        public async Task<Response<Courses>> CreatePosts(AddCourseDto course)
        {
            try
            {
                var newCourse = new Courses
                {
                    Name = course.Name,
                    Title = course.Title,
                    CreatedDate = DateTime.Now,
                    Passinggrade = course.Passinggrade,
                    TeacherId = course.TeacherId,
                    Credit = course.Credit
                };

                await _courseRepository.AddAsync(newCourse);
                unitOfWork.CommmitAsync();


                return Response<Courses>.Success(newCourse, 200);
            }
            catch
            {
                return Response<Courses>.Fail("Course creation failed", 500, true);

            }
        }

        public async Task<Response<List<GetCoursesDto>>> GetCourse()
        {
            var course = await _courseRepository.GetListByExpAsync(
                 predicate: null,  
                 include: null,    
                 orderBy: null,    
                 pageNumber: -1,   
                 pageSize: -1      
             );

            var courseDtoList = course.Select(course => new GetCoursesDto
            {
                Id = course.Id,
                CourseName=course.Name,
            }).ToList();



            return Response<List<GetCoursesDto>>.Success(courseDtoList, 200);
        }

        public async Task<Response<StudentCourseDto>> AddStudentsToCourseAsync(int courseId, IEnumerable<int> studentIds)
        {

            try
            {
                StudentCourseDto studentCourseDtos = new StudentCourseDto();

                foreach (var studentId in studentIds)
                {
                    var studentCourse = new StudentCourse
                    {
                        CourseId = courseId,
                        StudentId = studentId,
                        Participation = 0 
                    };

                     await _studentCourseRepository.AddAsync(studentCourse);
                    unitOfWork.CommmitAsync();

                }

            
                return Response<StudentCourseDto>.Success("Atama Başarılı", 200);

            }
            catch (Exception ex)
            {
                return Response<StudentCourseDto>.Fail("Course creation failed", 500, true);

            }

        }

        public async Task<Response<CourseDocument>> AddDocument(AddCourseDocument document)
        {
            try
            {
                var newDocument = new CourseDocument
                {
                    Name = document.Name,
                    CourseId = document.CourseId,
                    Document = document.Document
                };
                

                await _courseDocumentRepository.AddAsync(newDocument);
                unitOfWork.CommmitAsync();


                return Response<CourseDocument>.Success(newDocument, 200);
            }
            catch
            {
                return Response<CourseDocument>.Fail("Course creation failed", 500, true);

            }
        }

        public async Task<Response<CourseVideos>> AddVideo(AddVideoDto videoDto)
        {
            var newVideo = new CourseVideos
            {
                Name = videoDto.Name,
                CourseId = videoDto.CourseId,
                Video = videoDto.Video
            };

            await _courseVideosRepository.AddAsync(newVideo);
            unitOfWork.CommmitAsync();

            return Response<CourseVideos>.Success(newVideo, 200);


        }

        public async Task<Response<List<GradesDto>>> GetGrades(int id)
        {
            var userGrades = await _gradesRepository.GetListByExpAsync(
                u => u.StudentId == id,
                include: query => query.Include(g => g.Courses));

            var allGrades = await _gradesRepository.GetListByExpAsync(
                predicate: null,
                include: query => query.Include(g => g.Courses),
                orderBy: null,
                pageNumber: -1,
                pageSize: -1);

            var getGrades = userGrades.Select(grades => {
                var courseId = grades.CourseId;

                var courseGrades = allGrades.Where(g => g.CourseId == courseId);

                var midtermAverage = courseGrades.Average(g => g.MidtermNote);
                var finalAverage = courseGrades.Average(g => g.FinalNote);
                var integrationAverage = courseGrades.Average(g => g.IntegrationNote);

                return new GradesDto
                {
                    Course = grades.Courses,
                    MidtermClassAverage = midtermAverage,
                    FinalClassAverage = finalAverage,
                    IntegrationClassAverage = integrationAverage,
                    Average = grades.Average,
                    FinalNote = grades.FinalNote,
                    IntegrationNote = grades.IntegrationNote,
                    MidtermNote = grades.MidtermNote,
                    Status = grades.Status,
                };
            }).ToList();

            return Response<List<GradesDto>>.Success(getGrades, 200);
        }

        public async Task<Response<StudentAssigment>> UploadAssigment(UploadAssigmentDto assigmentDto)
        {
            var newAssigment = new StudentAssigment
            {
                Document = assigmentDto.assigmentDocument,
                AssigmentId = assigmentDto.assigmentId,
                StudentId = assigmentDto.studentId,
                Status=1,
                Point=null
            };

            var result = await _studentAssigmentRepository.AddAsync(newAssigment);
            await unitOfWork.CommmitAsync();

            return Response<StudentAssigment>.Success(result, 200);
        }
    }
}
