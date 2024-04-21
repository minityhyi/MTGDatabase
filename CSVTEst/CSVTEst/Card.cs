using CsvHelper.Configuration.Attributes;
namespace CSVTEst;

public class Card
{
    [Name("name")]
    public string? Name { get; set; }

    [Name("manaValue")]
    public string? CMC { get; set; }

    [Name("color")]
    public string? Color { get; set; }

    [Name("type")]
    public string? Type { get; set; }

    [Name("subType")]
    public string? Subtype { get; set; }

    [Name("power")]
    public string? Power { get; set; }

    [Name("toughness")]
    public string? Toughness { get; set; }

    [Name("loyalty")]
    public string? Loyalty { get; set; }
}

