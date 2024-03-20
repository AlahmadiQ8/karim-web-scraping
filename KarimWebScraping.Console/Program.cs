// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using HtmlAgilityPack;
using KarimWebScraping.Console;
using CsvWriter = KarimWebScraping.Console.CsvWriter;

// if (args.Length != 2)
// {
//     throw new Exception("put correct arguments");
// }
// var urlsFilePath = args[0];
// var outputPath = args[1];

var urlsFilePath = @"C:\Users\Asus\Dev\karim-web-scraping\input-links\jeddah.csv";
var outputPath = @"C:\Users\Asus\Dev\karim-web-scraping\output\output-jeddah.csv";

var urlList = LoadUrls(urlsFilePath);

var csvWriter = new CsvWriter(outputPath);

for (int i = 0; i < urlList.Count; i++)
{
    var urlRecord = urlList[i];
    Console.WriteLine($"processing url {i}: {urlRecord.Url}");
    var web = new HtmlWeb
    {
        AutoDetectEncoding = true
    };
    var htmlDoc = web.Load(urlRecord.Url);
    var parser = new MainParser(htmlDoc);
    csvWriter.AddRecord(
        urlRecord.Url,
        parser.ParseAdStats(),
        parser.ParseDetails(),
        parser.ParseContactDetails()
    );
}

csvWriter.WriteToCsv();
Console.WriteLine($"wrote output to {outputPath}");

IList<UrlRecord> LoadUrls(string inputPath)
{
    using var reader = new StreamReader(inputPath);
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
    var records = csv.GetRecords<UrlRecord>();
    return records.ToList();
}