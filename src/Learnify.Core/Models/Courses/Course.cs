using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Models.Enrollments;
using Learnify.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Models.Courses
{
    [Table("AppCourses")]
    public class Course : Entity, IHasCreationTime
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public DateTime CreationTime { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<RoadmapCourse> RoadmapCourses { get; set; }
        public ICollection<CourseStep> CourseSteps { get; set; }

        public Course()
        {
            CreationTime = Clock.Now;
        }
    }
}
