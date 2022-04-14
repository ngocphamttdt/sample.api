using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTPSample.Database;
using WTPSample.Database.DAL.Contracts;
using WTPSample.Database.Entities;
using WTPSample.Service.Contracts;
using WTPSample.Service.DTOs;

namespace WTPSample.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repos;
        private readonly WtpContext _context;
        public ProductService(IRepository<Product> repos, WtpContext context) {
            _repos = repos;
            _context = context;
        }
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var data = (await _repos.GetAsync()).Select(x=> new ProductDto { 
                Id = x.Id,
                Name = x.Name
            });
            
            return data;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto product)
        {
            var productEntity = new Product { Name = product.Name };
            await _repos.AddAsync(productEntity);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ResultEmployee> GetEmployee(int page)
        {
            int numRecords = 5;
            var list = new List<EmployeeDto>()
            {
                new EmployeeDto{Id = 0, FirstName="Ngoc", LastName="Pham"},
                new EmployeeDto{Id = 1, FirstName="Ngoc1", LastName="Pham"},
                new EmployeeDto{Id = 2, FirstName="Ngoc2", LastName="Pham"},
                new EmployeeDto{Id = 3, FirstName="Ngoc3", LastName="Pham"},
                new EmployeeDto{Id = 4, FirstName="Ngoc4", LastName="Pham"},
                new EmployeeDto{Id = 5, FirstName="Ngoc5", LastName="Pham"},
                new EmployeeDto{Id = 6, FirstName="Ngoc6", LastName="Pham"},
                new EmployeeDto{Id = 7, FirstName="Ngoc7", LastName="Pham"},
                new EmployeeDto{Id = 8, FirstName="Ngoc8", LastName="Pham"},
                new EmployeeDto{Id = 9, FirstName="Ngoc9", LastName="Pham"},
                new EmployeeDto{Id = 10, FirstName="Ngoc10", LastName="Pham"},
                new EmployeeDto{Id = 11, FirstName="Ngoc11", LastName="Pham"},
                new EmployeeDto{Id = 12, FirstName="Ngoc12", LastName="Pham"},
                new EmployeeDto{Id = 13, FirstName="Ngoc13", LastName="Pham"},
                new EmployeeDto{Id = 14, FirstName="Ngoc14", LastName="Pham"}
            };
            if(page == 0)
            {
                var data = list.Where(x => x.Id < 5).ToList();
                var result = new ResultEmployee
                {
                    Count = list.Count(),
                    Employees = data
                };
                return result;
            }
            if (page != 0)
            {
                var data = list.Where(x => x.Id >= page * 5  && x.Id < (page +1) * 5).ToList();
                var result = new ResultEmployee
                {
                    Count = list.Count(),
                    Employees = data
                };
                return result;
            }
            return null;
        }
    }
}
