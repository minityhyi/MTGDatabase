
using MTG.Common.DomainModels;
using MTG.Common.Repository.Interfaces;

namespace MTG.Common.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly MagicContext context;

        public DeckRepository(MagicContext context) {
            this.context = context;
        }
        
        public void AddCardToDeck(Card card, string deckName) 
        {
            var deckId = context.Decks.FirstOrDefault(d => d.DeckName == deckName)?.Id;
            if (!deckId.HasValue) {
                return;
            }

            card.DeckId = deckId.Value;
            context.Cards.Add(card);
            context.SaveChanges();
        }

        public void CreateDeck(string deckName)
        {
            context.Decks.Add(new Deck{
                DeckName = deckName
            });
            context.SaveChanges();
        }

        public List<string> GetAllDecks()
        {
            return context.Decks.Where(d => d.DeckName != null).Select(d => d.DeckName).AsEnumerable().Cast<string>().ToList();
        }

        public void DeleteDeck(string deckName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            var cards = context.Cards.Where(c => c.DeckId == deck.Id).ToList();
            
            context.Decks.Remove(deck);
            context.Cards.RemoveRange(cards);
            context.SaveChanges();
        }

        //Methode:Add card object to DeckSQL
        //Methode:Remove card object to DeckSQL
        //Mothode: Add To Sideboard
        //Methode: Create new deck
        //Methode: Delete Deck
        //Methode: Rename Deck
        //Methode: get deck
        //methode: get mainboard
        //methode: get Sideboard
        //methode: impoert decklist: imports text file
        //Methode: Export Decklist: generates text file

    }
}