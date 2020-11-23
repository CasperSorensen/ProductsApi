using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace ProductsApi.Data
{
  public interface IProductsRepository
  {

    public Task<IEnumerable<Product>> GetAllProducts();

    public Task<Product> GetProduct(long id);

    public Task Create(Product Product);

    public Task<bool> Update(Product Product);

    public Task<bool> Delete(long id);

    public Task<long> GetNextId();
  }

}