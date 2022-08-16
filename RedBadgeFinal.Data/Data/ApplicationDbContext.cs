using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;

namespace RedBadgeFinal.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Event_User> ScheduledEvents { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<EventEntity> Events { get; set; }
    }
}