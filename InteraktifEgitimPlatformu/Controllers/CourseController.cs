using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController(ICourseServıce courseServıce, IAssigmentService assigmentService) : CustomBaseController
    {
        [HttpPost]
        [Route("CourseByUserId")]
        public async Task<IActionResult> CourseByUserId(int Id)
        {
            var result = await courseServıce.CourseByUserId(Id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("CourseById")]
        public async Task<IActionResult> CourseById(int Id)
        {
            var result = await courseServıce.CourseById(Id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("CreateCourse")]
        public async Task<IActionResult> CreateCourse(AddCourseDto course)
        {
            var result = await courseServıce.CreatePosts(course);
            return ActionResultInstance(result);
        }


        [HttpPost]
        [Route("GetCourse")]
        public async Task<IActionResult> GetCourse()
        {
            var result = await courseServıce.GetCourse();
            return ActionResultInstance(result);
        }


        [HttpPost]
        [Route("AddStudentsToCourse")]
        public async Task<IActionResult> AddStudentsToCourse(int courseId, IEnumerable<int> studentIds)
        {
            var result = await courseServıce.AddStudentsToCourseAsync(courseId, studentIds);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("CreateAssigment")]
        public async Task<IActionResult> CreateAssigment(AddAssigmentDto assigmentDto)
        {
            var result = await assigmentService.CreateAssigment(assigmentDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("AddDocument")]
        public async Task<IActionResult> AddDocument(AddCourseDocument document)
        {
            var result = await courseServıce.AddDocument(document);
            return ActionResultInstance(result);
        }

    }
}
