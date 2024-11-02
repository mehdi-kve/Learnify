using Abp.Dependency;
using Abp.Domain.Repositories;
using Learnify.Models.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses
{
    public class CourseStepAppService : ICourseStepAppService, ITransientDependency
    {
        private readonly IRepository<CourseStep, int> _courseStepRepo;

        public CourseStepAppService(IRepository<CourseStep, int> courseStepRepo)
        {
            _courseStepRepo = courseStepRepo;
        }

        public async Task<List<CourseStep>> GetCourseStepsAsync(int courseId)
        {
            var courseSteps = await _courseStepRepo
                .GetAll()
                .Where(cs => cs.CourseId == courseId)
                .ToListAsync();

            if (courseSteps.Count <= 0)
                return null;

            return courseSteps;
        }
    }
}
