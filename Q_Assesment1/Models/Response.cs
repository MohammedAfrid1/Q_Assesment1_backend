using System.Collections.Generic;

namespace Q_Assesment1.Models
{
    public class Response
    {
        public bool error { get; set; }
        public string? message { get; set; }
        public int count { get; set; }
        public List<User>? Userdata { get; set; }
    }
}
