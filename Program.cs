using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TestAPIForWS
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            string response1 = await program.client.GetStringAsync("https://evilinsult.com/generate_insult.php?lang=en&type=json");
            //Console.WriteLine(response);

            Insult insult = JsonConvert.DeserializeObject<Insult>(response1);
            Console.WriteLine(insult.insult+"\n");
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Post,
                RequestUri = new Uri("https://deep-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
    {
        { "x-rapidapi-host", "deep-translate1.p.rapidapi.com" },
        { "x-rapidapi-key", "3c24845d2bmsh71022e2f51e8220p15d43bjsn73f828573461" },
    },
                Content = new StringContent($"{{\r\"q\": \"Hello World\",\r\"source\": \"en\",\r\"target\": \"es\"\r}}")
    {
                Headers =
        {
                    ContentType = new MediaTypeHeaderValue("application/json")
        }
            }
        };
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine("TRANSLATE "+body);
}
        }
        private async Task GetTodoItems()
        {
            while (true)
            {
                string response = await client.GetStringAsync("https://evilinsult.com/generate_insult.php?lang=en&type=json");
                //Console.WriteLine(response);

                Insult insult = JsonConvert.DeserializeObject<Insult>(response);
                Console.WriteLine($"\n{insult.insult}\n");
                
            }
        }
    }
    class Insult
    {
        public int number { get; set; }
        public string language { get; set; }
        public string insult { get; set; }
        public DateTime created { get; set; }
        public int shown { get; set; }
        public string createdby { get; set; }
        public int active { get; set; }
        public string comment { get; set; }
    }
    class FactOfCat
    {
        
        public string user { get; set; }
        public string text { get; set; }
        public string type { get; set; }

    }
}

