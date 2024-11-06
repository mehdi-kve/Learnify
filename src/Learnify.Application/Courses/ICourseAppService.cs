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

        Task<Course?> GetByIdAsync(int id);
        
        Task<Course> CreateAsync(Course course);

        Task<Course?> UpdateAsync(int id, Course course);

        Task<Course?> DeleteAsync(int id);
    }
}
