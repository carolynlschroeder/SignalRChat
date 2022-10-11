using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SignalRChat.Data
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        
        public string From { get; set; }

        public string To { get; set; }
        public string Body { get; set; }

        public DateTime DateSent { get; set; }

    }
}
