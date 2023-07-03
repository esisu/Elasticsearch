using System.Collections.Immutable;
using Elasticsearch.API.Models;
using Nest;

namespace Elasticsearch.API.Repositories
{
    public class ProductRepository
    {

        private readonly ElasticClient _client;

        private const string indexName = "products";

        public ProductRepository(ElasticClient client)
        {
            _client = client;
        }

        public async Task<Product> SaveAsync(Product newproduct)
        {
            newproduct.Created = DateTime.Now;

            var response = await _client.IndexAsync(newproduct, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            if (!response.IsValid) return null;

            newproduct.Id = response.Id;

            return newproduct;

        }

        public async Task<ImmutableList<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>(s => s.Index(indexName).Query(q => q.MatchAll()));

            foreach (var resultHit in result.Hits)
            {
                resultHit.Source.Id=resultHit.Id;
            }

            return result.Documents.ToImmutableList();
        }


    }
}
