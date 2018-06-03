using System.Collections.Generic;

namespace Twitstagram.Models
{
    public class Home
    {
        public List<string> TimeLine { get; set; }

        public string UserName { get; set; }

        public List<string> Likes { get; set; }
    }
}