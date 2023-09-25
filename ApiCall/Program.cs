using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

class Program{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        try{
            using HttpResponseMessage response = await client.GetAsync("https://api.jikan.moe/v4/anime/1");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(JsonObject.Parse(responseBody));
        }
        catch(HttpRequestException e){
            Console.WriteLine("error: {0}", e.Message);
        }
    }
}