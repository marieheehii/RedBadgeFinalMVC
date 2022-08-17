using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.Blog
{
    public class BlogCreate
    {
        [Required]
        [MaxLength(30, ErrorMessage ="Sorry, Your Title Cannot Exceed 20 Characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Sorry, Your Description Cannot Exceed 300 Characters")]
        public string Description { get; set; }

    }
}
