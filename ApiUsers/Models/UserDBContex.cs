using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Models
{
    public class UserDBContex : DbContext
    {
        public UserDBContex(DbContextOptions<UserDBContex> options) : base(options) { 
        
        }

        public DbSet<User> User { get; set; }
        public DbSet<phones> phones { get; set; }
    }
}
