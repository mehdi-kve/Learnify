using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses.Dto
{
    public class EnrollStudentDto
    {
        [Required]
        public List<long> UserIds { get; set; }
    }
}
