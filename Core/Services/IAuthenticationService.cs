using Core.Dtos;
using Entities.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        public Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

    }
}
