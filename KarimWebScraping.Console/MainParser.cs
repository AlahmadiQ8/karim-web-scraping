using System.Diagnostics;
using HtmlAgilityPack;

namespace KarimWebScraping.Console;

public class MainParser(HtmlDocument doc)
{
    public AdStats ParseAdStats()
    {
        var nodes = doc.DocumentNode.SelectNodes("//div[@class='property-details']//div[@class='pd-description'][1]//span");
        Debug.Assert(nodes.Count == 4);
        var rawText = nodes.Select(x => x.InnerText.Trim()).ToArray();
        return new AdStats(rawText[0], rawText[1], rawText[2], rawText[3]);
    }

    public ContactDetails ParseContactDetails()
    {
        var nodes = doc.DocumentNode.SelectNodes("//div[@class='property-details-right']//div");
        Debug.Assert(nodes.Count >= 4);
        var rawText = nodes.Select(x => x.InnerText.Trim()).ToArray();
        return new ContactDetails(rawText[0], rawText[1], rawText[2], rawText[3]);
    }

    public Details ParseDetails()
    {
        var nodes = doc.DocumentNode.SelectNodes("//div[@class='property-details']//div[@class='pd-description'][2]/ul/li//span");
        Debug.Assert(nodes.Count == 4);
        var rawText = nodes.Select(x => x.InnerText.Trim()).ToArray();
        return new Details(rawText[0], rawText[1], rawText[3]);
    }
}