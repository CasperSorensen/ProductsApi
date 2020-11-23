using System;
using Xunit;
using ProductsApi.Data;
using ProductsApi.Contexts;
using ProductsApi.Configs;

namespace ProductsApi.Unittests
{
  public class UnitTest1
  {
    private ProductsContext _productsContext { get; set; }
    private ProductsRepository _productsRepository { get; set; }
    private MongoDbConfig _mongoDbConfig { get; set; }

    [Fact]
    public async void GetAllProductsTest_NotEmptyList()
    {
      this._mongoDbConfig = new MongoDbConfig();
      this._mongoDbConfig.Database = "ProductsDb";
      this._mongoDbConfig.Host = "localhost";
      this._mongoDbConfig.Port = 27018;
      this._mongoDbConfig.User = "root";
      this._mongoDbConfig.Password = "example";

      this._productsContext = new ProductsContext(this._mongoDbConfig);
      this._productsRepository = new ProductsRepository(this._productsContext);
      var result = await this._productsRepository.GetAllProducts();
      Assert.NotEmpty(result);
    }
  }
}
