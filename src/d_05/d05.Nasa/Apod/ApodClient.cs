using System.Text.Json;

public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
{
    private string _srcUrl { get; set; }
    
    public ApodClient(string key)
    {
        _srcUrl = "https://api.nasa.gov/planetary/apod?api_key=" + key;
    }
    
    public async Task<MediaOfToday[]> GetAsync(int input)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(_srcUrl + "&count=" + input);
        // var res = response.EnsureSuccessStatusCode();
        // var responseBody = await response.Content.ReadAsStringAsync();
        // var doc = System.Text.Json.JsonDocument.Parse(responseBody);
        // var data1 = JsonSerializer.Deserialize<string[]>("[a, b, c]");
        // var data = doc.RootElement.Deserialize<MediaOfToday[]>();
        if (!response.IsSuccessStatusCode)
        {
            throw new ArgumentException($"GET\n\"{_srcUrl + "&count=" + input}\" returned {response.StatusCode}:\n" + await response.Content.ReadAsStringAsync());
        }
        var responseBody = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(responseBody);
        var data = doc.RootElement.Deserialize<MediaOfToday[]>();
        return data;
    }
}
