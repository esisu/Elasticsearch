using System.Net;
using Elasticsearch.API.DTOs;
using Elasticsearch.API.Repositories;

namespace Elasticsearch.API.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<ResponseDTO<ProductDTO>> SaveAsync(ProductCreateDTO productCreateDto)
        {
            
            var response = await _productRepository.SaveAsync(productCreateDto.CreateProduct());

            if (response == null)
            {
                return ResponseDTO<ProductDTO>.Fail(new List<string>() { "hata oldu" }, HttpStatusCode.InternalServerError);
            }


        }

    }
}
