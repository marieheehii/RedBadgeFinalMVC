using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;
using RedBadgeFinal.Models.Models.UserEntity;
using RedBadgeFinal.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.UserEntityServices
{
    public class UserEntityService : IUserEntityService
    {
        private readonly ApplicationDbContext _context;

        public UserEntityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(UserCreate model)
        {
            var userentity = new UserEntity
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            };
            _context.UserEntity.Add(userentity);
            var numberofchanges = await _context.SaveChangesAsync();
            return numberofchanges == 1;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var userentity = await _context.UserEntity.FindAsync(id);
            if(userentity != null)
            {
                _context.UserEntity.Remove(userentity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserDetail> GetUserDetails(int id)
        {
            var userentity = await _context.UserEntity.FirstOrDefaultAsync(entity => entity.Id == id);
            if (userentity is null)
            {
                return null;
            }
            return new UserDetail
            {
                Id = userentity.Id,
                Username = userentity.Username,
         
            };
        }

        public async Task<IEnumerable<UserListItem>> GetUserList()
        {
            var userentitys = await _context.UserEntity.Select(entity => new UserListItem
            {
                Id = entity.Id,
                Username = entity.Username,
            })
                .ToListAsync();
            return userentitys;
               
        }

        public async Task<bool> UpdateUser(int id, UserEdit model)
        {
            if(id != model.Id)
            {
                return false;
            }
            else
            {
                var usersInDb = await _context.UserEntity.FindAsync(model.Id);
                if (usersInDb != null) return false;

                usersInDb.Id = model.Id;
                usersInDb.Username = model.Username;
                usersInDb.Password = model.Password;

                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
