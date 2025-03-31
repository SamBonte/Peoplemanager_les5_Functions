using System.Net.Http.Json;
using PeopleManager.Dtos.Results;
using PeopleManager.Dtos.Requests;
namespace PeopleManager.Sdk
{
    public class FunctionApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FunctionApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Find
        public async Task<IList<FunctionResult>> Find()
        {
            var route = "api/functions";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var functions = await response.Content.ReadFromJsonAsync<IList<FunctionResult>>();

            if (functions is null)
            {
                return new List<FunctionResult>();
            }

            return functions;
        }

        //Get
        public async Task<FunctionResult?> Get(int id)
        {
            var route = $"api/functions/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var function = await response.Content.ReadFromJsonAsync<FunctionResult>();

            return function;
        }

        //Create
        public async Task<FunctionResult?> Create(FunctionRequest request)
        {
            var route = "api/functions";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PostAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var createdFunction = await response.Content.ReadFromJsonAsync<FunctionResult>();

            return createdFunction;
        }

        //Update
        public async Task<FunctionResult?> Update(int id, FunctionRequest request)
        {
            var route = $"api/functions/{id}";
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            var response = await httpClient.PutAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var updatedFunction = await response.Content.ReadFromJsonAsync<FunctionResult>();

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
