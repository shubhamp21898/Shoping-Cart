using Product.API.DTO;
using Product.API.Entities;
using System.Xml;

namespace Product.API.Mapper
{
    public static class ModelConverter
    {
        public static Products DtoToModel(ProductDTO model)
        {
            return new Products
            {
                Id = model.Id,
                Title = model.Title,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };
        }

        public static ProductDTO ModelToDto(Products model)
        {
            return new ProductDTO
            {
                Id = model.Id,
                Title = model.Title,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };
        }
    }
}
