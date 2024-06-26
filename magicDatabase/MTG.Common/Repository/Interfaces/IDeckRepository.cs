﻿using MTG.Common.DomainModels;

namespace MTG.Common.Repository.Interfaces
{
    public interface IDeckRepository
    {
        void AddCardToDeck(string deckName, Card card, bool isMain);
        void CreateDeck(string deckName);
        List<string> GetAllDecks();
        void DeleteDeck(string deckName);
        void RemoveCard(string deckName, string cardName);
        void RenameDeck(string deckName, string newName);
        List<Card> GetDeck(string deckName);
        void GetMain(string deckName);
        void GetSide(string deckName);
        void ExportDeck(string deckName);
        void ImportDeck(string path);
        void Copy(string deckName);
    }
}
