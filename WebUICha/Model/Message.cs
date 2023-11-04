using System.ComponentModel.DataAnnotations;

namespace WebUICha.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
