using System;
using System.Collections.Generic;
using System.Text;

namespace Brainstorming.Model.Model
{
    class User
    {
        public Guid AuthId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int TotalClicks { get; set; }
        public int TotalPageViews { get; set; }
        public string IpAddress { get; set; }
    }
}
