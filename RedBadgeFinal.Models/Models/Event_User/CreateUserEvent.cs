using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.Event_User
{
    public class CreateUserEvent
    {
        public string UserEntityId { get; set; }
        public int EventEntityId { get; set; }
    }
}
