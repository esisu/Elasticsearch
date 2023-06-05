using Elasticsearch.API.Models;
using Nest;

namespace Elasticsearch.API.Repositories
{
    public class ProductRepository
    {

        private readonly ElasticClient _client;

        public ProductRepository(ElasticClient client)
        {
            _client = client;
        }
        
        public async Task<Product> SaveAsync(Product newproduct)
        {
            newproduct.Created=DateTime.Now;

            var response = await _client.IndexAsync(newproduct, x => x.Index("products"));

            if (!response.IsValid) return null;
            
            newproduct.Id = response.Id;
            
            return newproduct;

        }

    }
}
