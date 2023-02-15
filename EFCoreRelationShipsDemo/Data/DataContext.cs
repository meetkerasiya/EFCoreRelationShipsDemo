using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationShipsDemo.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Weapon>  Weapons { get; set; }
    }
}
