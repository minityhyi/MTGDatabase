using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Markup;

internal class Program
{
    class CardDatabase
    {
        //contains every card in magic
        //can be extracted from the file cards.scv in the directory AllPrintingsSCV

    }

    class Deck
    {
        public List<Card>? decklist { get; set; }

        public void addCardToSQL()
        {
            //imports card to SQLite3 Database

        }

    }

    class Card
    {
        //this class stores the data for a specific card from the CardDatabase
        //cards are searched by name, and then the other values are saved in the class
        //it should select the latest printing of the card

        public string name { get; set; }
        public string CMC { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public string loyalty { get; set; }

        public Card(string na)
        {
            name = na;
        }

        public void findCard(string name)
        {
            //path to the csv file. Change it to your location
            var scvPath = @"C:\Users\andreas pc\Documents\GitHub\MTGDatabase\AllPrintingsSCV\cards.csv";

            try
            {
                using (var reader = new StreamReader(scvPath))
                {
                    while (reader.EndOfStream == false)
                    {
                        var content = reader.ReadLine();
                        var values = content.Split(",").ToList();
                        if (values[51].Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            CMC = values[50];
                            color = values[11];
                            if (color.Length == 0)
                            {
                                color = "colorless";
                            }
                            type = values[76];
                            subtype = values[72];
                            power = values[56];
                            toughness = values[70];
                            loyalty = values[48];

                            Console.WriteLine($"CMC: {CMC}\ncolor: {color}\ntype: {type}\nsubtype: {subtype}\npower: {power}\ntoughness: {toughness}\nloyalty: {loyalty}");

                            
                        }

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
            if (CMC == null)
            {
                Console.WriteLine($"Card with name '{name}' not found in the database.");
            }
        }

        public static void extract()
        {
            //extracts the data for the searched card
            //saves the data in the allocated variables
        }

        public static void addCardToDeck()
        {
            //adds the card to the decklist
        }


    }

    static bool rowHasData(List<string> cells)
    {
        return cells.Any(x => x.Length > 0);
    }

    static void Main(string[] args)
    {
        CardDatabase db = new CardDatabase();
        Card car = new Card("Sol Ring");
        car.findCard(car.name);

    }
}

