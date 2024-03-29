using magicDatabase.DomainModels;

namespace magicDatabase.Repositories
{
    public class DeckRepository
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