using magicDatabase.DomainModels;
using Microsoft.EntityFrameworkCore;

public class MagicContext : DbContext
{
    public DbSet<Card> Cards {get; set;}
    public DbSet<Deck> Decks {get; set;}
    
    public string ConnectionString {get;}

    public MagicContext()
    {
        //Database=mtg.db;Trusted_Connection=True;
        ConnectionString = @"Server=localhost\SQLEXPRESS;Initial Catalog=mtg.db;Integrated Security=True;TrustServerCertificate=True;";

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

}