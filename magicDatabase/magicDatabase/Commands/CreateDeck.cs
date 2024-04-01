using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class CreateDeck : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public CreateDeck(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }

        public int Execute(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of parameters found.");
                Console.WriteLine("Expected a single parameter");
                return 1;
            }

            var deckName = args[0];

            deckRepo.CreateDeck(deckName);
            Console.WriteLine("Deck created");

            return 0;
        }
    }
}
