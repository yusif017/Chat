using System.ComponentModel.DataAnnotations;

namespace WebUI1.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
