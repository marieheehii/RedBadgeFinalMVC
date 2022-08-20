using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedBadgeFinal.Data.Data;

namespace RedBadgeFinal.Models.Models.BlogModel
{
    public class BlogDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<EventEntity> EventEntities { get; set; } = new List<EventEntity>();
    }
}
