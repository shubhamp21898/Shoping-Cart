using System.ComponentModel.DataAnnotations;

namespace Product.API.Entities
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int  CategoryId { get; set; }    
    }
}
