using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses
{
    [Table("AppCourseSteps")]
    public class CourseStep : Entity
    {
        public string StepName { get; set; }
        public string Description { get; set; }

        [ForeignKey("CourseId")]
        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public ICollection<StudentProgress> StudentProgresses { get; set; }
    }
}
 