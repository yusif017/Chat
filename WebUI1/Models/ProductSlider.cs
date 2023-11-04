using System.ComponentModel.DataAnnotations;

namespace WebUI1.Models
{
    public class ProductSlider
    {
        public int Id { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
