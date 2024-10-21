using System.ComponentModel.DataAnnotations;

namespace Learnify.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}