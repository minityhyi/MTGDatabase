using MTG.Common.DomainModels;

namespace magicDatabase.Commands
{
    public class SearchCard : ISyncCommand
    {
        public int Execute(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of parameters found.");
                Console.WriteLine("Expected a single parameter");
                return 1;
            }

            var searchString = args[0];

            var card = Card.FindCard(searchString);
            if (card == null)
            {
                Console.WriteLine("Search did not find a result");
            }
            else
            {
                Console.WriteLine($"Found card:\n{card}");
            }
            return 0;
        }
    }
}
