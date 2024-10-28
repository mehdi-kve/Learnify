using Abp.Application.Services;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses
{
    public interface ICourseAppService: IApplicationService
    {
        Task<StudentsOutputDto> GetAllAsync();

        Task<StudentDto> GetByIdAsync(GetByIdDto input);

        //Task<StudentCourseOutput> GetCoursesAsync(int id);

        //Task<StudentDto> CreateAsync(CreateStudentDto input);

        //Task<StudentDto> UpdateAsync(UpdateStudentDto input);

        //Task<StudentDto> DeleteAsync(GetByIdDto input);
    }
}
