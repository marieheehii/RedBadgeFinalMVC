using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data.Data
{
    public class UserEntity 
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Blog> Blogs { get; set; } = new List<Blog>();
        //public List<Event_User> ScheduledEvents { get; set; } = new List<Event_User>();

    }
}
