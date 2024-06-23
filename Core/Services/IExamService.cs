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
    public interface IExamService
    {
        public Task<Response<List<ExamDto>>> ExamByUserId(int userId);
        public Task<Response<List<QuestionExamDto>>> QuestionListByExamId(int examId);
        public Task<Response<StudentExams>> FinishExam(FinishExamDto finishExam);
        public Task<Response<Exams>> AddExamAsync(AddExamDto examDto);
        public Task<Response<List<GetExamDto>>> GetExamAsync();
        public Task<Response<ExamsDetail>> AddExamQuestionAsync(AddExamQuestion examQuestion);





    }
}
