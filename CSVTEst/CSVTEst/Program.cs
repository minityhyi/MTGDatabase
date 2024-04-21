using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using CSVTEst;

string inputFile = @"C:\Users\andreas pc\Documents\GitHub\MTGDatabase\AllPrintingsSCV\cards.csv";
string outputFile = @"C:\Users\andreas pc\Documents\GitHub\MTGDatabase\AllPrintingsSCV\filtered-cards.csv";
List<Card> outputRecords = new();

using var reader = new StreamReader(inputFile);
using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
{
    HeaderValidated = null,
    MissingFieldFound = null

});

var records = csv.GetRecords<Card>();


int x = 0;
foreach (var record in records)
{
    if(record.Name.StartsWith("S"))
    {
        Console.WriteLine(record.Name);
    }
}