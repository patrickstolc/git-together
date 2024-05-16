using DevRanker.Model;
using System.Text;
using System.Text.Json;

namespace DevRanker.Services
{
    public class HTTPService :IHTTPService
    {
        private IHttpClientFactory _clientFactory;
        public HTTPService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Profile>> getProfiles(Profile profile)
        {
            try
            {
                HttpClient client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(ConfigurationHelper.GetConfigValue("ProfileBaseURL"));

                var request = new HttpRequestMessage(HttpMethod.Get, "");

                request.Content = new StringContent(JsonSerializer.Serialize(profile), Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);

                if(response.IsSuccessStatusCode)
                {
                    List<Profile> profiles = JsonSerializer.Deserialize<List<Profile>>(await response.Content.ReadAsStreamAsync());
                    Console.WriteLine($"Mhmmm we found the profiles : {profiles.Count()}");
                    return profiles;
                }
                Console.WriteLine($"Jan wanted this stupid check :{response.StatusCode}");
                return null;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Shiiiiit we lost the profiles - im getting fired.");
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
    }
}
