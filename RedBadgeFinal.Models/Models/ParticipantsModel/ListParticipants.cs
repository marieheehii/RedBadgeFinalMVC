using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.ParticipantsModel
{
    public class ListParticipants
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public int EventEntityId { get; set; }
    }
}
