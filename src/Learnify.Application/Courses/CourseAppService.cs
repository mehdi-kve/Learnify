using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using Learnify.Courses.Dto;
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
        private readonly IRepository<Course> _courseRepo;

        public CourseAppService(IRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
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


    }
}
