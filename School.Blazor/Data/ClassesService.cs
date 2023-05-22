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


        public async Task<int> Deactive(int id)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest($"class/{id}/deactive");

            var response = await client.PutAsync<int>(request);

            return response;
        }
    }
}