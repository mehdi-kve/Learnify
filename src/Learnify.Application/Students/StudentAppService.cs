using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public class StudentAppService : LearnifyAppServiceBase ,IStudentAppService, ITransientDependency
    {
        private readonly IRepository<Student> _studnetRepo;

        public StudentAppService(IRepository<Student> StudnetRepo)
        {
            _studnetRepo = StudnetRepo;
        }

        public async Task<StudentsOutputDto> GetAllAsync(GetAllStudentsDto input) 
        {
            var students = await _studnetRepo.GetAllListAsync();

            if(input.Name != null) 
            {
                students = await _studnetRepo.GetAllListAsync(std => std.Name.Contains(input.Name));
                
                if (students.Count == 0)
                    throw new UserFriendlyException("404, No Student Found!");
            }

            return new StudentsOutputDto
            {
                Students = ObjectMapper.Map<List<StudentDto>>(students)
            };
        }

        public async Task<StudentDto> GetByIdAsync(GetByIdDto input) 
        {
            var student = await _studnetRepo.FirstOrDefaultAsync(std => std.Id == input.Id);

            if(student == null)
                throw new UserFriendlyException("404, No Student Found!");

            return ObjectMapper.Map<StudentDto>(student);
        }

    }
}
