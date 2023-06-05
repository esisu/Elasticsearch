using Elasticsearch.Net;
using Nest;

namespace Elasticsearch.API.Extension
{
    public  static class ElasticSearch
    {
        public static void AddElastic(this IServiceCollection service,IConfiguration configuration)
        {
            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["URL"]!));
            var settings = new ConnectionSettings(pool);
            //settings.BasicAuthentication()
            var client = new ElasticClient(settings);
            service.AddSingleton(client);
        }
    }
}
