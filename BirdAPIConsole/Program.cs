using System.Text.Json;
using BirdAPIConsole;

Console.WriteLine("Fetching Birds Data...");

string url = "https://fake-brids-apis.vercel.app/api/v1/birds";

using HttpClient client = new HttpClient();

Console.OutputEncoding = System.Text.Encoding.UTF8;

try
{
    string response = await client.GetStringAsync(url);
    var birds = JsonSerializer.Deserialize<List<BirdModel>>(response);

    if (birds != null)
    {
        Console.WriteLine($"Found {birds.Count} birds:");
        Console.WriteLine("--------------------------------------------------");
        foreach (var bird in birds)
        {
            Console.WriteLine($"ID: {bird.Id}");
            Console.WriteLine($"English Name: {bird.BirdEnglishName}");
            Console.WriteLine($"Myanmar Name: {bird.BirdMyanmarName}");
            // Handle potentially null or short descriptions
            string desc = bird.Description ?? "";
            if (desc.Length > 100) desc = desc.Substring(0, 100) + "...";
            Console.WriteLine($"Description: {desc}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
