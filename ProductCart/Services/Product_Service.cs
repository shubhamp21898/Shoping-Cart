using Newtonsoft.Json;
using ProductCart.Models;
using System.Net.Http;
using System.Text;

namespace ProductCart.Services
{
    public class Product_Service : IProduct_Service
    {
        private readonly HttpClient _httpClient;

        public Product_Service(IHttpClientFactory httpClientFactory)
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

        public async Task<bool> AddNewProduct(ProductModel product)
        {
            try
            {
                var jsonProduct = JsonConvert.SerializeObject(product);
                var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7003/api/Product_ServiceAPI", content);
                response.EnsureSuccessStatusCode();

                var apiContent = await response.Content.ReadAsStringAsync();
                bool success=false ;
                if(response.IsSuccessStatusCode==true)
                {
                    success = response.IsSuccessStatusCode;
                }
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7003/api/Product_ServiceAPI/{id}");
                request.Headers.Add("Accept", "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var apiContent = await response.Content.ReadAsStringAsync();

                var productData = JsonConvert.DeserializeObject<ProductModel>(apiContent);
                return productData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
