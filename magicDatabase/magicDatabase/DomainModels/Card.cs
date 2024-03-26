namespace magicDatabase.DomainModels
{
    /// <summary>
    ///This class stores the data for a specific card from the CardDatabase
    ///cards are searched by name, and then the other values are saved in the class
    ///it should select the latest printing of the card
    /// </summary>
    public class Card
    {
        public string? Name { get; set; }
        public string? CMC { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public string? Subtype { get; set; }
        public string? Power { get; set; }
        public string? Toughness { get; set; }
        public string? Loyalty { get; set; }

        public Card(string na)
        {
            Name = na;
        }

        /// <summary>
        /// Finds a card based on the name provided.
        /// Otherwise, returns null.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Card? FindCard(string name)
        {
            //path to the csv file. Change it to your location
            var scvPath = @"C:\projects\MTGDatabase\AllPrintingsSCV\cards.csv";
            try
            {
                using var reader = new StreamReader(scvPath);
                
                while (reader.EndOfStream == false)
                {
                    var content = reader.ReadLine();
                    var values = content.Split(",").ToList();
                    if (values[51].Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        var CMC = values[50];
                        var color = values[11];
                        if (string.IsNullOrEmpty(color))
                        {
                            color = "colorless";
                        }

                        var result = new Card(name)
                        {
                            Type = values[76],
                            Subtype = values[72],
                            Power = values[56],
                            Toughness = values[70],
                            Loyalty = values[48],
                            CMC = CMC,
                            Color = color
                        };

                        return result;
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }

            return null;
        }

        public override string ToString()
        {
            return $"CMC: {CMC}\ncolor: {Color}\ntype: {Type}\nsubtype: {Subtype}\npower: {Power}\ntoughness: {Toughness}\nloyalty: {Loyalty}";
        }

        static bool rowHasData(List<string> cells)
        {
            return cells.Any(x => x.Length > 0);
        }

        /// <summary>
        /// Extracts the data for the searched card
        /// saves the data in the allocated variables
        /// </summary>
        public static void extract()
        {
            throw new NotImplementedException();
        }

        public static void addCardToDeck()
        {
            //adds the card to the decklist
        }
    }
}
