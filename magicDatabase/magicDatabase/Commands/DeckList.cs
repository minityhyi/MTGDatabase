using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class DeckList : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public DeckList(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }

        public int Execute(string[] args)
        {
            var decks = deckRepo.GetAllDecks();

            decks.ForEach(d => Console.WriteLine(d));
            return 0;
        }
    }
}
