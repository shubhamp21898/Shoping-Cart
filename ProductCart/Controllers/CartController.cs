using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductCart.Models;
using System.Text;

namespace ProductCart.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Cart()
        {
            List<ProductModel> cartProducts;
            if (_httpContextAccessor.HttpContext.Session.TryGetValue("CartProducts", out var cartData))
            {
                cartProducts = JsonConvert.DeserializeObject<List<ProductModel>>(Encoding.UTF8.GetString(cartData));
            }
            else
            {
                cartProducts = new List<ProductModel>();
            }

            // Pass the cartProducts to the view
            return View(cartProducts);
        }
    }
}
