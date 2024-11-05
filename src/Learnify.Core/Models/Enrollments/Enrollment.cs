using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Authorization.Users;
using Learnify.Models.Courses;
using Learnify.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Models.Enrollments
{
    [Table("AppEnrollments")]
    public class Enrollment : Entity, IHasCreationTime
    {
        [ForeignKey("UserId")]
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("CourseId")]
        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Column("EnrollmentDate")]
        public DateTime CreationTime { get; set; }

        public Enrollment()
        {
            CreationTime = Clock.Now;
        }
    }
}
