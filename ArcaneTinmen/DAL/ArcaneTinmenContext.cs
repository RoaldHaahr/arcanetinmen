using ArcaneTinmen.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ArcaneTinmen.DAL
{
    public class ArcaneTinmenContext : DbContext
    {
        public ArcaneTinmenContext() : base("ArcaneTinmenContext") { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<OrderPlacement> OrderPlacements { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Sleeve> Sleeves { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameSleeve> GameSleeves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}