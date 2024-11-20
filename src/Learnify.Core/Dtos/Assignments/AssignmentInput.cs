using Abp.AutoMapper;
using Learnify.Models.Assignments;
using Learnify.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Dtos.Assignments
{
    [AutoMap(typeof(Assignment))]
    public class AssignmentInput
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int TotalScore {  get; set; }

        [Required]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile File { get; set; }
    }
}
