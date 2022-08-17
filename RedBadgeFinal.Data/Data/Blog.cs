using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data.Data
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserEntityId { get; set; }
        [ForeignKey (nameof(UserEntityId))]
        public UserEntity UserEntity { get; set; }
        public List<EventEntity> eventEntities { get; set; } = new List<EventEntity>();
    }
}
