using Abp.AutoMapper;
using Learnify.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Dtos.Student
{
    [AutoMap(typeof(StudentProgress))]
    public class ProgressInput
    {
        [Required]
        public int CourseStepId { get; set; }

        [Required]
        [Range(0,1)]
        public ProgressState State { get; set; }
    }
}
