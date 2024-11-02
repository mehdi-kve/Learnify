using Abp.AutoMapper;
using Learnify.Models.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Dtos.Course
{
    [AutoMap(typeof(CourseStep))]
    public class courseStepInput
    {
        [Required]
        [MaxLength(50)]
        public string StepName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
