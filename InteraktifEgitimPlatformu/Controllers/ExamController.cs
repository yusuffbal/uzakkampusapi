using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebAPI.Controllers
{
    [Route("api/exams")]
    [ApiController]
    public class ExamController(IExamService examService) : CustomBaseController
    {
        [HttpPost]
        [Route("GetUserExam")]

        public async Task<IActionResult> GetUserExam(int id)
        {
            var result = await examService.ExamByUserId(id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("QuestionListByExamId")]

        public async Task<IActionResult> QuestionListByExamId(int id)
        {
            var result = await examService.QuestionListByExamId(id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("FinishExam")]

        public async Task<IActionResult> FinishExam(FinishExamDto finishExam)
        {
            var result = await examService.FinishExam(finishExam);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("AddExam")]

        public async Task<IActionResult> AddExam(AddExamDto examDto)
        {
            var result = await examService.AddExamAsync(examDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("GetAllExam")]

        public async Task<IActionResult> GetAllExam()
        {
            var result = await examService.GetExamAsync();
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("AddExamQuestion")]

        public async Task<IActionResult> AddExamQuestion(AddExamQuestion examQuestion)
        {
            var result = await examService.AddExamQuestionAsync(examQuestion);
            return ActionResultInstance(result);
        }


        



    }
}
