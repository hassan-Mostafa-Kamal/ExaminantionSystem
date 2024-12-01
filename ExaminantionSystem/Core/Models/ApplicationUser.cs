using Microsoft.AspNetCore.Identity;


namespace Core.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
