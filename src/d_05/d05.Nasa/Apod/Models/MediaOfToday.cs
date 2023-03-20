using System.Text.Json.Serialization;
using System.Globalization;

public class MediaOfToday
{
    [JsonPropertyName("copyright")]
    public string? Copyright { get; set; }
    [JsonPropertyName("date")]
    public string? Date { get; set; }
    [JsonPropertyName("explanation")]
    public string? Explanation { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public override string ToString()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        var copyright = Copyright != null ? $" by {Copyright}" : "";
        return $"{Date:d}\n‘{Title}’ {copyright}\n{Explanation}\n{Url}\n";
    }
}