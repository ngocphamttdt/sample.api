using System.Collections.Generic;
using System.Threading.Tasks;
using WTPSample.Service.DTOs;

namespace WTPSample.Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductDto product);
        Task<ResultEmployee> GetEmployee(int page);
    }
}
