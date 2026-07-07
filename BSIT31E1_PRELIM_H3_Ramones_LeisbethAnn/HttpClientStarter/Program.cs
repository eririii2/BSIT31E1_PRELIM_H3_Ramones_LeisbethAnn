using System.Text;

using var client = new HttpClient();

while (true)
{
    Console.Clear();

    Console.WriteLine("A - Get");
    Console.WriteLine("B - Post");
    Console.WriteLine("C - Put");
    Console.WriteLine("D - Delete");
    Console.WriteLine("E - Exit");
    Console.Write("Enter input: ");

    string? choice = Console.ReadLine()?.ToUpper();

    if (choice == "A")
    {
        response = await client.GetAsync("https://localhost:7135/WeatherForecast/1");
    }
    else if (choice == "B")
    {
        var requestBody = new StringContent(
            """
            {
                "date":"2025-01-01",
                "temperatureC":30,
                "temperatureF":86,
                "summary":"Sunny"
            }
            """,
            Encoding.UTF8,
            "application/json");

        response = await client.PostAsync("https://localhost:7135/WeatherForecast", requestBody);
    }
    else if (choice == "C")
    {
        var requestBody = new StringContent(
            """
            {
                "date":"2025-01-01",
                "temperatureC":25,
                "temperatureF":77,
                "summary":"Cloudy"
            }
            """,
            Encoding.UTF8,
            "application/json");

        response = await client.PutAsync("https://localhost:7135/WeatherForecast", requestBody);
    }
    else if (choice == "D")
    {
        response = await client.DeleteAsync("https://localhost:7135/WeatherForecast");
    }
    else
    {
        Console.WriteLine("Invalid choice.");
        Console.WriteLine("Press any key to continue... ");
        Console.ReadKey();
        continue;
    }

    if (choice == "E")
    {
        Console.WriteLine("Program terminated.");
        break;
    }

    HttpResponseMessage response;

    Console.WriteLine();
    Console.WriteLine($"Status Code : {(int)response.StatusCode}");
    Console.WriteLine($"Status      : {response.StatusCode}");
    Console.WriteLine($"Success     : {response.IsSuccessStatusCode}");
    Console.WriteLine();

    string body = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Response: ");
    Console.WriteLine(body);

    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu... ");
    Console.ReadKey();
}