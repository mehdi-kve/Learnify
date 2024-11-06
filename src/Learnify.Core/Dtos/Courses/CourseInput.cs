using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Learnify.Models.Courses;
using Learnify.Students;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses.Dto
{
    [AutoMap(typeof(Course))]
    public class CourseInput
    {
        [Required]
        [MaxLength(256)]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CourseCode { get; set; }
    }
}
