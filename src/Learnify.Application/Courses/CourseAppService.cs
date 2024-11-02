using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.UI;
using Learnify.Courses.Dto;
using Learnify.Models.Enrollments;
using Learnify.Models.Courses;
using Learnify.Models.Students;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Learnify.Courses
{
    public class CourseAppService : ICourseAppService, ITransientDependency
    {
        private readonly IRepository<Course,int> _courseRepo;

        public CourseAppService(IRepository<Course, int> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task<List<Course>> GetAllAsync(GetAllCoursesInput input)
        {
            var courses = await _courseRepo.GetAllListAsync();

            if (!input.Name.IsNullOrWhiteSpace())
            {
                courses = await _courseRepo.GetAllListAsync(c => c.CourseName.Contains(input.Name));

                if (courses.Count == 0)
                    return null;
            }

            if (!input.CourseCode.IsNullOrWhiteSpace() && input.Name.IsNullOrWhiteSpace())
            {
                courses = await _courseRepo.GetAllListAsync(c => c.CourseCode.Contains(input.CourseCode));

                if (courses.Count == 0)
                    return null;
            }

            return courses;

        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _courseRepo.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return null;

            return course;
        }

        public async Task<Course> GetCourseStepsAsync(int courseId)
        {
            var course = await _courseRepo
                .GetAll()
                .Include(c => c.CourseSteps)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course.CourseSteps.Count <= 0)
                return null;

            return course;
        }
    }
}
