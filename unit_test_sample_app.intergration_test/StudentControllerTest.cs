using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using unit_test_sample_app.core.Models;
using Xunit;

namespace unit_test_sample_app.intergration_test
{
    public class StudentControllerTest : BaseControllerTest
    {
        private readonly HttpClient _client;

        public StudentControllerTest(FakeApplicationFactory<FakeStartup> factory) : base(factory)
        {
            _client = GetFactory(true).CreateClient();
        }

        [Fact]
        public async Task GetSaveStudentReturnsOk()
        {
            var _request = new Student
            {
                FirstName = "Amesh",
                LastName = "Jayamanne",
                MobileNo = "88720324",
                Address = "5 Lorong Melayu"
            };

            var json = JsonConvert.SerializeObject(_request);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); 


            HttpResponseMessage response = null;
            string url = "api/Student";
            response = await _client.PostAsync(url, stringContent);
            var value = response.Content.ReadAsStringAsync();

            Assert.NotNull(response);
            response.EnsureSuccessStatusCode();
        }
    }
}
