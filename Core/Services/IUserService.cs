using Core.Dtos;
using Core.Entities;
using Entities.Concrete;
using Entities.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        public Task<Users> GetUserByEmailAndPasswordAsync(LoginDto loginDto);


        public Task<Response<UserDto>> GetCurrentUser(LoginDto loginDto);





    }
}
