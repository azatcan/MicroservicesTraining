using System.ComponentModel.DataAnnotations;

namespace IdentityServerService.Api.Dtos
{
    public class SignupDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
