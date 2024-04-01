using magicDatabase.Helpers;
using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class DeleteDeck : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public DeleteDeck(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }
        
        public int Execute(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments provided.");
                Console.WriteLine("Please provide the deck name to delete.");
                return 1;
            }
            var deckName = args[0];

            Console.WriteLine($"You are trying to delete the deck {deckName}.");
            Console.WriteLine("This will delete the deck and all cards added to the deck");
            Console.WriteLine("Are you sure you want to continue?");

            var delete = ConsoleHelpers.GetYesNo();
            if (!delete.HasValue)
            {
                Console.WriteLine("Could not understand the answer. Please try again.");
                return 1;
            }
            else if (!delete.Value)
            {
                Console.WriteLine("Cancelling the deletion");
                return 1;
            }

            deckRepo.DeleteDeck(deckName);

            Console.WriteLine($"The deck '{deckName}' successfully deleted");

            return 0;
        }
    }
}
