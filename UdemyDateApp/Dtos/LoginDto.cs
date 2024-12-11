using System.ComponentModel.DataAnnotations;

namespace UdemyDateApi.Dtos
{
    public class LoginDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
