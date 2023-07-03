using System.Collections.Immutable;
using System.Linq;
using System.Net;
using Elasticsearch.API.DTOs;
using Elasticsearch.API.Models;
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

            var responseProduct = await _productRepository.SaveAsync(productCreateDto.CreateProduct());

            if (responseProduct == null)
            {
                return ResponseDTO<ProductDTO>.Fail(new List<string>() { "hata oldu" }, HttpStatusCode.InternalServerError);
            }

            return ResponseDTO<ProductDTO>.Success(responseProduct.CreateDTO(), HttpStatusCode.Created);

        }

        public async Task<ResponseDTO<List<ProductDTO>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var productListDto = products.Select(x => new ProductDTO(x.Id, x.Name, x.Price, x.Stock, new ProductFeatureDto(x.Feature.Width, x.Feature.Height, x.Feature.Color))).ToList();

            return ResponseDTO<List<ProductDTO>>.Success(productListDto, HttpStatusCode.OK);
        }

    }
}
