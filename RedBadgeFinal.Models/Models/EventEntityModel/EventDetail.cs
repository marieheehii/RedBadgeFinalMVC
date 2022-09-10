using Microsoft.AspNetCore.Http;
using RedBadgeFinal.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.EventEntityModel
{
    public class EventDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public List<Participants> Participants { get; set; } = new List<Participants>();
        public int BlogId { get; set; }
    }
}
