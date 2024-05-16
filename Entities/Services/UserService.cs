using Core.Entities;
using Core.Repositories;
using Core.Services;
using Entities.Concrete;
using Entities.Dtos;
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
        

    

        
        public Task<Users> GetUserByEmailAndPasswordAsync(LoginDto loginDto)
        {
            var user =  userService.SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            return user;

        }
    }
}
