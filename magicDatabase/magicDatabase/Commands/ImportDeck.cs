
using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class ImportDeck : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public ImportDeck(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }

        public int Execute(string[] args)
        {

            if(args.Length != 1)
            {
                Console.WriteLine("Incorrect number of parameters found");
                Console.WriteLine("Expected one parameters");
                return 1;
            }

            string filePath = args[0];

            bool pathCheck = Path.IsPathRooted(filePath) && !string.IsNullOrWhiteSpace(Path.GetFullPath(filePath));

            if(pathCheck == false)
            {
                Console.WriteLine("Please provide filepath for the .txt file you want to import");
                return 1;
            }
            

            deckRepo.ImportDeck(filePath);

            return 0;
        }
    }
}