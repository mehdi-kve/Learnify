using Learnify.Courses.Dto;
using Learnify.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Dtos.Course
{
    public class CourseStepsOutout
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public List<CourseStepDto> CourseSteps { get; set; }
    }
}
