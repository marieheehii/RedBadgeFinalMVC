﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.EventEntity
{
    public class EventCreate
    {

        [Required]
        [MaxLength(100, ErrorMessage = "Sorry, Your Title Cannot Exceed 20 Characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Sorry, Your Description Cannot Exceed 1000 Characters")]
        public string Description { get; set; }
    }
}
