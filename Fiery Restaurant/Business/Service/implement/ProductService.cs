using AutoMapper;
using Business.Logger.Interfaces;
using Business.Service.Interfaces;
using Data.DataAccessLayer;
using Data.Repository.Interfaces;
using Domain;
using Domain.DTO;
using Domain.Entity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.implement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogingManager _loggerService;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ILogingManager loggerService, IMapper mapper)
        {
            _productRepository = productRepository;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name)
        {
            var products = await _productRepository.GetProductsByNameAsync(name);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            _loggerService.LogInfo($"Found {productDtos.Count()} products with name '{name}'.");

            return productDtos;
        }
    }
}
