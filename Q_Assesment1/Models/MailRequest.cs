namespace Q_Assesment1.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
       public string Subject { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string GPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
       
        public Userdata Userdata { get; set; }

    }
}
