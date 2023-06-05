using Elasticsearch.API.Models;
using Nest;

namespace Elasticsearch.API.DTOs
{
    public record ProductDTO(string Id, string Name, decimal Price, int? Stock, ProductFeatureDto? Feature)
    {
    }
}
