using Core.Dtos;
using Entities.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITokenService
    {
        Task<TokenDto> CreateTokenAsync(LoginDto userApp);

    }
}
