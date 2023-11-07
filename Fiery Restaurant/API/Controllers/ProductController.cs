using AutoMapper;
using Business.Service.implement;
using Business.Service.Interfaces;
using Data.DataAccessLayer;
using Data.Repository.implement;
using Data.Repository.Interfaces;
using Domain;
using Domain.DTO;
using Domain.Entity;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ProductDto>> Get(string name)
        {
            return await _productService.GetProductsByNameAsync(name);
        }
    }
}
