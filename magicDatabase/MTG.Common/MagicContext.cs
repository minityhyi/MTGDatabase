using Microsoft.EntityFrameworkCore;
using MTG.Common.DomainModels;

namespace MTG.Common
{
    public class MagicContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }

        private string ConnectionString { get; }

        public MagicContext()
        {
            // Andreas connection string
            //ConnectionString = @"Server=localhost\SQLEXPRESS;Initial Catalog=mtg.db;Integrated Security=True;TrustServerCertificate=True;";

            // Casper connection string
            ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=mtg.db;Integrated Security=True;TrustServerCertificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}