using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.UI;
using Learnify.Courses.Dto;
using Learnify.Enrollments;
using Learnify.Students;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses
{
    public class CourseAppService : LearnifyAppServiceBase, ICourseAppService, ITransientDependency
    {
        private readonly IRepository<Course,int> _courseRepo;
        private readonly IRepository<Student,int> _studentRepo;

        public CourseAppService(IRepository<Course, int> courseRepo, IRepository<Student, int> StudentRepo)
        {
            _courseRepo = courseRepo;
            _studentRepo = StudentRepo;
        }

        // api Endpoint => GET: api/Course/GetAll
        public async Task<CourseOutputDto> GetAllAsync(GetAllCourseDto input)
        {
            var courses = await _courseRepo.GetAllListAsync();

            if (!input.Name.IsNullOrWhiteSpace())
            {
                courses = await _courseRepo.GetAllListAsync(c => c.CourseName.Contains(input.Name));

                if (courses.Count == 0)
                    throw new UserFriendlyException("No Course Found!");
            }

            if (!input.CourseCode.IsNullOrWhiteSpace() && input.Name.IsNullOrWhiteSpace())
            {
                courses = await _courseRepo.GetAllListAsync(c => c.CourseCode.Contains(input.CourseCode));

                if (courses.Count == 0)
                    throw new UserFriendlyException("No Course Found!");
            }

            return new CourseOutputDto
            {
                Courses = ObjectMapper.Map<List<CourseDto>>(courses)
            };
        }

        // api Endpoint => GET: api/Course/GetById
        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepo.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                throw new UserFriendlyException("No Course Found!");

            return ObjectMapper.Map<CourseDto>(course);
        }

        // api Endpoint => Post: api/courses/{courseId}/enrollstudents
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
        }


    }
}
