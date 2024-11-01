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

        /*// api Endpoint => Post: api/courses/{courseId}/enrollstudents
        public async void EnrollStudenstAsync(int courseId, EnrollStudentDto input)
        {
            var course = await _courseRepo.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
                throw new UserFriendlyException("No Course Found!");

            if (input.StudentIds.Count <= 0 || !input.StudentIds.Any())
            {
                throw new UserFriendlyException("Student IDs cannot be empty!");
            }
            
            foreach (var studentId in input.StudentIds)
            {
                var student = await _studentRepo.FirstOrDefaultAsync(c => c.Id == studentId);

                if (student != null)
                {
                    course.Enrollments.Add(new Enrollment
                    {
                        CourseId = courseId,
                        StudentId = studentId
                    });

                    await _courseRepo.UpdateAsync(course);
                }
            }
        }*/


    }
}
