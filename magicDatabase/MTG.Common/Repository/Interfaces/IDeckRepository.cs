using MTG.Common.DomainModels;

namespace MTG.Common.Repository.Interfaces
{
    public interface IDeckRepository
    {
        void AddCardToDeck(string deckName, Card card, bool isMain);
        void CreateDeck(string deckName);
        List<string> GetAllDecks();
        void DeleteDeck(string deckName);
        void RemoveCard(string deckName, string CardName);

    }
}
