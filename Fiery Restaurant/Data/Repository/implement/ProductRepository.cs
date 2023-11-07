using Azure;
using Data.DataAccessLayer;
using Data.Repository.Interfaces;
using Domain;
using Domain.DTO;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository.implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _dbContext.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }
    }

}

