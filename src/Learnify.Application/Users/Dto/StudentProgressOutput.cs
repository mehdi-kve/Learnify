using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students.Dtos
{
    public class StudentProgressOutput
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProgressDto> StudentProgresses { get; set; }
    }
}
