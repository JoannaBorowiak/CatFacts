using System.Net;
using System.Text;
using System.Text.Json;
using CatFacts.Interfaces;

namespace CatFacts.Models
{
    public class CatFactService : ICatFactService
    {
        private HttpClient _httpClient = new HttpClient();
        private string url = "https://catfact.ninja/fact";

        public async Task<CatFact> GetFactsAsync()
        {
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<CatFact>(json);
        }      
    }
}
