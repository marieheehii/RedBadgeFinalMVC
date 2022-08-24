using Microsoft.AspNetCore.Identity;
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
        public string UserEntityId { get; set; }
        [ForeignKey (nameof(UserEntityId))]
        public IdentityUser UserEntity { get; set; }
        public List<EventEntity> EventEntities { get; set; } = new List<EventEntity>();
    }
}
