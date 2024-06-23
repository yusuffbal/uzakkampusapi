using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Services
{
    public class ExamService(
        IGenericRepository<StudentExams> studentExamSerive,
        IGenericRepository<Courses> courseService,
        IGenericRepository<StudentCourse> studentCourseService,
        IGenericRepository<Exams> examService,
        IGenericRepository<ExamsDetail> examDetailService,
        IUnitOfWork unitOfWork) : IExamService
    {
        public async Task<Response<Exams>> AddExamAsync(AddExamDto examDto)
        {
            try
            {
                var Exam = new Exams
                {
                    CourseId=examDto.courseId,
                    Name=examDto.examName,
                    Description=examDto.examDescription,
                    DateOfStart=examDto.DateOfStart,
                    DateOfEnd=examDto.DateOfEnd,
                    Type=examDto.examType
                };

                var result = await examService.AddAsync(Exam);
                await unitOfWork.CommmitAsync();

                return Response<Exams>.Success(result, 200);
            }
            catch (Exception ex)
            {
                return Response<Exams>.Fail(ex.InnerException.ToString(), 500, true);

            }
        }

        public async Task<Response<List<ExamDto>>> ExamByUserId(int userId)
        {
            var studentCourses = await studentCourseService.GetListByExpAsync(sc => sc.StudentId == userId);

            if (studentCourses == null || !studentCourses.Any())
            {
                return Response<List<ExamDto>>.Fail("Öğrenciye ait ders bulunamadı.", 404,true);

            }

            var courseIds = studentCourses.Select(sc => sc.CourseId).ToList();

            var exams = await examService.GetListByExpAsync(
                e => courseIds.Contains(e.CourseId),
                orderBy: q => q.OrderBy(e => e.DateOfStart));

            if (exams == null || !exams.Any())
            {
                return Response<List<ExamDto>>.Fail("Derslere ait sınav bulunamadı.", 404,true);
            }

            var examDtos = exams.Select(e => new ExamDto
            {
                ExamId = e.Id,
                ExamName = e.Name,
                ExamStartTime = e.DateOfStart,
                ExamEndTime = e.DateOfEnd,
                ExamDescription= e.Description,
                Type=e.Type,
            }).ToList();

            return Response<List<ExamDto>>.Success(examDtos,200);
        }

        public async Task<Response<StudentExams>> FinishExam(FinishExamDto finishExam)
        {
            try
            {
                var newStudentExam = new StudentExams
                {
                    StudentID = finishExam.StudentID,
                    ExamId=finishExam.ExamId,
                    Point = finishExam.Point,
                    Status=1,
                    DateOfStart=finishExam.DateOfStart,
                    DateOfEnd=finishExam.DateOfEnd,
                };

                await studentExamSerive.AddAsync(newStudentExam);
                await unitOfWork.CommmitAsync(); 


                return Response<StudentExams>.Success(newStudentExam, 200);
            }
            catch (Exception ex)

            {
                return Response<StudentExams>.Fail(ex.InnerException.ToString(), 500, true);

            }
        }



        public async Task<Response<List<QuestionExamDto>>> QuestionListByExamId(int examId)
        {
            var question = await examDetailService.GetListByExpAsync(u => u.ExamId == examId);

            var questionDto = question.Select(e => new QuestionExamDto
            {
                Id = e.Id,
                Image=e.Image,
                AnswerText=e.AnswerText,
                Correct=e.Correct,
                Choice1=e.Choice1,
                Choice2=e.Choice2,
                Choice3=e.Choice3,
                Choice4=e.Choice4
            }).ToList();

            return Response<List<QuestionExamDto>>.Success(questionDto,200);
        }

        public async Task<Response<List<GetExamDto>>> GetExamAsync()
        {
            var exams = await examService.GetListByExpAsync(
                            predicate: null,
                            include: null,
                            orderBy: null,
                            pageNumber: -1,
                            pageSize: -1
                        );

            var GetExamDtoList = exams.Select(exam => new GetExamDto
            {
                ExamId=exam.Id,
                ExamName=exam.Name
            }).ToList();



            return Response<List<GetExamDto>>.Success(GetExamDtoList, 200); 
        }

        public async Task<Response<ExamsDetail>> AddExamQuestionAsync(AddExamQuestion examQuestion)
        {
            try
            {
                var newExamDetail = new ExamsDetail
                {
                    AnswerText = examQuestion.AnswerText,
                    Choice1=examQuestion.Choice1,
                    Choice2= examQuestion.Choice2,
                    Choice3 = examQuestion.Choice3,
                    Choice4 = examQuestion.Choice4,
                    Correct=examQuestion.Correct,
                    ExamId=examQuestion.ExamId
                };

                var result = await examDetailService.AddAsync(newExamDetail);
                await unitOfWork.CommmitAsync();


                return Response<ExamsDetail>.Success(result, 200);
            }
            catch (Exception ex)

            {
                return Response<ExamsDetail>.Fail(ex.InnerException.ToString(), 500, true);

            }
        }
    }
}
