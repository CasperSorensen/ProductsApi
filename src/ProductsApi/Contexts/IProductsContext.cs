using System;
using MongoDB.Driver;
using ProductsApi.Models;

namespace ProductsApi.Contexts
{
  public interface IProductsContext
  {
    public IMongoCollection<Product> Products { get; }

  }
}