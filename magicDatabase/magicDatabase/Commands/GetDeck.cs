using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class GetDeck : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public GetDeck(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }

        public int Execute(string[] args)
        {

            if(args.Length != 1)
            {
                Console.WriteLine("Incorrect number of parameters found");
                Console.WriteLine("Expected two parameters");
                return 1;
            }

            string deckName = args[0];

            deckRepo.GetDeck(deckName);



            return 0;
        }
    }
}