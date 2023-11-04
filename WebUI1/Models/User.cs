using Microsoft.AspNetCore.Identity;

namespace WebUI1.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
