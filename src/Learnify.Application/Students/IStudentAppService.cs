using Abp.Application.Services;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public interface IStudentAppService // : IAsyncCrudAppService<StudentDto>
    {
        Task<StudentsOutputDto> GetAllAsync(GetAllStudentsDto input);

        //Task<StudentDto> GetByIdAsync(StudentDto input);

        //void CreateAsync(StudentDto input);

        //void UpdateAsync(StudentDto input);

        //void DeleteAsync();
    }
}
