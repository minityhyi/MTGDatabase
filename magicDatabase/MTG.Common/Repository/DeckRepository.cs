
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;
using MTG.Common.DomainModels;
using MTG.Common.Repository.Interfaces;
using magicDatabase.RepHelp;

namespace MTG.Common.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly MagicContext context;

        public DeckRepository(MagicContext context) {
            this.context = context;
        }
        /// <summary>
        /// adds card to specific deck
        /// </summary>
        /// <param name="deckName"></param>
        /// <param name="card"></param>
        /// <param name="isMain"></param>
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
            //there is a limit of 15 cards in a sideboard
            //this stops the user from adding anymore
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
        /// <summary>
        /// Creates a deck
        /// </summary>
        /// <param name="deckName"></param>
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
        /// <summary>
        /// Deletes a deck
        /// </summary>
        /// <param name="deckName"></param>
        public void DeleteDeck(string deckName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            var cards = context.Cards.Where(c => c.DeckId == deck.Id).ToList();
            
            context.Decks.Remove(deck);
            context.Cards.RemoveRange(cards);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes a card from a deck
        /// </summary>
        /// <param name="deckName"></param>
        /// <param name="cardName"></param>
        public void RemoveCard(string deckName, string cardName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            Card? card = context.Cards.FirstOrDefault(c => c.DeckId == deck.Id & c.Name == cardName);
            ArgumentNullException.ThrowIfNull(card);

            context.Cards.Remove(card);
            Console.WriteLine($"Card {cardName} removed from deck {deckName}");

            context.SaveChanges();
        }
        /// <summary>
        /// Renames a deck. Where you first write the existing deckanme, and afterwards, what you want to call it
        /// </summary>
        /// <param name="deckName"></param>
        /// <param name="newName"></param>
        public void RenameDeck(string deckName, string newName)
        {
            Deck deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            deck.DeckName = newName;
            context.Update(deck);
            context.SaveChanges();
        }

        /// <summary>
        /// prints the decklist of a deck in the console
        /// </summary>
        /// <param name="deckName"></param>
        public void GetDeck(string deckName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            var cards = context.Cards.Where(c => c.DeckId == deck.Id).ToList();
            
            foreach(Card card in cards)
            {
                Console.WriteLine(card.Name);
            }
            
        }
        /// <summary>
        /// prints the mainboard of a deck in the console
        /// </summary>
        /// <param name="deckName"></param>
        public void GetMain(string deckName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            var cards = context.Cards.Where(c => c.DeckId == deck.Id & c.IsSideBoard == false).ToList();
            foreach(Card card in cards)
            {
                Console.WriteLine(card.Name);
            }
        }
        /// <summary>
        /// prints the sideboard of a deck in console
        /// </summary>
        /// <param name="deckName"></param>
        public void GetSide(string deckName)
        {
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);

            var cards = context.Cards.Where(c => c.DeckId == deck.Id & c.IsSideBoard == true).ToList();
            foreach(Card card in cards)
            {
                Console.WriteLine(card.Name);
            }
        }

        /// <summary>
        /// Exports a deck to a text file
        /// </summary>
        /// <param name="deckName"></param>
        public void ExportDeck(string deckName)
        {            
            // filepath Andreas stationaer
            //string basePath = $@"C:\Users\andreas pc\Documents\GitHub\MTGDatabase\DeckTextFiles\";

            // filepath Andreas Bærbar
            string basePath = @$"C:\Users\Bruger\OneDrive\Documents\GitHub\MTGDatabase\DeckTextFiles\";
            string filePath = $"{basePath}{deckName}.txt";

            int counter = 1;

            while(File.Exists(filePath))
            {
                filePath = $"{basePath}{deckName}{counter}.txt";
                counter ++;
            }
            
            //Finds the cards from the deck
            var deck = context.Decks.FirstOrDefault(d => d.DeckName == deckName);
            ArgumentNullException.ThrowIfNull(deck);
            var mainCards = context.Cards.Where(c => c.DeckId == deck.Id & c.IsSideBoard == false).Select(c=> c.Name).ToList();
            var sideCards = context.Cards.Where(c => c.DeckId == deck.Id & c.IsSideBoard == true).Select(c=> c.Name).ToList();

            mainCards = RepositoryHelpers.DeckFormat(mainCards);
            sideCards = RepositoryHelpers.DeckFormat(sideCards);


            // Create a StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Mainboard:");
                foreach(string? c in mainCards)
                {
                    writer.WriteLine(c);
                }
                writer.WriteLine("\nSideboard:");
                foreach(string? c in sideCards)
                {
                    writer.WriteLine(c);
                }
                Console.WriteLine($"The deck {deckName} have been exported");
            }
        }

        
        //methode: impoert decklist: imports text file

    }
}