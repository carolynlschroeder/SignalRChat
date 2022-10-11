namespace SignalRChat.Models
{
    public class MessageDto
    {
        public MessageDto(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
        }

        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }

        public DateTime DateSent { get; set; }

        public string CSS => Mine ? "sent" : "received";
    }
}
