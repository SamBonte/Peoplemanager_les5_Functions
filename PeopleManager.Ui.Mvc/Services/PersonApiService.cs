using PeopleManager.Model;

namespace PeopleManager.Ui.Mvc.Services
{
    public class PersonApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Find
        public async Task<IList<Person>> Find()
        {
            var route = "api/people";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var people = await response.Content.ReadFromJsonAsync<IList<Person>>();

            if (people is null)
            {
                return new List<Person>();
            }

            return people;
        }

        //Get
        public async Task<Person?> Get(int id)
        {
            var route = $"api/people/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var person = await response.Content.ReadFromJsonAsync<Person>();

            return person;
        }

        //Create
        public async Task<Person?> Create(Person person)
        {
            var route = "api/people";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PostAsJsonAsync(route, person);

            response.EnsureSuccessStatusCode();

            var createdPerson = await response.Content.ReadFromJsonAsync<Person>();

            return createdPerson;
        }

        //Update
        public async Task<Person?> Update(int id, Person person)
        {
            var route = $"api/people/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PutAsJsonAsync(route, person);

            response.EnsureSuccessStatusCode();

            var updatedPerson = await response.Content.ReadFromJsonAsync<Person>();

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
