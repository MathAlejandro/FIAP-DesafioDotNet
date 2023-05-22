using RestSharp;
using School.Blazor.DTO;

namespace School.Blazor.Data
{
    public class StudentService
    {
        private readonly IConfiguration _configuration;
        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<StudentDTO>> GetStudents()
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest("student");

            var response = await client.GetAsync<IEnumerable<StudentDTO>>(request);


            return response.ToList();
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest($"student/{id}");

            var response = await client.GetAsync<StudentDTO>(request);

            return response;
        }

        public async Task<int> Create(StudentDTO studentDTO)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest("student");
            request.AddJsonBody(studentDTO);

            var response = await client.PostAsync<int>(request);

            return response;
        }

        public async Task<int> Update(StudentDTO studentDTO)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest("student");
            request.AddJsonBody(studentDTO);

            var response = await client.PutAsync<int>(request);

            return response;
        }

        public async Task<int> Deactive(int id)
        {
            var client = new RestClient(new RestClientOptions(_configuration.GetValue<string>("SchoolAPIURL")));
            var request = new RestRequest($"student/{id}/deactive");

            var response = await client.PutAsync<int>(request);

            return response;
        }
    }
}
