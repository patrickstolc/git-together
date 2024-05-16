
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using Suggestion.Core.Entities;
using Suggestion.Core.Repository;

namespace Suggestion.Core.Services
{
    public class Service : IService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        private readonly string rankingServiceAddress;

        private IRepository _repository;


        public Service(IHttpClientFactory httpClientFactory, IRepository repository)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
            _repository = repository;
        }
        public async Task<Entiies.Suggestion> CreateSuggestion(Entiies.Suggestion suggestion)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, rankingServiceAddress);

            var response = _client.SendAsync(request).Result;

            var rankingProfiles = new List<RankProfile>();

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                rankingProfiles =  JsonConvert.DeserializeObject<List<RankProfile>>(result);
            }

            var suggestionDTO = new Entiies.Suggestion
            {
                ProfileRankings = rankingProfiles,
                Id = suggestion.Id,
                userID = suggestion.userID
            };

            return suggestionDTO;
        }

        public List<Entiies.Suggestion> GetSuggestions()
        {
            return _repository.GetSuggestions();
        }
    }
}
