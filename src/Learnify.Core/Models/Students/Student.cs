using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Courses;
using Learnify.Models.Enrollments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Models.Students
{
    [Table("AppStudents")]
    public class Student : Entity, IHasCreationTime
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Column("RegistrationDate")]
        public DateTime CreationTime { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<StudentProgress> StudentProgresses { get; set; }

        public Student()
        {
            CreationTime = Clock.Now;
        }
    }
}
