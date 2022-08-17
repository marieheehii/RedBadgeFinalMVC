﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data.Data
{
    public class EventEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Participants { get; set; }
        public int BlogId { get; set; }

        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }
    }
}
