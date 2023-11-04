using System.ComponentModel.DataAnnotations;

namespace WebUI1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
