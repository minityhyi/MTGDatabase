namespace magicDatabase.DomainModels
{
    public class Deck
    {
        public int Id { get; set; }
        public List<Card>? Decklist { get; set; }
        public string? DeckName { get; set; }




    }
}
