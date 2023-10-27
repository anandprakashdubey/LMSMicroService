

using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace LMS.ClientOrderHandler.API.Repository
{
    public class OrderProcessorRepository : IOrderProcessorRepository
    {
        private readonly HttpClient _httpClient;
        public OrderProcessorRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("OrderAPI").ToString());
        }

        public async Task<bool> ProcessOrder(int Id, string status)
        {
            var jsonString = JsonConvert.SerializeObject(new { id = Id, status = status });
           
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/api/Order/updateorderstatus?id={Id}&status={status}", content);
            if (response.Content != null)
                return true;
            else 
                return false;
        }
    }
}
