
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;
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
        
        //Adds a card to a specific deck.
        public void AddCardToDeck(string deckName, Card card, bool isMain=true) 
        {
            var deckId = context.Decks.FirstOrDefault(d => d.DeckName == deckName)?.Id;

            card.DeckId = deckId.Value;

            //By default the card is added to the mainboard, if not then it is added to sideboard
            if(isMain != true)
            {
                card.IsSideBoard = true;
            }

            if(isMain == true)
            {
                card.IsSideBoard = false;
            }

            var cards = context.Cards.Where(c => c.DeckId == deckId & c.IsSideBoard == true);
            if(cards.Count() >= 15)
            {
                Console.WriteLine("The sideboard is full (limit = 15), delete sideboard cards to add more");
            } 
            
            //No more than 4 of the same cards in a deck
            //This looks for cards that booth have the given deckId and card
            cards = context.Cards.Where(c => c.DeckId == deckId & c.Name == card.Name);
            if(cards.Count() >= 4)
            {
                Console.WriteLine("Already four cards in he deck");
                return;
            }

            if(cards.Count() < 4)
            {
                context.Cards.Add(card);
                Console.WriteLine($"The card {card.Name} have been added to {deckName}");
                context.SaveChanges();   
            }

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

        public void RemoveCard(string deckName, string CardName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            Card? card = context.Cards.FirstOrDefault(c => c.DeckId == deck.Id & c.Name == CardName);
            ArgumentNullException.ThrowIfNull(card);

            context.Cards.Remove(card);
            Console.WriteLine($"Card {CardName} removed from deck {deckName}");

            context.SaveChanges();
        }

        public void RenameDeck(string deckName, string newName)
        {
            Deck deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            deck.DeckName = newName;
            context.Update(deck);
            context.SaveChanges();
        }


        //Methode: get deck
        //methode: get mainboard
        //methode: get Sideboard
        //methode: impoert decklist: imports text file
        //Methode: Export Decklist: generates text file

    }
}