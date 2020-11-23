using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using ProductsApi.Models;
using ProductsApi.Contexts;

namespace ProductsApi.Data
{
  //TODO Product replace Products with Productsa
  public class ProductsRepository : IProductsRepository
  {
    private readonly IProductsContext _context;

    public ProductsRepository(IProductsContext context)
    {
      this._context = context;
    }

    // api/[GET]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
      return await _context
                    .Products
                    .Find(_ => true)
                    .ToListAsync();
    }

    // api/where/{id}/equals/{id} /[GET]
    public Task<Product> GetProduct(long id)
    {
      FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.Id, id);
      return _context
              .Products
              .Find(filter)
              .FirstOrDefaultAsync();
    }

    // api/[POST]
    public async Task Create(Product Product)
    {
      await _context
              .Products
              .InsertOneAsync(Product);

    }

    // api/[PUT]
    public async Task<bool> Update(Product Product)
    {
      ReplaceOneResult updateResult =
                    await _context
                            .Products
                            .ReplaceOneAsync(filter: g => g.Id == Product.Id, replacement: Product);

      return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    // api[DELETE]
    public async Task<bool> Delete(long id)
    {
      FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.Id, id);

      DeleteResult deleteResult = await _context
                                          .Products
                                        .DeleteOneAsync(filter);

      return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<long> GetNextId()
    {
      return await _context
                    .Products
                    .CountDocumentsAsync(new BsonDocument()) + 1;

    }

  }

}