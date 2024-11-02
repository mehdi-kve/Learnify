using Abp.AutoMapper;
using Learnify.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Dtos.Course
{
    [AutoMap(typeof(CourseStep))]
    public class CourseStepDto
    {
        public int Id { get; set; }
        public string StepName { get; set; }
        public string Description { get; set; }
    }
}
