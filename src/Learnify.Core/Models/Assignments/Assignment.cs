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
    [Table("AppAssignments")]
    public class Assignment : Entity, IHasCreationTime
    {
        public string Title {  get; set; }
        public int TotalScore { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }

        [ForeignKey("CourseStepId")]
        public virtual int CourseStepId { get; set; }
        public virtual CourseStep CourseStep { get; set; }

        /*
        [ForeignKey("TeacherId")]
        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        */
        public ICollection<Response> Responses { get; set; }

        [Column("UploadedAt")]
        public DateTime CreationTime { get; set; }

        public Assignment()
        {
            CreationTime = Clock.Now;
        }
    }
}
