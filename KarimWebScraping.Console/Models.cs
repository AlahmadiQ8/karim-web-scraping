using System.Globalization;

namespace KarimWebScraping.Console;

public record AdStats(string PostedOn, string AdId, string Type, string Condition);
public record ContactDetails(string Price, string Username, string PhoneNumber, string Email);
public record Details(string City, string ManufactureYear, string FuelType);

public record CsvRecord
{
    public required string Url { get; init; }
    public required string AdId { get; init; } 
    public required string PostedOn { get; init; } 
    public required string Type { get; init; } 
    public required string Condition { get; init; } 
    public required string Price { get; init; } 
    public required string Username { get; init; } 
    public required string PhoneNumber { get; init; } 
    public required string Email { get; init; } 
    public required string City { get; init; } 
    public required string Manufacturer { get; init; } 
    public required string FuelType { get; init; } 
}

public class UrlRecord
{
    public string Url { get; set; }
}