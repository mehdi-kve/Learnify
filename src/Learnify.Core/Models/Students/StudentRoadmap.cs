using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Learnify.Authorization.Users;
using Learnify.Models.Courses;
using Learnify.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Models.Students
{
    [Table("AppStudentRoadmaps")]
    public class StudentRoadmap: Entity, IHasCreationTime
    {
        [ForeignKey("UserId")]
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("RoadmapId")]
        public virtual int RoadmapId { get; set; }
        public virtual Roadmap Roadmap { get; set; }

        [Column("EnrollmentDate")]
        public DateTime CreationTime { get; set; }

        public StudentRoadmap()
        {
            CreationTime = Clock.Now;
        }
    }
}
