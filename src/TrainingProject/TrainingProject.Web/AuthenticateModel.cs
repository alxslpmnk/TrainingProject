using System.ComponentModel.DataAnnotations;

namespace TrainingProject.Web
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}