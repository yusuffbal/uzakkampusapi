using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using DataAcces;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AssigmentService
        (IGenericRepository<Assigments> assigmentService,
        IUnitOfWork unitOfWork)
        : IAssigmentService
    {
        public async Task<Response<Assigments>> CreateAssigment(AddAssigmentDto assigment)
        {
            var newAssigment = new Assigments
            {
                Name = assigment.name,
                Title = assigment.title,
                Description = assigment.description,
                CourseId = assigment.courseId,
            };
           

            await assigmentService.AddAsync(newAssigment);
            unitOfWork.CommmitAsync();


            return Response<Assigments>.Success(newAssigment, 200);
        }
    }
}
