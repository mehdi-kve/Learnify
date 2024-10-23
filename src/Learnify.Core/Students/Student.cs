using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    [Table("Students")]
    public class Student : Entity, IHasCreationTime
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Column("RegistrationDate")]
        public DateTime CreationTime { get; set; }

        public Student()
        {
            CreationTime = Clock.Now;
        }
    }
}
