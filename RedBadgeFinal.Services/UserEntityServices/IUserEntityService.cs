using RedBadgeFinal.Models.Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.UserEntityServices
{
    public interface IUserEntityService
    {
        Task<bool> CreateUser(UserCreate model);
        Task<IEnumerable<UserListItem>> GetUserList();
        Task<UserDetail> GetUserDetails(int id);
        Task<bool> UpdateUser(int id, UserEdit model);
        Task<bool> DeleteUser(int id);
    }
}
