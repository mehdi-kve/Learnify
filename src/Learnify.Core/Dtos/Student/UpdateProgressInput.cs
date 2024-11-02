using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Dtos.Student
{
    public class UpdateProgressInput
    {
        [Required]
        public int CourseStepId { get; set; }

        [Required]
        [Range(0,1)]
        public int State { get; set; }
    }
}
