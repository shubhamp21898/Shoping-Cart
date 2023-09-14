using Newtonsoft.Json;
using ProductCart.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ProductCart.Services
{
    public class User_Service : IUser_Service
    {
        private readonly HttpClient _httpClient;

        public User_Service(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ShoingCart");
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7003/api/Product_ServiceAPI");
                request.Headers.Add("Accept", "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var apiContent = await response.Content.ReadAsStringAsync();

                var productData = JsonConvert.DeserializeObject<List<ProductModel>>(apiContent);
                return productData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UserLogin(Login login)
        {
            try
            {
                string token;
                var jsonProduct = JsonConvert.SerializeObject(login);
                var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7118/api/Registration/login", content);
                //response.EnsureSuccessStatusCode();

                var apiContent = await response.Content.ReadAsStringAsync();
                

                if (response.IsSuccessStatusCode)
                {
                    
                     token = apiContent.Trim();
                    return token;
                }
                else
                {
                    //throw new Exception($"Login failed: {apiContent}");
                    return token = string.Empty;
                    
                }

                //return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        

    }
}
