using Elasticsearch.API.Models;

namespace Elasticsearch.API.DTOs
{
    public record ProductCreateDTO(string Name, decimal Price, int Stock, ProductFeatureDto ProductFeature)
    {
        public Product CreateProduct()
        {
            return new Product()
            {
                Name = Name,
                Price = Price,
                Stock = Stock,
                Feature = new ProductFeature()
                    { Width = ProductFeature.Width, Height = ProductFeature.Height, Color = ProductFeature.Color }
            };
        }
    }
}
