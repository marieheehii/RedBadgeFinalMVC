using RedBadgeFinal.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.UserEntity
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Blog> Blogs { get; set; } = new List<Blog>();
        public List<Event_User> ScheduledEvents { get; set; } = new List<Event_User>();

    }
}
