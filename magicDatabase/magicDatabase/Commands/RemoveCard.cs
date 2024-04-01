using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class RemoveCard : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public RemoveCard(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }
        public int Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of parameters found.");
                Console.WriteLine("Expected a two parameters");
                return 1;
            }

            var deck = args[0];
            var card = args[1];

            deckRepo.RemoveCard(deck, card);



            return 0;


            
        }
    }
}