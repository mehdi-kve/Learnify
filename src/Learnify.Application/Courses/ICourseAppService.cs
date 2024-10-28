using Abp.Application.Services;
using Learnify.Courses.Dto;
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
        Task<CourseOutputDto> GetAllAsync(GetAllCourseDto input);

        Task<CourseDto> GetByIdAsync(int id);

        //Task<StudentCourseOutput> GetCoursesAsync(int id);

        //Task<StudentDto> CreateAsync(CreateStudentDto input);

        //Task<StudentDto> UpdateAsync(UpdateStudentDto input);

        //Task<StudentDto> DeleteAsync(GetByIdDto input);
    }
}
