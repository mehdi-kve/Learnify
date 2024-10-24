using Abp.Domain.Entities;
using Learnify.Courses;
using Learnify.Enrollments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    [Table("AppStudentProgresses")]
    public class StudentProgress: Entity
    {
        public ProgressState State { get; set; }
        public DateTime? CompletionDate { get; set; }

        [ForeignKey("StudentId")]
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("CourseStep")]
        public virtual int CourseStepId { get; set; }
        public virtual CourseStep CourseStep { get; set; }

        public StudentProgress()
        {
            State = ProgressState.InProgress;
        }
    }
}
