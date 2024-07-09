using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Entities.Concrete;
using Entities.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService(IGenericRepository<Users> userService, IGenericRepository<StudentCourse> studentCourseService) 
        : IUserService
    {
        public async Task<Response<List<UserDto>>> GetAllStudent()
        {


            var allStudents = await userService.GetListByExpAsync(u => u.Type == 1);

           

            var studentDtoList = allStudents.Select(student => new UserDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Email = student.Email,
                Type = student.Type
            }).ToList();

            return Response<List<UserDto>>.Success(studentDtoList, 200);
        }

        public async Task<Response<UserDto>> GetCurrentUser(LoginDto loginDto)
        {
            var user = await userService.SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);


            UserDto userDto =  new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Type = user.Type
            };

            return Response<UserDto>.Success(userDto, 200);

        }

        public async Task<Response<List<UserDto>>> GetStudent(int courseId)
        {
            var studentIdsInCourse = await studentCourseService.GetListByExpAsync(u => u.CourseId == courseId);

            var studentIds = studentIdsInCourse.Select(sc => sc.StudentId).ToList();

            var allStudents = await userService.GetListByExpAsync(u => u.Type == 1);

            var filteredStudents = allStudents.Where(student => !studentIds.Contains(student.Id)).ToList();

            var studentDtoList = filteredStudents.Select(student => new UserDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Email = student.Email,
                Type = student.Type
            }).ToList();

            return Response<List<UserDto>>.Success(studentDtoList, 200);
        }



        public async Task<Response<List<UserDto>>> GetTeacher()
        {
            var teacher = await userService.GetListByExpAsync(u => u.Type == 2);

            var teacherDtoList = teacher.Select(teacher => new UserDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Surname = teacher.Surname,
                Email = teacher.Email,
                Type = teacher.Type
            }).ToList();

            

            return Response<List<UserDto>>.Success(teacherDtoList, 200);
        }

        public Task<Users> GetUserByEmailAndPasswordAsync(LoginDto loginDto)
        {
            var user =  userService.SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            return user;
        }
    }
}
