using PeopleManager.Model;

namespace PeopleManager.Ui.Mvc.Services
{
    public class FunctionApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FunctionApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Find
        public async Task<IList<Function>> Find()
        {
            var route = "api/functions";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var functions = await response.Content.ReadFromJsonAsync<IList<Function>>();

            if (functions is null)
            {
                return new List<Function>();
            }

            return functions;
        }

        //Get
        public async Task<Function?> Get(int id)
        {
            var route = $"api/functions/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var function = await response.Content.ReadFromJsonAsync<Function>();

            return function;
        }

        //Create
        public async Task<Function?> Create(Function function)
        {
            var route = "api/functions";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PostAsJsonAsync(route, function);

            response.EnsureSuccessStatusCode();

            var createdFunction = await response.Content.ReadFromJsonAsync<Function>();

            return createdFunction;
        }

        //Update
        public async Task<Function?> Update(int id, Function function)
        {
            var route = $"api/functions/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PutAsJsonAsync(route, function);

            response.EnsureSuccessStatusCode();

            var updatedFunction = await response.Content.ReadFromJsonAsync<Function>();

            return updatedFunction;
        }

        //Delete
        public async Task Delete(int id)
        {
            var route = $"api/functions/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.DeleteAsync(route);

            response.EnsureSuccessStatusCode();
        }
    }
}
