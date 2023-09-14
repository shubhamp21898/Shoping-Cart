using Microsoft.AspNetCore.Mvc;
using Product.API.Data;
using Product.API.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_ServiceAPIController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public Product_ServiceAPIController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return _context.Products.ToList();
        }

        // GET api/<Product_ServiceAPIController>/5
        [HttpGet("{id}")]
        public Products Get(int id)
        {
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<Product_ServiceAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Products product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<Product_ServiceAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Product_ServiceAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
