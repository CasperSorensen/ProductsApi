using System;
using ProductsApi.Configs;
using ProductsApi.Models;
using MongoDB.Driver;

namespace ProductsApi.Contexts
{
  public class ProductsContext : IProductsContext
  {
    private readonly IMongoDatabase _db;

    public ProductsContext(MongoDbConfig config)
    {
      var client = new MongoClient(config.ConnectionString);
      _db = client.GetDatabase(config.Database);
    }

    public IMongoCollection<Product> Products => _db.GetCollection<Product>("Products");

  }
}