using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductCart.Models;
using ProductCart.Services;
using Microsoft.VisualBasic;
using Microsoft.CodeAnalysis;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ProductCart.Controllers
{
    public class ProductUIController : Controller
    {
       
        private readonly IProduct_Service _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public const string JSRecordAdd = "alert('Record successfully Added !');";
        private static List<ProductModel> cartProducts = new List<ProductModel>();


        public ProductUIController(IProduct_Service productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Product()
        {
           var productData = await _productService.GetAllProduct();
          
            return View(productData);
        }

        public async Task<IActionResult> ProductHome() 
        {
            var productData = await _productService.GetAllProduct();
            
            return View(productData);
        }

        public async Task<IActionResult> ProductAbout()
        {
            var productData = await _productService.GetAllProduct();
         
            return View(productData);
           
        }

        
        
        public IActionResult Add_NewProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_NewProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _productService.AddNewProduct(product);

                if (isAdded)
                {
                    //Response.Redirect("<script>alert('Data inserted successfully')</script>");
                    return RedirectToAction("Product", "ProductUI", new { area = "" });
                }
            }
            return View(product);
        }


        
        [HttpGet]
        public async Task<IActionResult> ProductDetailsById(int id)
        {
            ProductModel product =await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return PartialView("ProductDetailsById", product);
        }

        

        [HttpPost]
        public async Task<IActionResult> Cart(int productId)
        {
            // Fetch the product from your API using the GetProductById method
            var product = await _productService.GetProductById(productId);

            if (product != null)
            {
                // Retrieve the cartProducts list from session
                var cartProductsJson = _httpContextAccessor.HttpContext.Session.GetString("CartProducts");
                List<ProductModel> cartProducts;
                if (!string.IsNullOrEmpty(cartProductsJson))
                {
                    cartProducts = JsonConvert.DeserializeObject<List<ProductModel>>(cartProductsJson);
                }
                else
                {
                    cartProducts = new List<ProductModel>();
                }

                cartProducts.Add(product);

                // Store the cartProducts list in session
                _httpContextAccessor.HttpContext.Session.SetString("CartProducts", JsonConvert.SerializeObject(cartProducts));
            }

            // Return a redirect to the Cart action to display the updated cart
            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            // Retrieve the cartProducts list from session
            var cartProductsJson = _httpContextAccessor.HttpContext.Session.GetString("CartProducts");
            List<ProductModel> cartProducts;
            if (!string.IsNullOrEmpty(cartProductsJson))
            {
                cartProducts = JsonConvert.DeserializeObject<List<ProductModel>>(cartProductsJson);
            }
            else
            {
                cartProducts = new List<ProductModel>();
            }

            return View(cartProducts);
        }

        public int GetCartCount()
        {
            var cartProductsJson = _httpContextAccessor.HttpContext.Session.GetString("CartProducts");
            if (!string.IsNullOrEmpty(cartProductsJson))
            {
                var cartProducts = JsonConvert.DeserializeObject<List<ProductModel>>(cartProductsJson);
                return cartProducts.Count;
            }

            return 0;
        }

    }
}
