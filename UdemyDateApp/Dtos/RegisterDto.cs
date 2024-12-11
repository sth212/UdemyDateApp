using System.ComponentModel.DataAnnotations;

namespace UdemyDateApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
