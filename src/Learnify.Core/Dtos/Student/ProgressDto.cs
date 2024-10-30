using Abp.Application.Services.Dto;
using Learnify.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students.Dtos
{
    public class ProgressDto : EntityDto<int>
    {
        public string CourseName { get; set; }
        public string CourseStepName { get; set; }
        public ProgressState State { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
