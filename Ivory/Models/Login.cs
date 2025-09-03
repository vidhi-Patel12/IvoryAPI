using System.ComponentModel.DataAnnotations;

namespace Ivory.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public int IvoryId { get; set; }
        public int OTP { get; set; }
        public bool IsValid { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
