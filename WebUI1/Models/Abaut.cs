using System.ComponentModel.DataAnnotations;

namespace WebUI1.Models
{
    public class Abaut
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }

    }
}
