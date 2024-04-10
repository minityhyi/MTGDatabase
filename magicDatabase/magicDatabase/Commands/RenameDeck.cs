using magicDatabase.Helpers;
using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class RenameDeck : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        // Constructor
        public RenameDeck(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }

        public int Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of parameters found.");
                Console.WriteLine("Expected two parameters");
                return 1;
            }

            string deckName = args[0];
            string newName = args[1];

            deckRepo.RenameDeck(deckName, newName);
            return 0;
        }
    }
}