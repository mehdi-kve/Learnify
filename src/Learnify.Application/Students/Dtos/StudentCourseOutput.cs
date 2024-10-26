using Abp.Application.Services.Dto;
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
    public class StudentCourseOutput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<EnrollmentDto> Enrollments { get; set; }
    }
}
