using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public class StudentAppService : /*AsyncCrudAppService<Student, StudentDto>,*/LearnifyAppServiceBase ,IStudentAppService, ITransientDependency
    {
        private readonly IRepository<Student> _studnetRepo;

        public StudentAppService(IRepository<Student> StudnetRepo)
           // : base(StudnetRepo)
        {
            _studnetRepo = StudnetRepo;
        }

        public async Task<StudentsOutputDto> GetAllAsync(GetAllStudentsDto input) 
        {
            var students = await _studnetRepo.GetAllListAsync();

            if(input.Name != null) 
            {
                students = await _studnetRepo.GetAllListAsync(std => std.Name.Contains(input.Name));
            }

            var StdDtoList = students
                .Select(std => new StudentDto
                {
                    Id = std.Id,
                    Name = std.Name,
                    Email = std.Email
                }).ToList();

            return new StudentsOutputDto { Students = StdDtoList };
        }

    }
}
