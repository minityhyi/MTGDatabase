using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class Copy : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public Copy(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }

        public int Execute(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Expected 1 parameter");
                return 1;
            }

            deckRepo.Copy(args[0]);
            return 0;
        }
    }
}
