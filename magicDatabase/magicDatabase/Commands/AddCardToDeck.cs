using MTG.Common.DomainModels;
using MTG.Common.Repository.Interfaces;

namespace magicDatabase.Commands
{
    public class AddCardToDeck : ISyncCommand
    {
        private readonly IDeckRepository deckRepo;

        public AddCardToDeck(IDeckRepository deckRepo)
        {
            this.deckRepo = deckRepo;
        }
        public int Execute(string[] args)
        {
            if (args.Length != 2 & args.Length != 3)
            {
                Console.WriteLine("Incorrect number of parameters found.");
                Console.WriteLine("Expects the parameter deckname, card and (optionally) side, f or false to add the deck to sideboard");
                return 1;
            }

            string deck = args[0];
            var decks = deckRepo.GetAllDecks();
            if(!decks.Contains(deck))
            {
                Console.WriteLine($"No Deck with the name: {deck}, check the DeckList and find you deck");
            }

            string cardName = args[1];
            Card? card = Card.FindCard(cardName);
            if( card == null)
            {
                Console.WriteLine($"No card with the name: {cardName}");
                return 1;
            }

            bool isMain = true;

            if(args.Length == 3)
            {
                string? main = args[2].ToLower();

                if( main == "f" || main == "false" || main == "side")
                {
                    isMain = false; 
                }

                if( main != "f" || main != "false" || main != "side")
                {
                    Console.WriteLine("The third parameter should be 'f' 'false' or 'side' to indicate that the card should be added to the sideboard");
                }

            }
            


            deckRepo.AddCardToDeck(deck, card, isMain);
            return 0;


            
        }
    }
}