using Abp.AutoMapper;
using Learnify.Courses;
using Learnify.Enrollments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students.Dtos
{
    [AutoMap(typeof(Student))]
    public class StudentCourseOutput : StudentDto
    {
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
