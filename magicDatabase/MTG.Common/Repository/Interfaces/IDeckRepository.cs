using MTG.Common.DomainModels;

namespace MTG.Common.Repository.Interfaces
{
    public interface IDeckRepository
    {
        void AddCardToDeck(Card card, string deckName);
        void CreateDeck(string deckName);
    }
}
