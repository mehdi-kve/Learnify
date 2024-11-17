using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Timing;
using Learnify.Models.Courses;
using Learnify.Models.Students;

namespace Learnify.Models.Assignments
{
    [Table("AppAssignmentResponses")]
    public class Response : Entity, IHasCreationTime
    {
        public string Title { get; set; }
        public int score { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        
        [ForeignKey("AssignmentId")]
        public virtual int AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
       
        [ForeignKey("StudentProgressId")]
        public virtual int StudentProgressId { get; set; }
        public virtual StudentProgress StudentProgress { get; set; }

        [Column("UploadedAt")]
        public DateTime CreationTime { get; set; }

        public Response()
        {
            CreationTime = Clock.Now;
        }
    }
}
