using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Learnify.Models.Courses;
using Learnify.Students;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class CourseDto : EntityDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
