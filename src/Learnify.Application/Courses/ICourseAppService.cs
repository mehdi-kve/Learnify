using Abp.Application.Services;
using Abp.Domain.Repositories;
using Learnify.Courses.Dto;
using Learnify.Models.Courses;
using Learnify.Students;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses
{
    public interface ICourseAppService
    {
        Task<List<Course>> GetAllAsync(GetAllCoursesInput input);

        Task<Course> GetByIdAsync(int id);
        
        //Task<StudentDto> CreateAsync(CreateStudentDto input);

        //Task<StudentDto> UpdateAsync(UpdateStudentDto input);

        //Task<StudentDto> DeleteAsync(GetByIdDto input);
    }
}
