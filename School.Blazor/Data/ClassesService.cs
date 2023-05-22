using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using RestSharp;
using School.Blazor.DTO;

namespace School.Blazor.Data
{
    public class ClassesService
    {
        private readonly IConfiguration _configuration;
        public ClassesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<ClassDTO>> GetClasses()
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest("Class");

            var response = await client.GetAsync<IEnumerable<ClassDTO>>(request);
            

            return response.ToList();
        }

        public async Task<ClassDTO> GetClass(int id)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest($"class/{id}");

            var response = await client.GetAsync<ClassDTO>(request);

            return response;
        }

        public async Task<int> Create(ClassDTO classDTO)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest("class");
            request.AddJsonBody(classDTO);

            var response = await client.PostAsync<int>(request);

            return response;
        }

        public async Task<int> Update(ClassDTO classDTO)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest("class");
            request.AddJsonBody(classDTO);

            var response = await client.PutAsync<int>(request);

            return response;
        }

        public async Task<int> Deactive(int id)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest($"class/{id}/deactive");

            var response = await client.PutAsync<int>(request);

            return response;
        }
    }
}