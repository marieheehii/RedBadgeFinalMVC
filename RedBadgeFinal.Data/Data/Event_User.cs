using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data.Data
{
    public class Event_User
    {
        public int Id { get; set; }
        public string UserEntityId { get; set; }
        [ForeignKey(nameof(UserEntityId))]
        public UserEntity UserEntity { get; set; }
        public int EventEntityId { get; set; }
        [ForeignKey(nameof(EventEntityId))]
        public EventEntity EventEntity { get; set; }
    }
}
