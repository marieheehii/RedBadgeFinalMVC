using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.Models.ParticipantsModel
{
    public class EditParticipant
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Sorry, Your Name Cannot Exceed 20 Characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Sorry, Your Name Cannot Exceed 20 Characters")]
        public string LastName { get; set; }

        [EmailAddress]
        public string email { get; set; }
        public int EventEntityId { get; set; }
    }
}
