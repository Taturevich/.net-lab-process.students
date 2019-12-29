using System.ComponentModel.DataAnnotations;

namespace WebService.Api.Models
{
    public class UserAuthModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}