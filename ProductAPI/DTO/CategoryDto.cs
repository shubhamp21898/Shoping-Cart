using System.ComponentModel.DataAnnotations;

namespace Product.API.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
    }
}
