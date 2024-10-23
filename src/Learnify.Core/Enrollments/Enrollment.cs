using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Courses;
using Learnify.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Enrollments
{
    public class Enrollment : Entity, IHasCreationTime
    {
        [ForeignKey("StudentId")]
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("CourseId")]
        public virtual int CourseId { get; set; }
        public virtual Student Course { get; set; }

        public DateTime CreationTime { get; set; }

        public Enrollment()
        {
            CreationTime = Clock.Now;
        }
    }
}
