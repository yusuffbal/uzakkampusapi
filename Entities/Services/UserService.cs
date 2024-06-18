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
    public class UserService(IGenericRepository<Users> userService) 
        : IUserService
    {
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

        public Task<Users> GetUserByEmailAndPasswordAsync(LoginDto loginDto)
        {
            var user =  userService.SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            return user;
        }
    }
}
