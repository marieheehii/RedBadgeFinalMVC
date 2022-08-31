using RedBadgeFinal.Models.Models.ParticipantsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.ParticipantServices
{
    public interface IParticipationService
    {
        Task<bool> CreateParticipant(CreateParticipant model);
        Task<IEnumerable<ListParticipants>> GetParticipantList();
        Task<DetailParticipant> GetParticipantDetail(int id);
        Task<bool> UpdateParticipant(int id, EditParticipant model);
        Task<bool> DeleteParticipant(int id);
    }
}
