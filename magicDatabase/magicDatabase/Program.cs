using Autofac;
using Microsoft.Extensions.DependencyInjection;
using MTG.Common;
using MTG.Common.DomainModels;
using MTG.Common.Repositories;

internal class Program
{
    static void Main(string[] args)
    {
        var searchString = "Jace, the Mind Sculptor";

        var card = Card.FindCard(searchString);

        if (card == null)
        {
            Console.WriteLine($"Card with name '{searchString}' not found in the database.");
        }
        else
        {
            Console.WriteLine(card);
        }

        using var db = new MagicContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        

        var repo = new DeckRepository(db);
        
        repo.AddCardToDeck(card, "The good deck");
        

    }
}

