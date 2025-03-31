using System.Net.Http.Json;
using PeopleManager.Dtos.Results;
using PeopleManager.Dtos.Requests;
namespace PeopleManager.Sdk
{
    public class PersonApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Find
        public async Task<IList<PersonResult>> Find()
        {
            var route = "api/people";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var people = await response.Content.ReadFromJsonAsync<IList<PersonResult>>();

            if (people is null)
            {
                return new List<PersonResult>();
            }

            return people;
        }

        //Get
        public async Task<PersonResult?> Get(int id)
        {
            var route = $"api/people/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var person = await response.Content.ReadFromJsonAsync<PersonResult>();

            return person;
        }

        //Create
        public async Task<PersonResult?> Create(PersonRequest request)
        {
            var route = "api/people";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PostAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var createdPerson = await response.Content.ReadFromJsonAsync<PersonResult>();

            return createdPerson;
        }

        //Update
        public async Task<PersonResult?> Update(int id, PersonRequest request)
        {
            var route = $"api/people/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PutAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var updatedPerson = await response.Content.ReadFromJsonAsync<PersonResult>();

            return updatedPerson;
        }

        //Delete
        public async Task Delete(int id)
        {
            var route = $"api/people/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.DeleteAsync(route);

            response.EnsureSuccessStatusCode();
        }
    }
}
