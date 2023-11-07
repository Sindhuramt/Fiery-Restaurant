using Domain.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name);
    }
}
