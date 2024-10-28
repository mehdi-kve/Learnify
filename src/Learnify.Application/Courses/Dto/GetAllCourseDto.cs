using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Courses.Dto
{
    public class GetAllCourseDto
    {
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? CourseCode { get; set; }
    }
}
