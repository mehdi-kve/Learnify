using Learnify.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses
{
    public interface ICourseStepAppService
    {
        Task<List<CourseStep>> GetCourseStepsAsync(int courseid);

    }
}
