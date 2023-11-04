using Microsoft.AspNetCore.Identity;

namespace WebUICha.Model
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
