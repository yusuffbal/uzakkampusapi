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
    public interface IAssigmentService
    {
        public Task<Response<Assigments>> CreateAssigment(AddAssigmentDto assigment);

    }
}
