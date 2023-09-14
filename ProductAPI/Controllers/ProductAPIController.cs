using Microsoft.AspNetCore.Mvc;
using Product.API.Model;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductAPIController : ControllerBase
    {
        [HttpGet]
        [Route("api/Product")]
        public IActionResult GetAllProducts()
        {
            try
            {
                // Fetch the product data from your data source
                var productData = GetProductData();

                return Ok(productData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching the product data.");
            }
        }

        private List<ProductAPIModel> GetProductData()
        {
          
            var products = new List<ProductAPIModel>
            {
                new ProductAPIModel { Id = 1, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new ProductAPIModel { Id = 1, Title = "IPhone 13", Description = "Apple Mobile", Price = 50000.00m, ImageUrl = "https://technextgroup.com/wp-content/uploads/2022/03/Tech-Next-Store-iPhone-13-Pro-Starlight1-1.jpg", CategoryId = 1 },
                new ProductAPIModel { Id = 1, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new ProductAPIModel { Id = 1, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new ProductAPIModel { Id = 1, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new ProductAPIModel { Id = 1, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 }
                // Add more product entries as needed
            };

            return products;
        }

    }
}