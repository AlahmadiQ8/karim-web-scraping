
using System.Globalization;

namespace KarimWebScraping.Console;

public class CsvWriter
{
    private readonly string _outputPath;
    private readonly CsvHelper.CsvWriter _csvWriter;
    private readonly IList<CsvRecord> _records = new List<CsvRecord>();
    
    public CsvWriter(string outputPath)
    {
        _outputPath = outputPath;
    }

    public void AddRecord(string url, AdStats adStats, Details details, ContactDetails contactDetails)
    {
        _records.Add(CreateCsvRecord(url, adStats, details, contactDetails));
    }

    public void WriteToCsv()
    {
        using var writer = new StreamWriter(_outputPath);
        using var csvWriter = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(_records);
    }

    private CsvRecord CreateCsvRecord(string url, AdStats adStats, Details details, ContactDetails contactDetails)
    {
        return new CsvRecord
        {
            Url = url,
            AdId = adStats.AdId,
            PostedOn = adStats.PostedOn,
            Type = adStats.Type,
            Condition = adStats.Condition,
            Price = contactDetails.Price,
            Username = contactDetails.Username,
            PhoneNumber = contactDetails.PhoneNumber,
            Email = contactDetails.Email,
            City = details.City,
            Manufacturer = details.ManufactureYear,
            FuelType = details.FuelType
        };
    }
}