using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace MTG.Common.DomainModels
{
    /// <summary>
    ///This class stores the data for a specific card from the CardDatabase
    ///cards are searched by name, and then the other values are saved in the class
    ///it should select the latest printing of the card
    /// </summary>
    public class Card
    {

        public int Id { get; set; }
        [Name("name")]
        public string? Name { get; set; }

        [Name("manaValue")]
        public string? CMC { get; set; }

        [Name("colors")]
        public string? Color { get; set; }

        [Name("type")]
        public string? Type { get; set; }

        [Name("power")]
        public string? Power { get; set; }

        [Name("toughness")]
        public string? Toughness { get; set; }

        [Name("loyalty")]
        public string? Loyalty { get; set; }

        public int DeckId { get; set; }

        public bool IsSideBoard { get; set; }

        /// <summary>
        /// Finds a card based on the name provided.
        /// Otherwise, returns null.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Card? FindCard(string name)
        {
            //path to the csv file. Change it to your location
            // Andreas bærbar path:
            //var scvPath = @"C:\Users\Bruger\OneDrive\Documents\GitHub\MTGDatabase\AllPrintingsSCV\cards.csv";

            // Andreas stationær path:
            var scvPath = @"C:\Users\andreas pc\Documents\GitHub\MTGDatabase\AllPrintingsSCV\cards.csv";

            // Casper path:
            //var scvPath = @"C:\projects\MTGDatabase\AllPrintingsSCV\cards.csv";

            using var reader = new StreamReader(scvPath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null

            });

            //The card is found using CsvHelper
            //this line generates a form of library of all the records in the database
            var records = csv.GetRecords<Card>();

            //each record is a card object.
            //it loops through each card object until it finds the on that matches the name written in the function
            foreach (var record in records)
            {
                if (string.Equals(record.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    //returns the card if found
                    return record;
                }
            }
            //returns null, if the card is not in the 
            return null;
        }
        public override string ToString()
        {
            return $"CMC: {CMC}\ncolor: {Color}\ntype: {Type}\npower: {Power}\ntoughness: {Toughness}\nloyalty: {Loyalty}";
        }


        /// <summary>
        /// Extracts the data for the searched card
        /// saves the data in the allocated variables
        /// </summary>
        public static void extract()
        {
            throw new NotImplementedException();
        }

    }
}
