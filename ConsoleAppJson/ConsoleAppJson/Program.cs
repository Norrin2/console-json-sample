using ConsoleAppJson;
using System.Text.Json;

public class Program
{
    static async Task Main()
    {
        string apiUrl = "https://api.sampleapis.com/codingresources/codingResources";

        var codingResources = await FetchCodingResources(apiUrl);

        var uniqueTopics = codingResources.SelectMany(x => x.Topics)
                                          .Distinct();
                                          

        Console.WriteLine("Unique Topics:");
        foreach (var topic in uniqueTopics)
        {
            Console.WriteLine(topic);
        }

        Console.ReadLine();
    }

    static async Task<IEnumerable<CodingResource>> FetchCodingResources(string apiUrl)
    {
        IEnumerable<CodingResource> codingResources = new List<CodingResource>();

        using var httpClient = new HttpClient();
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                codingResources = JsonSerializer.Deserialize<IEnumerable<CodingResource>>(jsonString, options);
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }

        return codingResources;
    }
}
